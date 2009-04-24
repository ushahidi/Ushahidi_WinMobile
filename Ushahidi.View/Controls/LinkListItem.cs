using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Extensions;

namespace Ushahidi.View.Controls
{
    public class LinkListItem : ScrollListBoxItem
    {
        public LinkListItem(string type, string link)
        {
            Type = type;
            Link = link;
            CalculateHeight(base.Font);
            BoldFont = base.Font.ToBold();
            UnderlineFont = base.Font.ToUnderline();
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                BoldFont = value.ToBold();
                UnderlineFont = value.ToUnderline();
                CalculateHeight(value);
            }
        }

        public string Type { get; private set; }

        public string Link { get; private set; }

        public Font BoldFont { get; private set; }

        public Font UnderlineFont { get; private set; }

        public int Padding = 4;

        private void CalculateHeight(Font font)
        {
            using (Graphics graphic = CreateGraphics())
            {
                Height = (int)(graphic.MeasureString("A", font).Height * 1.2) + Padding + Padding;
            }
        }
        /// <summary>
        /// Draw text onto the control
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush fontBrush = new SolidBrush(IsSelected ? Color.White : Color.Black))
            {
                int width = (int)e.Graphics.MeasureString(Type, Font).Width;
                Rectangle rectangle = new Rectangle(Padding, Padding, width, ClientRectangle.Height - Padding - Padding);
                e.Graphics.DrawString(Type, Font, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.X = rectangle.Right + Padding;
                rectangle.Width = ClientRectangle.Width - width - Padding - Padding - Padding;
                e.Graphics.DrawString(Link, UnderlineFont, fontBrush, rectangle, Constants.LeftAligned);
            }
            using (Pen pen = new Pen(Color.Black))
            {
                if (Index == 0)
                {
                    e.Graphics.DrawLine(pen, 0, 0, Width, 0);
                }
                e.Graphics.DrawLine(pen, 0, Height - 1, Width, Height - 1);
            }
        }
    }
}
