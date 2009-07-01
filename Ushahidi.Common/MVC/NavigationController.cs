using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Logging;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Navigation Controller
    /// </summary>
    public class NavigationController : INavigationController
    {
        /// <summary>
        /// The stack of views
        /// </summary>
        private readonly Stack<IViewController> Stack = new Stack<IViewController>();

        /// <summary>
        /// The cache of loaded views
        /// </summary>
        private readonly IDictionary<Type, IViewController> Cache = new Dictionary<Type, IViewController>();

        /// <summary>
        /// The root view controller
        /// </summary>
        protected IViewController RootViewController { get; private set; }

        /// <summary>
        /// Stack depth
        /// </summary>
        public int Depth
        {
            get { return Stack.Count; }
        }

        /// <summary>
        /// Run application thread
        /// </summary>
        public void Run()
        {
            Log.Info("NavigationController.Run");
            try
            {
                do
                {
                    //continue to run while stack contains view controllers
                    Application.DoEvents();
                } while (Stack.Count > 0);
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Push a new type onto the stack passing it the provided arguments
        /// </summary>
        /// <param name="type">view controller type</param>
        public void Push(Type type)
        {
            Push(type, false);
        }

        /// <summary>
        /// Push a new type onto the stack passing it the provided arguments
        /// </summary>
        /// <param name="type">view controller type</param>
        /// <param name="clearStack">should clear stack?</param>
        /// <param name="parameters">parameters to pass to next view controller</param>
        public void Push(Type type, bool clearStack, params object [] parameters)
        {
            Log.Info("NavigationController.Push", "type={0} clearStack={1} parameters={2}", type.Name, clearStack, parameters.Length);
            IViewController currentViewController = (Depth > 0) ? Stack.Peek() : null;
            IViewController viewController;
            using (new WaitCursor())
            {

                if (currentViewController != null && currentViewController.Validate() == false)
                {
                    Log.Critical("NavigationController.Push", "View Controller Validate Failure");
                    return;
                }
                if (currentViewController != null && currentViewController.Save() == false)
                {
                    Log.Critical("NavigationController.Push", "View Controller Save Failure");
                    return;
                }
                //previous view controller successfuly saved, proceed to load new view controller
                if (!Cache.ContainsKey(type))
                {
                    if (!typeof (IViewController).IsAssignableFrom(type))
                    {
                        throw new ArgumentException("Invalid view controller type", "type");
                    }
                    viewController = (IViewController) Activator.CreateInstance(type);
                    viewController.Back += Pop;
                    viewController.Forward += Push;
                    viewController.Exit += Exit;
                    viewController.Initialize();
                    Cache.Add(type, viewController);
                    if (RootViewController == null)
                    {
                        RootViewController = viewController;
                    }
                }
                else
                {
                    viewController = Cache[type];
                }
                if (clearStack)
                {
                    Stack.Clear();
                    if (RootViewController != null)
                    {
                        Stack.Push(RootViewController);
                    }
                }
                Stack.Push(viewController);
                viewController.Load(parameters);
                viewController.Render();
                viewController.Translate();
            }
            viewController.Show();
            if (currentViewController != null)
            {
                currentViewController.Hide();
            }
        }

        /// <summary>
        /// Pop off the specified number of views from stack
        /// </summary>
        /// <param name="parameters">parameters to return to previous view controller</param>
        public void Pop(params object [] parameters)
        {
            Log.Info("NavigationController.Pop", "StackCount={0}", Stack.Count);
            IViewController currentViewController = (Depth > 0) ? Stack.Peek() : null;
            using (new WaitCursor())
            {
                if (currentViewController == null)
                {
                    Log.Info("NavigationController.Pop", "No previous view controller");
                }
                else if (currentViewController.Validate() == false)
                {
                    Log.Critical("NavigationController.Pop", "View Controller Validate Failure");
                }
                else if(currentViewController.Save() == false)
                {
                    Log.Critical("NavigationController.Pop", "View Controller Save Failure");
                }
                else if (Depth > 0)
                {
                    //current view controller successfully saved
                    currentViewController = Stack.Pop();
                    if (Stack.Count > 0)
                    {
                        //show previous view controller
                        IViewController viewController = Stack.Peek();
                        viewController.Load(parameters);
                        viewController.Render();
                        viewController.Translate();
                        viewController.Show();
                    }
                    if (currentViewController != null)
                    {
                        //hide current view controller
                        currentViewController.Hide();
                    }
                }
            }
        }

        /// <summary>
        /// Exit application
        /// </summary>
        private void Exit(params object [] paremeters)
        {
            Log.Info("NavigationController.Exit");
            if (Depth > 0 && Stack.Peek().Save())
            {
                Log.Info("NavigationController.Exit", "IViewController Saved");
            }
            Dispose();
        }

        /// <summary>
        /// Dispose of resources
        /// </summary>
        public void Dispose()
        {
            Log.Info("NavigationController.Dispose");
            Stack.Clear();
            foreach (IViewController view in Cache.Values.Reverse())
            {
                try
                {
                    view.Dispose();
                }
                catch (Exception exception)
                {
                    Log.Info("NavigationController.Dispose", "Exception: {0}", exception.Message);
                }
            }
        }
    }
}
