using Ushahidi.Model.Models;
using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    public class IncidentDetailsViewController : BaseViewController<IncidentDetailsView, IncidentDetailsModel>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load(object[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                Incident incident = parameters[0] as Incident;
                if (incident != null)
                {
                    //View.Photos = incident.Photos;
                    View.MediaItems = incident.MediaItems;
                    View.Title = incident.Title;
                    View.Category = incident.CategoryTitle;
                    View.Locale = incident.Locale.Name;
                    View.Date = incident.Date;
                    View.Verified = incident.Verified;
                    View.Active = incident.Active;
                    View.Description = incident.Description;
                    View.Latitude = incident.Locale.Latitude;
                    View.Longitude = incident.Locale.Longitude;
                }
            }
        }

        public override bool Save()
        {
            return base.Save();
        }
    }
}
