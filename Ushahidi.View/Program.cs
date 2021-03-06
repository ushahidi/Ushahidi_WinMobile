﻿using System;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Logging;
using Ushahidi.Common.MVC;
using Ushahidi.Model.Extensions;
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
            Log.Info("Program.Main", "Starting...");
            try
            {
                using (INavigationController navigationController = new NavigationController())
                {
                    navigationController.Push(typeof(HomeViewController));
                    navigationController.Run();
                }
            }
            catch (Exception ex)
            {
                Dialog.Error("runtimeException".Translate(), ex.Message, ex);
            }
            Log.Info("Program.Main", "...Exiting");
        }
    }
}