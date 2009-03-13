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
        /// Load AddIncidentView with AddIncidentModel data
        /// </summary>
        public override void Load()
        {
            View.Title = Model.Title;
            View.Type = Model.Type;
            View.Locale = Model.Locale;
            View.Date = Model.Date;
            View.Description = Model.Description;
            View.Images = Model.Images;
            View.Types = Model.Types;
        }

        /// <summary>
        /// Save AddIncidentModel from AddIncidentView data
        /// </summary>
        /// <returns>true, if successful</returns>
        public override bool Save()
        {
            Model.Title = View.Title;
            Model.Type = View.Type;
            Model.Locale = View.Locale;
            Model.Date = View.Date;
            Model.Description = View.Description;
            Model.Images = View.Images;
            //TODO save values to database
            return true;
        }
    }
}
