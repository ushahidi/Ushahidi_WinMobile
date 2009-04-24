using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.View.Languages;

namespace Ushahidi.View.Views
{
    public partial class IncidentPhotoView
    {
        public override void Translate()
        {
            base.Translate();
            menuItemAction.Translate("Done");
        }
        public override void Initialize()
        {
            base.Initialize();
            //TopMost = true;
            //FormBorderStyle = FormBorderStyle.None;
            //MinimizeBox = false;
            //MaximizeBox = false;
            //ControlBox = false;
            //WindowState = FormWindowState.Maximized;
            Click += OnClick;
            DoubleClick += OnClick;
            KeyDown += OnKeyDown;
            menuItemAction.Click += OnClick;
        }

        public Image Image { get; set; }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back)
            {
                OnBack();
            }
        }

        private void OnClick(object sender, EventArgs e)
        {
            OnBack();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                int height = Width * Image.Height / Image.Width;
                int posY = Height > height ? (Height - height)/2 : 0;
                Rectangle destRect = new Rectangle(0, posY, Width, height);
                Rectangle srcRect = new Rectangle(0, 0, Image.Width, Image.Height);
                e.Graphics.DrawImage(Image, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }
    }
}
