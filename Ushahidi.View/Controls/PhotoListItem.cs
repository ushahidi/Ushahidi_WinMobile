using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;

namespace Ushahidi.View.Controls
{
    public class PhotoListItem : ScrollListBoxItem
    {
        public PhotoListItem(Image image)
        {
            Image = image;
            Height = ClientRectangle.Width * image.Height / image.Width;
        }

        public Image Image { get; private set; }

        public int BorderWidth
        {
            get { return _BorderWidth; }
            set
            {
                _BorderWidth = value > -1 ? value : 0;
                Invalidate();
            }
        }private int _BorderWidth = 4;

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                int height = ClientRectangle.Width * Image.Height / Image.Width;
                Rectangle srcRect = new Rectangle(0, 0, Image.Width, Image.Height);
                Rectangle destRect = IsSelected ? new Rectangle(BorderWidth, BorderWidth, ClientRectangle.Width - BorderWidth - BorderWidth, height - BorderWidth - BorderWidth) 
                                                : new Rectangle(0, 0, ClientRectangle.Width, height);
                e.Graphics.DrawImage(Image, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }
    }
}
