using System;
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
        /// Load the view
        /// </summary>
        public override void Load()
        {
            View.Title = string.Empty;
            View.Type = null;
            View.Locale = null;
            View.Date = DateTime.Now;
            View.Description = string.Empty;
            View.Images = null;
        }
    }
}
