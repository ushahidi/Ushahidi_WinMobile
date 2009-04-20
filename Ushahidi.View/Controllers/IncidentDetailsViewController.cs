using System;
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
            if (parameters == null || parameters.Length == 0 || (parameters[0] is Incident) == false)
            {
                throw new ArgumentNullException("parameters", "Parameters can not be null");
            }
            Incident incident = parameters[0] as Incident;
            if (incident != null)
            {
                View.MedaItems = incident.MediaItems;
                View.Title = incident.Title;
                View.Locale = incident.LocationName;
                View.Date = incident.Date;
                View.Verified = incident.Verified;
                View.Active = incident.Active;
                View.Description = incident.Description;
                View.Latitude = incident.Longitude;
                View.Longitude = incident.Longitude;
            }
            else
            {
                throw new ArgumentException("First argument must be an Incident", "parameters");
            }
        }

        public override bool Save()
        {
            return base.Save();
        }
    }
}
