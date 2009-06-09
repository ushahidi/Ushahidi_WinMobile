using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    public partial class LabelImages : UserControl
    {
        public LabelImages()
        {
            InitializeComponent();
            label.Font = label.Font.ToBold();
        }

        /// <summary>
        /// Label
        /// </summary>
        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        /// <summary>
        /// Get or set the background color
        /// </summary>
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = label.BackColor = panel.BackColor = value; }
        }

        /// <summary>
        /// Font
        /// </summary>
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                label.Font = value.ToBold();
            }
        }

        /// <summary>
        /// Images
        /// </summary>
        public Image [] Images
        {
            get { return _Images; }
            set
            {
                _Images = value;
                panel.Invalidate();
            }
        }private Image[] _Images;

        /// <summary>
        /// Number of images per row
        /// </summary>
        public int ImagesPerRow
        {
            get { return _ImagesPerRow; }
            set { _ImagesPerRow = value;}
        }private int _ImagesPerRow = 3;

        /// <summary>
        /// On paint, draw out images
        /// </summary>
        private void OnPanelPaint(object sender, PaintEventArgs e)
        {
            if (Images == null) return;
            int x = 0, y = 0;
            int width = panel.Width / ImagesPerRow;
            int height = panel.Width / ImagesPerRow;
            foreach(Image image in Images)
            {
                Rectangle destRect = new Rectangle(x, y, width, height);
                Rectangle srcRect = new Rectangle(0, 0, image.Width, image.Height);
                e.Graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
                if (x + width < panel.Width)
                {
                    x += width;
                }
                else
                {
                    x = 0;
                    y += height;
                }
            }
        }
    }
}
