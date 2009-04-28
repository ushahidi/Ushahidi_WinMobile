using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Extensions;

namespace Ushahidi.View.Controls
{
    public class LocaleListItem : ScrollListBoxItem
    {
        public LocaleListItem(string locale, string latitude, string longitude)
        {
            Locale = locale;
            Latitude = latitude;
            Longitude = longitude;
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

        public string Locale { get; private set; }

        public string Latitude { get; private set; }

        public string Longitude { get; private set; }

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
                int width = (int)e.Graphics.MeasureString(Locale, Font).Width;
                Rectangle rectangle = new Rectangle(Padding, Padding, width, ClientRectangle.Height - Padding - Padding);
                e.Graphics.DrawString(Locale, Font, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.X = rectangle.Right + Padding;
                rectangle.Width = ClientRectangle.Width - width - Padding - Padding - Padding;
                e.Graphics.DrawString(string.Format("({0}, {1})", Latitude, Longitude), UnderlineFont, fontBrush, rectangle, Constants.LeftAligned);
            }
        }
    }
}
