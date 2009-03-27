using Ushahidi.Common.Controls;
using Ushahidi.Model;
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
            //foreach (Category category in DataManager.Categories.Items)
            //{
            //    Log.Info("Category: {0} {1} {2} {3}", category.ID, category.Title, category.Description, category.Color);
            //}
            //foreach (Country country in DataManager.Countries.Items)
            //{
            //    Log.Info("Country: {0} {1} {2} {3}", country.ID, country.ISO, country.Name, country.Capital);
            //}
            //foreach (Locale locale in DataManager.Locales.Items)
            //{
            //    Log.Info("Locale: {0} {1} {2} {3} {4}", locale.ID, locale.Name, locale.CountryID, locale.Latitude, locale.Longitude);
            //}
            //foreach (Incident incident in DataManager.Incidents.Items)
            //{
            //    Log.Info("Incident: {0} {1} {2}", incident.ID, incident.Title, incident.Description);
            //}
        }
    }
}
