using System;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.View.Controllers;
using Ushahidi.Model.Extensions;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Base view
    /// </summary>
    public partial class BaseView : Common.MVC.View
    {
        public BaseView()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            base.Initialize();
            MinimizeBox = false;
        }

        public override void Translate()
        {
            menuItemMenu.Translate("menu");
            menuItemWebsite.Translate("website");
            menuItemAddIncident.Translate("addIncident");
            menuItemExit.Translate("exit");
            menuItemIncidentList.Translate("incidentList");
            menuItemAbout.Translate("about");
            menuItemSettings.Translate("settings");
            menuItemSynchronize.Translate("synchronize");
        }

        public override void Render()
        {
            base.Render();
            BackColor = Colors.Background;
        }

        /// <summary>
        /// On add incident
        /// </summary>
        private void OnAddIncident(object sender, EventArgs e)
        {
            OnForward<AddViewController>(true);
        }

        /// <summary>
        /// On incident list
        /// </summary>
        private void OnIncidentList(object sender, EventArgs e)
        {
            OnForward<ListViewController>(true);
        }

        /// <summary>
        /// On incident map
        /// </summary>
        private void OnIncidentMap(object sender, EventArgs e)
        {
            OnForward<MapViewController>(true);
        }

        /// <summary>
        /// On sync
        /// </summary>
        private void OnSync(object sender, EventArgs e)
        {
            OnForward<SyncViewController>(true);
        }

        private void OnAbout(object sender, EventArgs e)
        {
            OnForward<AboutViewController>(true);
        }

        /// <summary>
        /// On settings
        /// </summary>
        private void OnSettings(object sender, EventArgs e)
        {
            OnForward<SettingsViewController>(true);
        }

        /// <summary>
        /// On about
        /// </summary>
        private void OnWebsite(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(true, DataManager.ServerAddress, "WebsiteView".Translate());  
        }

        /// <summary>
        /// On exit
        /// </summary>
        private void OnExit(object sender, EventArgs e)
        {
            if (Dialog.Question("exit".Translate(), "exitApplication".Translate()))
            {
                OnExit();
            }
        }

        private void OnMenuPopup(object sender, EventArgs e)
        {
            Type type = GetType();
            menuItemAddIncident.Enabled = type != typeof (AddView);
            menuItemIncidentList.Enabled = type != typeof (ListView);
            menuItemSettings.Enabled = type != typeof (SettingsView);
            menuItemSynchronize.Enabled = type != typeof (SyncView);
            menuItemAbout.Enabled = type != typeof (AboutView);
            menuItemWebsite.Enabled = type != typeof (WebsiteView);
        }

    }
}
