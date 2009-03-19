using System;
using Ushahidi.View.Controllers;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Base view
    /// </summary>
    public partial class BaseView
    {
        /// <summary>
        /// On add incident
        /// </summary>
        private void OnAddIncident(object sender, EventArgs e)
        {
            OnForward(typeof(AddIncidentViewController), true);
        }

        /// <summary>
        /// On incident list
        /// </summary>
        private void OnIncidentList(object sender, EventArgs e)
        {
            OnForward(typeof(IncidentListViewController), true);
        }

        /// <summary>
        /// On incident map
        /// </summary>
        private void OnIncidentMap(object sender, EventArgs e)
        {
            OnForward(typeof(IncidentMapViewController), true);
        }

        /// <summary>
        /// On sync
        /// </summary>
        private void OnSync(object sender, EventArgs e)
        {
            OnForward(typeof(SyncViewController), true);
        }

        /// <summary>
        /// On settings
        /// </summary>
        private void OnSettings(object sender, EventArgs e)
        {
            OnForward(typeof(SettingsViewController), true);
        }

        /// <summary>
        /// On about
        /// </summary>
        private void OnWebsite(object sender, EventArgs e)
        {
            OnForward(typeof(WebsiteViewController), true);  
        }

        /// <summary>
        /// On exit
        /// </summary>
        private void OnExit(object sender, EventArgs e)
        {
            OnExit();
        }
    }
}
