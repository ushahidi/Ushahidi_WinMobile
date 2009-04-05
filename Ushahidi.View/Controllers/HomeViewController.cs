using System;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Logging;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Home View Controller
    /// </summary>
    public class HomeViewController : BaseViewController<HomeView, HomeModel>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load()
        {
            Keyboard.AutoShowHideKeyboard = DataManager.ShowKeyboard;
            View.Description = Model.Description;
            View.Logo = Model.Logo;
            //try
            //{
            //    foreach (Incident incident in DataManager.Incidents)
            //    {
            //        Log.Info("", "Incident: {0}", incident);
            //        foreach (Media media in incident.MediaItems)
            //        {
            //            Log.Info("", " Media: {0}", media);
            //        }
            //    }
            //    foreach (Category category in DataManager.Categories)
            //    {
            //        Log.Info("", "Category: {0}", category);
            //    }
            //    foreach (Country country in DataManager.Countries)
            //    {
            //        Log.Info("", "Country: {0}", country);
            //    }
            //    foreach (Locale locale in DataManager.Locales)
            //    {
            //        Log.Info("", "Locale: {0}", locale);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Log.Exception("HomeViewController.Load", "Exception {0}", ex.Message);
            //}
        }
    }
}
