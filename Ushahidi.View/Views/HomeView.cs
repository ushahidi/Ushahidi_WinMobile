using System;
using System.Drawing;
using Ushahidi.View.Controllers;
using Ushahidi.View.Languages;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Home View
    /// </summary>
    public partial class HomeView : BaseView
    {
        public HomeView()
        {
            InitializeComponent();
        }

        public override void Translate()
        {
            base.Translate();
            buttonListIncident.Translate("menuItemIncidentList");
            buttonMapIncident.Translate("menuItemIncidentDetailsViewMap");
            buttonAddIncident.Translate("menuItemAddIncident");
            buttonSynchronize.Translate("menuItemSynchronize");
        }

        /// <summary>
        /// The logo
        /// </summary>
        public Image Logo
        {
            get { return pictureBoxLogo.Image; }
            set { pictureBoxLogo.Image = value; }
        }

        private void OnListIncident(object sender, EventArgs e)
        {
            OnForward<ListViewController>(true);
        }

        private void OnMapIncident(object sender, EventArgs e)
        {
            OnForward<MapViewController>(true);
        }

        private void OnAddIncident(object sender, EventArgs e)
        {
            OnForward<AddViewController>(true);
        }

        private void OnSynchronize(object sender, EventArgs e)
        {
            OnForward<SyncViewController>(true);
        }
    }
}