using System;
using Ushahidi.Common.Geo;
using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Add incident view controller
    /// </summary>
    public class AddIncidentViewController : BaseViewController<AddIncidentView, AddIncidentModel>
    {
        /// <summary>
        /// Save error caption
        /// </summary>
        public override string SaveErrorCaption
        {
            get { return "Missing Fields"; }
        }

        /// <summary>
        /// Save error message
        /// </summary>
        public override string SaveErrorMessage
        {
            get { return "Please verify all required fields are entered"; }
        }

        /// <summary>
        /// Load AddIncidentView with AddIncidentModel data
        /// </summary>
        public override void Load(object[] parameters)
        {
            View.Categories = Model.Categories;
            View.Locales = Model.Locales;
            View.Title = string.Empty;
            View.Category = null;
            View.Locale = null;
            View.Date = DateTime.Now;
            View.Description = string.Empty;
            View.Images = null;
        }

        /// <summary>
        /// Save AddIncidentModel from AddIncidentView data
        /// </summary>
        /// <returns>true, if successful</returns>
        public override bool Save()
        {
            if (View.ShouldSave)
            {
                Model.Title = View.Title;
                Model.Category = View.Category;
                Model.Locale = View.Locale;
                Model.Date = View.Date;
                Model.Description = View.Description;
                Model.Images = View.Images;
                Model.Longitude = GeoManager.GetLongitude();
                Model.Latitude = GeoManager.GetLatitude();
                return Model.Save();
            }
            return true;
        }
    }
}
