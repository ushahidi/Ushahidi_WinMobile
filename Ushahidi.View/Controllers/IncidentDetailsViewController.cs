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
                Incident = parameters[0] as Incident;
                if (Incident != null)
                {
                    View.ID = Incident.ID;
                    View.MediaItems = Incident.MediaItems;
                    View.Title = Incident.Title;
                    View.Category = Incident.CategoryTitle;
                    View.Locale = Incident.Locale;
                    View.Date = Incident.Date;
                    View.Verified = Incident.Verified;
                    View.Active = Incident.Active;
                    View.Description = Incident.Description;
                }
            }
        }

        protected Incident Incident { get; private set; }

        public override bool Save()
        {
            Incident.MediaItems = View.MediaItems;
            //TODO save incident media to XML
            return base.Save();
        }
    }
}
