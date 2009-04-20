using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ushahidi.View.Views
{
    public partial class IncidentPhotoView
    {
        public override void Initialize()
        {
            base.Initialize();
            pictureBox.Click += pictureBox_Click;
            pictureBox.KeyDown += pictureBox_KeyDown;
            Menu = null;
        }

        public Image Image { get; set; }

        private void pictureBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back)
            {
                OnBack();
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            OnBack();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                
                if (Image.Width > Image.Height && Width < Height)
                {
                    //TODO implement drawing of photo
                }
                else
                {
                    
                }
            }
        }
    }
}
