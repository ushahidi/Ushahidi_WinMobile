using System;
using System.Drawing;
using Ushahidi.View.Controllers;
using Ushahidi.Model.Extensions;

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
            this.Translate("ushahidi");
            buttonListIncident.Translate("incidentList");
            buttonAddIncident.Translate("addIncident");
            buttonSynchronize.Translate("synchronize");
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

        private void OnResize(object sender, EventArgs e)
        {
            int padding = buttonListIncident.Left;
            buttonListIncident.Height = buttonAddIncident.Height = buttonSynchronize.Height =
                (ClientRectangle.Height - pictureBoxLogo.Height - pictureBoxLogo.Top - (padding*4)) / 3;
            buttonListIncident.Top = pictureBoxLogo.Bottom + padding;
            buttonAddIncident.Top = buttonListIncident.Bottom + padding;
            buttonSynchronize.Top = buttonAddIncident.Bottom + padding;
        }
    }
}