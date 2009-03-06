using Ushahidi.View.Controllers;

namespace Ushahidi.View.Views
{
    public partial class HomeView
    {
        private void OnViewIncidents(object sender, System.EventArgs e)
        {
            OnForward(typeof(IncidentListViewController));
        }

        private void OnAddIncident(object sender, System.EventArgs e)
        {
            OnForward(typeof(AddIncidentViewController));
        }
    }
}