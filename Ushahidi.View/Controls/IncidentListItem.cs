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
            CalculateHeight(base.Font);
            BoldFont = base.Font.ToBold();
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

        public Incident Incident { get; private set; }

        public Font BoldFont { get; set; }

        private void CalculateHeight(Font font)
        {
            using (Graphics graphic = CreateGraphics())
            {
                Height = (int)(graphic.MeasureString("A", font).Height * 1.2) * RowCount;
            }
        }public readonly int RowCount = 4;

        /// <summary>
        /// Draw text onto the control
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush fontBrush = new SolidBrush(IsSelected ? Color.White : Color.Black))
            {
                int rowHeight = Height/RowCount;
                Rectangle destRect = Rectangle.Empty;
                if (Incident.Thumbnail != null)
                {
                    if (Incident.Thumbnail.Width > Incident.Thumbnail.Height)
                    {
                        int width = Height;
                        int height = Height * Incident.Thumbnail.Height / Incident.Thumbnail.Width;
                        const int posX = 0;
                        int posY = Height > height ? (Height - height) / 2 : 0;
                        destRect = new Rectangle(posX, posY, width, height);
                    }
                    else
                    {
                        int width = Height * Incident.Thumbnail.Width / Incident.Thumbnail.Height;
                        int height = Height;
                        int posX = Height > width ? (Height - width) / 2 : 0;
                        const int posY = 0;
                        destRect = new Rectangle(posX, posY, width, height);
                    }
                    Rectangle srcRect = new Rectangle(0, 0, Incident.Thumbnail.Width, Incident.Thumbnail.Height);
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, Height, Height);
                    e.Graphics.DrawImage(Incident.Thumbnail, destRect, srcRect, GraphicsUnit.Pixel);
                }
                Rectangle rectangle = new Rectangle(destRect.Right + 5, 0, Width - destRect.Right - 5, rowHeight);
                e.Graphics.DrawString(Incident.Title, BoldFont, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, rowHeight);
                e.Graphics.DrawString(Incident.Description, Font, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, rowHeight);
                e.Graphics.DrawString(Incident.LocaleAndDate, Font, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, rowHeight);
                e.Graphics.DrawString(Incident.CategoryTitle, Font, fontBrush, rectangle, Constants.LeftAligned);
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
