using System.Drawing;
using System.Windows.Forms;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Centered picture box
    /// </summary>
    public partial class CenteredPictureBox : UserControl
    {
        public CenteredPictureBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Picture box image
        /// </summary>
        public Image Image
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = (value != null) ? ScaleBitmap(value) : null; }
        }

        /// <summary>
        /// Scale image
        /// </summary>
        /// <param name="srcImage">source image</param>
        /// <returns></returns>
        private Bitmap ScaleBitmap(Image srcImage)
        {
            Bitmap destImage = new Bitmap(Width, Height);
            Rectangle srcRect = new Rectangle();
            Rectangle destRect = new Rectangle{Width = destImage.Width, Height = destImage.Height};
            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                using (Brush brush = new SolidBrush(BackColor))
                {
                    graphics.FillRectangle(brush, destRect);
                }
                srcRect.Width = srcImage.Width;
                srcRect.Height = srcImage.Height;
                float sourceAspect = srcImage.Width/(float) srcImage.Height;
                float destAspect = destImage.Width/(float) destImage.Height;
                if (sourceAspect > destAspect)
                {
                    destRect.Width = destImage.Width;
                    destRect.Height = (int) (destImage.Width/sourceAspect);
                    destRect.X = 0;
                    destRect.Y = (destImage.Height - destRect.Height)/2;
                }
                else
                {
                    destRect.Height = destImage.Height;
                    destRect.Width = (int) (destImage.Height*sourceAspect);
                    destRect.X = (destImage.Width - destRect.Width)/2;
                    destRect.Y = 0;
                }
                graphics.DrawImage(srcImage, destRect, srcRect, GraphicsUnit.Pixel);
            }
            return destImage;
        }
    }
}
