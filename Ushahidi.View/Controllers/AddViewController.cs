using System;
using System.Linq;
using Ushahidi.Common.Extensions;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.Model.Extensions;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Add incident view controller
    /// </summary>
    public class AddViewController : BaseViewController<AddView>
    {
        /// <summary>
        /// Save error caption
        /// </summary>
        public override string SaveErrorCaption
        {
            get { return "missingFields".Translate(); }
        }

        /// <summary>
        /// Save error message
        /// </summary>
        public override string SaveErrorMessage
        {
            get { return "missingFieldsVerify".Translate(); }
        }

        /// <summary>
        /// Load AddIncidentView with AddIncidentModel data
        /// </summary>
        public override void Load(object[] parameters)
        {
            View.Categories = DataManager.Categories;
            View.Locales = DataManager.Locales;
            View.Title = string.Empty;
            View.Locale = null;
            View.Date = DateTime.Now;
            View.Description = string.Empty;
            View.MediaItems = null;
        }

        /// <summary>
        /// Save AddIncidentModel from AddIncidentView data
        /// </summary>
        /// <returns>true, if successful</returns>
        public override bool Save()
        {
            if (View.ShouldSave && 
                View.Title.HasText() && 
                View.Description.HasText() && 
                View.Locale != null && 
                View.Categories.Count() > 0 && 
                View.Date != DateTime.MinValue)
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
