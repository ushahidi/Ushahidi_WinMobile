using System.Drawing;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Home View
    /// </summary>
    partial class HomeView
    {
        /// <summary>
        /// The description
        /// </summary>
        public string Description
        {
            get { return labelDescription.Text; }
            set { labelDescription.Text = value; }
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