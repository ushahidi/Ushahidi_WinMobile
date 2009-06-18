using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Model.Extensions;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Incident Photo View
    /// </summary>
    public partial class PhotoView : BaseView
    {
        public PhotoView()
        {
            InitializeComponent();    
        }

        public override void Initialize()
        {
            base.Initialize();
            WindowState = FormWindowState.Maximized;
            Menu = null;
            menuItemMenu.Enabled = false;
        }

        public Bitmap Image
        {
            get { return _Image; }
            set
            {
                if (value != null)
                {
                    _Image = Height > Width && value.Width > value.Height
                        ? value.Rotate90Unsafe() : value;
                }
                else
                {
                    _Image = null;
                } 
            }
        }private Bitmap _Image;

        private void OnLoad(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back || e.KeyCode == Keys.Return)
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
            base.OnPaint(e);
            if (Image != null)
            {
                int height = Width * Image.Height / Image.Width;
                int width = Height * Image.Width / Image.Height;
                int posY = Height > height ? (Height - height) / 2 : 0;
                int posX = Width > width ? (Width - width) / 2 : 0;
                Rectangle srcRect = new Rectangle(0, 0, Image.Width, Image.Height);
                Rectangle destRect = new Rectangle(posX, posY, width, height);
                e.Graphics.DrawImage(Image, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }
    }
}
