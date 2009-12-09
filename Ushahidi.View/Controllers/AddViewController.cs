using System;
using System.Linq;
using Ushahidi.Common.Extensions;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Add incident view controller
    /// </summary>
    public class AddViewController : BaseViewController<AddView>
    {
        /// <summary>
        /// Load AddView
        /// </summary>
        /// <param name="parameters">parameters for AddView</param>
        public override void Load(object[] parameters)
        {
            if (parameters.Exists(0) && parameters[0] is Media)
            {
                Media media = parameters.ItemAtIndex<Media>(0);
                if (string.IsNullOrEmpty(media.Link) == false)
                {
                    View.AddMedia(media);
                }
            }
            else if (parameters.Exists(0) && parameters.Exists(1))
            {
                View.Locales = DataManager.Locales;
                double latitude = Convert.ToDouble(parameters[0]);
                double longitude = Convert.ToDouble(parameters[1]);
                if (latitude != double.MinValue && longitude != double.MinValue)
                {
                    Locale locale = DataManager.Locales.FirstOrDefault(l => Convert.ToDouble(l.Latitude).AlmostEquals(latitude) &&
                                                                            Convert.ToDouble(l.Longitude).AlmostEquals(longitude));
                    View.Locale = locale ?? DataManager.Locales.LastOrDefault();
                }
            }
            else if (parameters == null || parameters.Length == 0)
            {
                View.Categories = DataManager.Categories;
                View.Locales = DataManager.Locales;
                View.Locale = DataManager.DefaultLocale;
                View.Title = string.Empty;
                View.Date = DateTime.Now;
                View.Description = string.Empty;
                View.MediaItems = null;
                View.ImageSize = DataManager.ImageSize;
            }
        }

        /// <summary>
        /// Save AddView
        /// </summary>
        /// <returns>true, if successful</returns>
        public override bool Save()
        {
            if (View.ShouldSave)
            {
                Incident incident = new Incident
                {
                    ID = (-1),
                    Date = View.Date,
                    Title = View.Title,
                    Description = View.Description,
                    Categories = View.Categories.ToArray(),
                    MediaItems = View.MediaItems.ToArray(),
                    Locale = View.Locale,
                    Mode = 1,
                    Active = true,
                    Verified = false,
                    Upload = true
                };
                return DataManager.AddIncident(incident);
            }
            return true;
        }
    }
}
