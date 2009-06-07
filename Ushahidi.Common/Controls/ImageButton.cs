using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Image Button
    /// </summary>
    public partial class ImageButton : UserControl
    {
        /// <summary>
        /// Image Button
        /// </summary>
        public ImageButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Enabled
        /// </summary>
        public new bool Enabled
        {
            get { return base.Enabled; }
            set 
            { 
                base.Enabled = value;
                TabStop = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Pressed
        /// </summary>
        public bool Pressed
        {
            get { return _Pressed; }
            set
            {
                _Pressed = value;
                Invalidate();
            }
        }private bool _Pressed = false;

        /// <summary>
        /// This makes it behave not like a switch
        /// </summary>
        public bool Momentary { get; set; }

        /// <summary>
        /// Button Image
        /// </summary>
        public Image Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                Invalidate();
            }
        }private Image _Image;

        public Color BackColorSelected
        {
            get { return _BackColorSelected; }
            set { _BackColorSelected = value; }
        }private Color _BackColorSelected = Color.White;

        /// <summary>
        /// Disabled Image
        /// </summary>
        public Image DisabledImage
        {
            get { return _DisabledImage; }
            set
            {
                _DisabledImage = value;
                Invalidate();
            }
        }private Image _DisabledImage;

        /// <summary>
        /// Image Rectangle
        /// </summary>
        protected Rectangle ImageRectangle
        {
            get
            {
                if (_ImageRectangle == Rectangle.Empty && Image != null)
                {
                    _ImageRectangle = Image != null ? new Rectangle(0, 0, Image.Width, Image.Height) : Rectangle.Empty;
                }
                return _ImageRectangle;
            }
        }private Rectangle _ImageRectangle = Rectangle.Empty;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Up)
            {
                Parent.SelectNextControl(this, false, true, true, true);
                Invalidate();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                Parent.SelectNextControl(this, true, true, true, true);
                Invalidate();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Pressed = true;
                Invalidate();
                Pressed = false;
                OnClick(e);
            }
            base.OnKeyDown(e);
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(System.EventArgs e)
        {
            Invalidate();
            base.OnLostFocus(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (Image == null)
            {
                e.Graphics.FillRectangle(new SolidBrush(Pressed ? BackColorSelected : BackColor), ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Enabled)
            {
                if (Image != null)
                {
                    Rectangle rectangle = Pressed ? new Rectangle(1, 1, ClientRectangle.Width - 1, ClientRectangle.Height - 1) : ClientRectangle;
                    e.Graphics.DrawImage(Image, rectangle, ImageRectangle, GraphicsUnit.Pixel);
                }
                if (Focused || Image == null && Pressed)
                {
                    using (Pen pen = new Pen(Color.Black))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                    }
                }
            }
            else
            {
                if (DisabledImage != null)
                {
                    e.Graphics.DrawImage(DisabledImage, ClientRectangle, ImageRectangle, GraphicsUnit.Pixel);
                }
            }
            if (string.IsNullOrEmpty(Text) == false)
            {
                e.Graphics.DrawString(Text, Pressed || Focused ? Font.ToBold() : Font, new SolidBrush(ForeColor), ClientRectangle, CenterAligned);
            }
        }

        private static readonly StringFormat CenterAligned = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
            FormatFlags = StringFormatFlags.NoWrap
        };

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Pressed = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (Momentary == false)
            {
                Pressed = false;
                Invalidate();
            }
            base.OnMouseUp(e);
        }
    }
}
