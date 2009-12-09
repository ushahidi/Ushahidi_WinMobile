using System;
using System.Linq;
using Ushahidi.Common.Extensions;
using Ushahidi.Common.Logging;
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
            View.Satellite = DataManager.MapType == "Satellite";
            View.ZoomLevel = DataManager.MapZoomLevel;
            View.ZoomLevels = Enumerable.Range(1, 20);
            View.MaxZoomLevel = 20;
            if (parameters.Exists(0) && parameters[0] is Locale)
            {
                Locale locale = parameters[0] as Locale;
                if (locale != null)
                {
                    View.Latitude = Convert.ToDouble(locale.Latitude);
                    View.Longitude = Convert.ToDouble(locale.Longitude);
                    View.LocationName = locale.Name;
                }
                else
                {
                    View.Latitude = double.MinValue;
                    View.Longitude = double.MinValue;
                    View.LocationName = string.Empty;
                }
            }
            else if (DataManager.DefaultLocale != null && 
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
                if (View.Latitude.AlmostEquals(0) == false && View.Longitude.AlmostEquals(0) == false &&
                    View.Latitude != double.MinValue && View.Longitude != double.MinValue)
                {
                    if (DataManager.Locales.Any(l => Convert.ToDouble(l.Latitude).AlmostEquals(View.Latitude) &&
                                                     Convert.ToDouble(l.Longitude).AlmostEquals(View.Longitude)))
                    {
                        Log.Info("MapViewController.Save", "Lat:{0} Long:{1} Exists!", View.Latitude, View.Longitude);
                    }
                    else
                    {
                        Log.Info("MapViewController.Save", "Adding Lat:{0} Long:{1}", View.Latitude, View.Longitude);
                        Locale locale = new Locale
                        {
                            CountryID = null,
                            Latitude = View.Latitude.ToString(),
                            Longitude = View.Longitude.ToString(),
                            Name = string.IsNullOrEmpty(View.LocationName)
                                 ? string.Format("({0},{1})", View.Latitude, View.Longitude) : View.LocationName
                        };
                        DataManager.AddLocale(locale);    
                    }
                }
            }
            return true;
        }
    }
}