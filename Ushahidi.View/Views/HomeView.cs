using System.Drawing;
using Ushahidi.View.Languages;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Home View
    /// </summary>
    partial class HomeView
    {
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Translate()
        {
            base.Translate();
            labelHomeDescription.Translate();
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