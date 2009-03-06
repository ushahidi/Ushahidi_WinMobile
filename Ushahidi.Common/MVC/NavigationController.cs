using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Ushahidi.Common.Controls;

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
            try
            {
                do
                {
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
            IViewController previousViewController = (Depth > 0) ? Stack.Peek() : null;
            IViewController viewController;
            using (new WaitCursor())
            {
                if (!Cache.ContainsKey(type))
                {
                    if (!typeof(IViewController).IsAssignableFrom(type))
                    {
                        throw new ArgumentException("Invalid view controller type", "type");
                    }
                    viewController = (IViewController)Activator.CreateInstance(type);
                    viewController.Back += Pop;
                    viewController.Forward += Push;
                    viewController.Exit += Dispose;
                    Cache.Add(type, viewController);
                }
                else
                {
                    viewController = Cache[type];
                }
                if (clearStack)
                {
                    Stack.Clear();
                }
                Stack.Push(viewController);
                viewController.Load();
                viewController.Render();
            }
            viewController.Show();
            if (previousViewController != null)
            {
                previousViewController.Hide();
            }
        }

        /// <summary>
        /// Pop off the specified number of views from stack
        /// </summary>
        public void Pop()
        {
            if (Depth != 1 || Dialog.Question("Exit", "Are you sure you would like to exit the application?"))
            {
                using (new WaitCursor())
                {
                    IViewController previousViewController = (Depth > 0) ? Stack.Pop() : null;
                    if (Stack.Count > 0)
                    {
                        IViewController viewController = Stack.Peek();
                        viewController.Load();
                        viewController.Render();
                        viewController.Show();
                    }
                    if (previousViewController != null)
                    {
                        previousViewController.Hide();
                    }
                }
            }
        }

        /// <summary>
        /// Dispose of resources
        /// </summary>
        public void Dispose()
        {
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
