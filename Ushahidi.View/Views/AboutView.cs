using System.Drawing;
using Ushahidi.Common;
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
            textBlockDescription.Translate("ushahidiDescription");
            textBlockDescription.AdjustHeight();
        }

        public override void Render()
        {
            base.Render();
        }

        /// <summary>
        /// The logo
        /// </summary>
        public Image Logo
        {
            get { return pictureBoxLogo.Image; }
            set { pictureBoxLogo.Image = value; }
        }
    }
}