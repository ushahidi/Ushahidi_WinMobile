using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Extensions;

namespace Ushahidi.View.Controls
{
    /// <summary>
    /// Incident list item
    /// </summary>
    public class IncidentListItem : ScrollListBoxItem
    {
        public IncidentListItem() : this (null, null, DateTime.MinValue, false) { }
        public IncidentListItem(string title, string locale, DateTime date, bool verified)
        {
            Title = title;
            Locale = locale;
            Date = date;
            Verified = verified;
            CalculateHeight(Font);
            BoldFont = Font.ToBold();
        }

        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                BoldFont = value.ToBold();
                CalculateHeight(value);
            }
        }

        public Font BoldFont { get; set; }

        private void CalculateHeight(Font font)
        {
            using (Graphics graphic = CreateGraphics())
            {
                Height = (int)(graphic.MeasureString("A", font).Height * 1.2) * RowCount;
            }
        }

        public readonly int RowCount = 4;

        public string Title { get; set; }

        public string Locale { get; set; }

        public DateTime Date { get; set; }

        public bool Verified { get; set; }

        public Image Image { get; set; }

        /// <summary>
        /// Draw text onto the control
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush fontBrush = new SolidBrush(IsSelected ? Color.White : Color.Black))
            {
                int rowHeight = Height/RowCount;
                if (Image != null)
                {
                    Rectangle destRect = new Rectangle(0, 0, Height, Height);
                    Rectangle srcRect = new Rectangle(0, 0, Image.Width, Image.Height);
                    e.Graphics.DrawImage(Image, destRect, srcRect, GraphicsUnit.Pixel);
                }
                Rectangle rectangle = new Rectangle(Height + 5, 0, Width - Height - 5, rowHeight);
                e.Graphics.DrawString(Title, BoldFont, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, rowHeight);
                e.Graphics.DrawString(Locale, BoldFont, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, rowHeight);
                string incidentDate = String.Format("Date: {0:dd.MM.yy}", Date);
                e.Graphics.DrawString(incidentDate, Font, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, rowHeight);
                string isVerified = Verified ? "VERIFIED" : "NOT VERIFIED";
                e.Graphics.DrawString(isVerified, Font.ToBold(), fontBrush, rectangle, Constants.LeftAligned);
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
