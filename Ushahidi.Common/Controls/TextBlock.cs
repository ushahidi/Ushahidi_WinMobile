using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    public class TextBlock : Control
    {
        public TextBlock()
        {
            TabStop = false;
        }

        public override string Text
        {
            get { return base.Text;  }
            set
            {
                base.Text = value;
                if (AutoResize)
                {
                    Height = this.GetRequiredHeight(Font, ClientRectangle.Width-Padding*2, value) + Padding*2;
                }
                Invalidate();
            }
        }

        public int AdjustHeight()
        {
            Height = this.GetRequiredHeight(Font, ClientRectangle.Width - Padding * 2, Text) + Padding * 2;
            return Height;
        }

        public int Padding
        {
            get { return _Padding; }
            set
            {
                _Padding = value;
                Invalidate();
            }
        }private int _Padding = 4;

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        private new bool TabStop
        {
            get { return base.TabStop; }
            set { base.TabStop = value; }
        }

        public bool Bold
        {
            get { return Font.Style == FontStyle.Bold; }
            set
            {
                Font = Font.ToBold();
                Invalidate();
            }
        }

        public bool AutoResize
        {
            get { return _AutoResize; }
            set
            {
                _AutoResize = value;
                Invalidate();
            }
        }private bool _AutoResize = false;

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                Brush = new SolidBrush(value);
                Invalidate();
            }
        }private SolidBrush Brush = new SolidBrush(Color.Black);

        public ContentAlignment TextAlign
        {
            get { return _TextAlign; }
            set
            {
                _TextAlign = value;
                if (value == ContentAlignment.TopLeft)
                {
                    Alignment = new StringFormat { Alignment = StringAlignment.Near };
                }
                else if (value == ContentAlignment.TopCenter)
                {
                    Alignment = new StringFormat { Alignment = StringAlignment.Center };
                }
                else if (value == ContentAlignment.TopRight)
                {
                    Alignment = new StringFormat { Alignment = StringAlignment.Far };
                }
                Invalidate();
            }
        }private ContentAlignment _TextAlign = ContentAlignment.TopRight;
        private StringFormat Alignment = new StringFormat { Alignment = StringAlignment.Near};

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(Padding, Padding, ClientRectangle.Width - Padding * 2, ClientRectangle.Height - Padding * 2);
            e.Graphics.DrawString(Text, Font, Brush, rectangle, Alignment);
        }
    }
}
