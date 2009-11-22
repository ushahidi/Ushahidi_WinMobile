using System;
using System.Drawing;
using Ushahidi.View.Controllers;
using Ushahidi.Model.Extensions;
using Ushahidi.View.Controls;

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

        public override void Initialize()
        {
            base.Initialize();
            panelContent.BackColor = Colors.Background;
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("ushahidi");
            buttonIncidentList.Translate("incidentList");
            buttonAddIncident.Translate("addIncident");
            buttonSynchronize.Translate("synchronize");
        }

        public override void Render()
        {
            base.Render();
            buttonIncidentList.Focus();
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
            int padding = buttonIncidentList.Left;
            int height = (ClientRectangle.Height - pictureBoxLogo.Height - pictureBoxLogo.Top - (padding * 4)) / 3;
            buttonIncidentList.Height = buttonAddIncident.Height = buttonSynchronize.Height = height > 28 ? height : 28;
            buttonIncidentList.Top = pictureBoxLogo.Bottom + padding;
            buttonAddIncident.Top = buttonIncidentList.Bottom + padding;
            buttonSynchronize.Top = buttonAddIncident.Bottom + padding;
        }
    }
}