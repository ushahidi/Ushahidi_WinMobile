using System.Drawing;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// About view
    /// </summary>
    public partial class AboutView
    {
        /// <summary>
        /// About text
        /// </summary>
        public string AboutText
        {
            get { return labelAbout.Text; }
            set { labelAbout.Text = value; }
        }

        /// <summary>
        /// About logo
        /// </summary>
        public Image AboutLogo
        {
            get { return pictureBoxLogo.Image; }
            set { pictureBoxLogo.Image = value; }
        }
    }
}
