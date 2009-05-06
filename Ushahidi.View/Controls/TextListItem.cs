using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Extensions;

namespace Ushahidi.View.Controls
{
    public class TextListItem : ScrollListBoxItem<string>
    {
        public TextListItem(string label, string text) : this(label, text, false){}
        public TextListItem(string label, string text, bool bold) : base(1)
        {
            Label = label;
            base.Font = bold ? base.Font.ToBold() : base.Font;
            base.Text = string.IsNullOrEmpty(text) ? "" : text.Trim();
            Height = this.GetRequiredHeight(base.Font, ClientRectangle.Width - Padding * 2, base.Text) + Padding + Padding;
        }

        public string Label { get; private set; }
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = string.IsNullOrEmpty(value) ? "" : value.Trim();
                Height = this.GetRequiredHeight(base.Font, ClientRectangle.Width - Padding * 2, base.Text) + Padding + Padding;
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
            using (SolidBrush fontBrush = new SolidBrush(ForeColor))
            {
                Rectangle rectangle = new Rectangle(Padding, Padding, ClientRectangle.Width - Padding - Padding,
                                                    ClientRectangle.Height - Padding - Padding);
                e.Graphics.DrawString(Text, Font, fontBrush, rectangle, Alignment);
            }
        }
    }
}
