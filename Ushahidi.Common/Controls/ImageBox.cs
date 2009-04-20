using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ushahidi.Common.Controls
{
    public partial class ImageBox : UserControl
    {
        public ImageBox()
        {
            InitializeComponent();
        }

        public Image Image
        { 
            get { return _Image; }
            set
            {
                _Image = value;
                Invalidate();
            }
        }private Image _Image;

        public bool Selected
        {
            get { return _Selected; }
            set
            {
                _Selected = value;
                Invalidate();
            }
        }private bool _Selected = false;

        public new Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                _BackBrush = null;
            }
        }

        public Color BorderColor
        {
            get { return _BorderColor; }
            set
            {
                _BorderColor = value;
                _BorderPen = null;
                if (Selected) Invalidate();
            }
        }private Color _BorderColor = Color.Black;

        protected Brush BackBrush
        {
            get
            {
                if (_BackBrush == null)
                {
                    _BackBrush = new SolidBrush(BackColor);
                }
                return _BackBrush;
            }
        }private Brush _BackBrush;

        protected Pen BorderPen
        {
            get
            {
                if (_BorderPen == null)
                {
                    _BorderPen = new Pen(BorderColor);
                }
                return _BorderPen;
            }
        }private Pen _BorderPen;

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(BackBrush, 0, 0, Width, Height);
            if (Image != null)
            {
                Rectangle srcRect = new Rectangle(0, 0, Image.Width, Image.Height);
                Rectangle destRect;
                if (Image.Width > Image.Height)
                {
                    int thumbnailHeight = Image.Height * Width / Image.Width;
                    destRect = new Rectangle(0, (Height - thumbnailHeight) / 2, Width, thumbnailHeight);
                }
                else if (Image.Height > Image.Width)
                {
                    int thumbnailWidth = Image.Width * Height / Image.Height;
                    destRect = new Rectangle((Width - thumbnailWidth) / 2, 0, thumbnailWidth, Height);
                }
                else
                {
                    destRect = new Rectangle(0, 0, Width, Height);
                }
                e.Graphics.DrawImage(Image, destRect, srcRect, GraphicsUnit.Pixel);
            }
            if (Selected)
            {
                e.Graphics.DrawRectangle(BorderPen, 0, 0, Width - 1, Height - 1);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            Selected = true;
            Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Selected = false;
            Invalidate();
            base.OnLostFocus(e);
        }
    }
}
