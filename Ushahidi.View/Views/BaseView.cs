using System;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.View.Controllers;
using Ushahidi.View.Languages;

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
            //Keyboard.KeyboardChanged += OnKeyboardChanged;
        }

        public override void Translate()
        {
            this.Translate(this);
            menuItemMenu.Translate(this);
            menuItemWebsite.Translate(this);
            menuItemAddIncident.Translate(this);
            menuItemExit.Translate(this);
            menuItemIncidentList.Translate(this);
            menuItemIncidentMap.Translate(this);
            menuItemSettings.Translate(this);
            menuItemSynchronize.Translate(this);
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
            OnExit();
        }

        private void OnMenuPopup(object sender, EventArgs e)
        {
            Type type = GetType();
            menuItemAddIncident.Enabled =  type != typeof(AddView);
            menuItemIncidentList.Enabled = type != typeof(ListView);
            menuItemIncidentMap.Enabled = type != typeof(MapView);
        }

    }
}
