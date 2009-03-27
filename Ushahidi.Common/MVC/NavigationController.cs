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
        public void Push(Type type, bool clearStack)
        {
            Log.Info("NavigationController.Push", "type={0} clearStack={1}", type.Name, clearStack);
            IViewController currentViewController = (Depth > 0) ? Stack.Peek() : null;
            IViewController viewController;
            using (new WaitCursor())
            {
                if (currentViewController != null && !currentViewController.Save())
                {
                    //unable to save previous view controller
                    Dialog.Error("Error", "There was a problem saving {0} information", currentViewController.Name);
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
                viewController.Load();
                viewController.Render();
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
        public void Pop()
        {
            Log.Info("NavigationController.Pop", "StackCount={0}", Stack.Count);
            IViewController currentViewController = (Depth > 0) ? Stack.Peek() : null;
            using (new WaitCursor())
            {
                if (currentViewController != null && !currentViewController.Save())
                {
                    //unable to save current view controller
                    if (Depth > 1)
                    {
                        Dialog.Error(currentViewController.SaveErrorCaption, currentViewController.SaveErrorMessage);
                    }
                    else
                    {
                        if (Dialog.Question("Error", "There was a problem saving {0} information. Would you like to exit anyways?",
                                            currentViewController.Name))
                        {
                            Dispose();
                        }
                    }
                }
                else if (Depth > 0 || Dialog.Question("Exit", "Are you sure you would like to exit the application?"))
                {
                    //current view controller successfully saved
                    currentViewController = Stack.Pop();
                    if (Stack.Count > 0)
                    {
                        //show previous view controller
                        IViewController viewController = Stack.Peek();
                        viewController.Load();
                        viewController.Render();
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
        private void Exit()
        {
            Log.Info("NavigationController.Exit");
            IViewController viewController = (Depth > 0) ? Stack.Peek() : null;
            if (viewController == null || 
                viewController.Save() || 
                Dialog.Question("Error", "There was a problem saving {0} information. Would you like to exit anyways?", viewController.Name))
            {
                Dispose();
            }
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
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
