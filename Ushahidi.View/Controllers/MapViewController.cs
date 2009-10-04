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