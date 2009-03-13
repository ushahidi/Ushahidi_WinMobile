using System.ComponentModel;
using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    public class IncidentListViewController : BaseViewController<IncidentListView, IncidentListModel>
    {
        public override void Load()
        {
            View.Types = Model.Types;  
            View.ClearIncidents();
            foreach(Incident incident in Model.Incidents)
            {
                View.AddIncident(incident.Title, incident.Locale, 
                                 incident.Date, incident.ContributorCount, 
                                 incident.ResponseCount, incident.LinkCount, 
                                 incident.Verified, incident.Image);
            }
        }

        public override void OnModelChanged(object sender, PropertyChangedEventArgs e)
        {
            //TODO add handling when incident list model changes
        }
    }
}
