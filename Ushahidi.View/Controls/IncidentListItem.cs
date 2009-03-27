using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Extensions;
using Ushahidi.Model.Models;

namespace Ushahidi.View.Controls
{
    /// <summary>
    /// Incident list item
    /// </summary>
    public class IncidentListItem : ScrollListBoxItem
    {
        public IncidentListItem(Incident incident)
        {
            Incident = incident;
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

        protected Incident Incident { get; private set; }

        public Font BoldFont { get; set; }

        private void CalculateHeight(Font font)
        {
            using (Graphics graphic = CreateGraphics())
            {
                Height = (int)(graphic.MeasureString("A", font).Height * 1.2) * RowCount;
            }
        }

        public readonly int RowCount = 4;

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
                e.Graphics.DrawString(Incident.Title, BoldFont, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, rowHeight);
                e.Graphics.DrawString(Incident.Description, BoldFont, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, rowHeight);
                e.Graphics.DrawString(Incident.LocationName, Font, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, rowHeight);
                e.Graphics.DrawString(Incident.CategoryTitle, Font.ToBold(), fontBrush, rectangle, Constants.LeftAligned);
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
