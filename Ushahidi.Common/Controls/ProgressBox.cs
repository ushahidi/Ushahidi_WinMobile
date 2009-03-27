using System.Drawing;
using System.Windows.Forms;

namespace Ushahidi.Common.Controls
{
    public partial class ProgressBox : UserControl
    {
        public ProgressBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get or set the background color
        /// </summary>
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        /// Progress Value
        /// </summary>
        public int Value
        {
            get { return progressBar.Value; }
            set { progressBar.Value = value;}
        }

        /// <summary>
        /// Progress Minimum
        /// </summary>
        public int Minimum
        {
            get { return progressBar.Minimum; }
            set { progressBar.Minimum = value; }
        }

        /// <summary>
        /// Progress Maximum
        /// </summary>
        public int Maximum
        {
            get { return progressBar.Maximum; }
            set { progressBar.Maximum = value; }
        }

        /// <summary>
        /// Text
        /// </summary>
        public new string Text
        {
            get { return labelProgress.Text; }
            set { labelProgress.Text = value; }
        }
    }
}
