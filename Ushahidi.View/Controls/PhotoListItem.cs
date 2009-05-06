using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;

namespace Ushahidi.View.Controls
{
    /// <summary>
    /// Photo List Item
    /// </summary>
    public class PhotoListItem : ScrollListBoxItem<Image>
    {
        public PhotoListItem(Image image) : this(image, 4) {}
        public PhotoListItem(Image image, int borderWidth) :base(1)
        {
            Image = image;
            BorderWidth = borderWidth;
            Height = ClientRectangle.Width * image.Height / image.Width;
        }

        /// <summary>
        /// Photo Image
        /// </summary>
        public Image Image { get; private set; }

        /// <summary>
        /// Border Width
        /// </summary>
        public int BorderWidth { get; private set; }

        /// <summary>
        /// Draw Image
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                int height = ClientRectangle.Width * Image.Height / Image.Width;
                Rectangle srcRect = new Rectangle(0, 0, Image.Width, Image.Height);
                //TODO define better way to know if item is selected
                Rectangle destRect = ForeColor == Color.White ? new Rectangle(BorderWidth, BorderWidth, 
                                                                ClientRectangle.Width - BorderWidth - BorderWidth, 
                                                                height - BorderWidth - BorderWidth) 
                                                : new Rectangle(0, 0, ClientRectangle.Width, height);
                e.Graphics.DrawImage(Image, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }
    }
}
