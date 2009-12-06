using System;
using System.Linq;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Resources;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Map View Controller
    /// </summary>
    public class MapViewController : BaseViewController<MapView>
    {
        public override void Load(object[] parameters)
        {
            View.Username = ResourcesManager.BingMapUsername;
            View.Password = ResourcesManager.BingMapPassword;
            View.MapApiKey = ResourcesManager.GoogleMapApiKey;
            View.ZoomLevel = DataManager.MapZoomLevel;
            View.ZoomLevels = Enumerable.Range(1, 20);
            View.MaxZoomLevel = 20;
            if (DataManager.DefaultLocale != null && 
                string.IsNullOrEmpty(DataManager.DefaultLocale.Latitude) == false &&
                string.IsNullOrEmpty(DataManager.DefaultLocale.Longitude) == false)
            {
                View.Latitude = Convert.ToDouble(DataManager.DefaultLocale.Latitude);
                View.Longitude = Convert.ToDouble(DataManager.DefaultLocale.Longitude);
                View.LocationName = DataManager.DefaultLocale.Name;
            }
            else
            {
                View.Latitude = double.MinValue;
                View.Longitude = double.MinValue;
                View.LocationName = string.Empty;
            }
        }

        public override bool Save()
        {
            if (View.ShouldSave)
            {
                DataManager.MapZoomLevel = View.ZoomLevel;
                if (View.Latitude != 0 && 
                    View.Longitude != 0 && 
                    string.IsNullOrEmpty(View.LocationName) == false)
                {
                    Locale locale = new Locale
                    {
                        CountryID = null,
                        Latitude = View.Latitude.ToString(),
                        Longitude = View.Longitude.ToString(),
                        Name = View.LocationName
                    };
                    //save new locale
                    DataManager.AddLocale(locale);
                }
            }
            return true;
        }
    }
}