using System;
using Ushahidi.Common.MVC;
using Ushahidi.View.Controllers;

namespace Ushahidi.View
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            using (INavigationController navigationController = new NavigationController())
            {
                navigationController.Push(typeof(HomeViewController));
                navigationController.Run();
            }
        }
    }
}