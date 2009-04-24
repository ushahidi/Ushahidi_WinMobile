using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Extensions;

namespace Ushahidi.View.Controls
{
    public class TextListItem : ScrollListBoxItem
    {
        public TextListItem(string label, string text)
        {
            Label = label;
            base.Text = text;
            Height = this.GetRequiredHeight(base.Font, ClientRectangle.Width - Padding * 2, text) + Padding + Padding;
        }

        public string Label { get; private set; }
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                Height = this.GetRequiredHeight(base.Font, ClientRectangle.Width - Padding * 2, value) + Padding + Padding;
            }
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

        public bool Bold
        {
            get { return Font.Style == FontStyle.Bold; }
            set
            {
                Font = Font.ToBold();
                Invalidate();
            }
        }

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
        private StringFormat Alignment = new StringFormat { Alignment = StringAlignment.Near };

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush fontBrush = new SolidBrush(IsSelected ? Color.White : Color.Black))
            {
                Rectangle rectangle = new Rectangle(Padding, Padding, ClientRectangle.Width - Padding*2,
                                                    ClientRectangle.Height - Padding*2);
                e.Graphics.DrawString(Text, Font, fontBrush, rectangle, Alignment);
            }
        }
    }
}
