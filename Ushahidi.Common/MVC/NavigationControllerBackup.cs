using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Push a new type onto the stack passing it the provided arguments
    /// </summary>
    /// <param name="args">args to pass to form</param>
    //void Push<T>(params object[] args) where T : IViewController, new();

    /// <summary>
    /// Push a new type onto the stack passing it the provided arguments
    /// </summary>
    /// <param name="args">args to pass to form</param>
    //void Push<T>(bool clearStack, params object[] args) where T : IViewController, new();

    class NavigationControllerBackup
    {
        /// <summary>
        /// Push a new type onto the stack passing it the provided arguments
        /// </summary>
        /// <param name="args">args to pass to form</param>
        //public void Push<T>(params object[] args) where T : IViewController, new()
        //{
        //    Push<T>(false, args);
        //}

        /// <summary>
        /// Push a new type onto the stack passing it the provided arguments
        /// </summary>
        /// <param name="args">args to pass to form</param>
        //public void Push<T>(bool clearStack, params object[] args) where T : IViewController, new()
        //{
        //    using (new WaitCursor())
        //    {
        //        IViewController previousViewController = Stack.Count > 0 ? Stack.Peek() : null;
        //        IViewController viewController;
        //        if (!Cache.ContainsKey(typeof(T)))
        //        {
        //            viewController = new T();
        //            viewController.Back += Pop;
        //            Cache.Add(typeof(T), viewController);
        //        }
        //        else
        //        {
        //            viewController = Cache[typeof(T)];
        //        }
        //        if (clearStack)
        //        {
        //            Stack.Clear();
        //        }
        //        Stack.Push(viewController);
        //        viewController.Populate(args);
        //        viewController.Render();
        //        viewController.Show();
        //        if (previousViewController != null)
        //        {
        //            previousViewController.Hide();
        //        }
        //    }
        //}
    }
}
