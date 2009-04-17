using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ushahidi.Common.Logging;

namespace Ushahidi.Common.Controls
{
    public enum ThumbnailSizes
    {
        FullWidth = 1,
        HalfWidth = 2,
        ThirdWidth = 3,
        QuarterWidth = 4
    }

    public partial class ImageListBox : UserControl
    {
        public ImageListBox()
        {
            InitializeComponent();
        }
        public void AddImage(Image image)
        {
            if (image != null)
            {
                _Images.Add(image);
                Height = (int)Math.Floor(((Width / (int)ThumbnailSize) * Images.Count()) + 0.5);
            }
        }

        public IEnumerable<Image> Images
        {
            get { return _Images; }
            set
            {
                _Images.Clear();
                if (value != null)
                {
                    _Images.AddRange(value);
                    Height = (int)Math.Floor(((Width / (int)ThumbnailSize) * Images.Count()) + 0.5);
                }
                else
                {
                    Height = 0;
                }
                Invalidate();
            }
        }private readonly List<Image> _Images = new List<Image>();

        public ThumbnailSizes ThumbnailSize
        {
            get { return _ThumbnailSize; }
            set
            {
                _ThumbnailSize = value;
                Invalidate();
            }
        }private ThumbnailSizes _ThumbnailSize = ThumbnailSizes.FullWidth;

        public new event EventHandler DoubleClick
        {
            add { DoubleClick += value; }
            remove { DoubleClick -= value; }
        }

        public delegate void ImageSelectedHandler(object sender, ImageSelectedEventArgs args);

        public event ImageSelectedHandler ImageSelected;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            MouseDownLocation = new Point(e.X, e.Y);
            base.OnMouseDown(e);
        }private Point MouseDownLocation { get; set; }

        protected override void OnDoubleClick(EventArgs e)
        {
            Log.Info("PictureListBox.OnDoubleClick", "Location {0} {1}", MouseDownLocation.X, MouseDownLocation.Y);
            base.OnDoubleClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int posX = 0;
            int posY = 0;
            foreach(Image image in Images)
            {
                int thumbnailWidth = Width / (int)ThumbnailSize;
                Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);
                Rectangle destRect = new Rectangle(posX, posY, thumbnailWidth, thumbnailWidth);
                if (posX + thumbnailWidth >= Width)
                {
                    posX += 0;
                    posY += thumbnailWidth;
                }
                else
                {
                    posX += thumbnailWidth;
                }
                e.Graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
                    
            }
        }
    }

    public class ImageSelectedEventArgs : EventArgs
    {
        public ImageSelectedEventArgs(Image image)
        {
            Image = image;
        }
        public Image Image { get; private set; }
    }
}
