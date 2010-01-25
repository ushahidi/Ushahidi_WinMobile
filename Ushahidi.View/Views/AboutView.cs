using System;
using System.Drawing;
using Ushahidi.Model.Extensions;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// About View
    /// </summary>
    public partial class AboutView : BaseView
    {
        public AboutView()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            base.Initialize();
            textBlockDescription.BackColor = Colors.Background;
            BackColor = Colors.Background;
        }
        
        public override void Translate()
        {
            base.Translate();
            this.Translate("about");
            menuItemAction.Translate("back");
            textBlockDescription.Translate("ushahidiDescription");
            textBlockDescription.AdjustHeight();
        }

        /// <summary>
        /// The logo
        /// </summary>
        public Image Logo
        {
            get { return pictureBoxLogo.Image; }
            set { pictureBoxLogo.Image = value; }
        }

        private void OnMenuBack(object sender, EventArgs e)
        {
            OnBack();
        }
    }
}