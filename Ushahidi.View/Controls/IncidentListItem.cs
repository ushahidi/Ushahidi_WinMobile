using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Model.Models;

namespace Ushahidi.View.Controls
{
    /// <summary>
    /// Incident List Item
    /// </summary>
    public class IncidentListItem : ScrollListBoxItem<Incident>
    {
        /// <summary>
        /// Incident List Item
        /// </summary>
        /// <param name="incident">incident</param>
        public IncidentListItem(Incident incident) : base(4)
        {
            Item = incident;
        }

        /// <summary>
        /// Render Incident Information
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush fontBrush = new SolidBrush(ForeColor))
            {
                Rectangle destRect = Rectangle.Empty;
                if (Item.Thumbnail != null)
                {
                    if (Item.Thumbnail.Width > Item.Thumbnail.Height)
                    {
                        int width = Height;
                        int height = Height * Item.Thumbnail.Height / Item.Thumbnail.Width;
                        const int posX = 0;
                        int posY = Height > height ? (Height - height) / 2 : 0;
                        destRect = new Rectangle(posX, posY, width, height);
                    }
                    else
                    {
                        int width = Height * Item.Thumbnail.Width / Item.Thumbnail.Height;
                        int height = Height;
                        int posX = Height > width ? (Height - width) / 2 : 0;
                        const int posY = 0;
                        destRect = new Rectangle(posX, posY, width, height);
                    }
                    Rectangle srcRect = new Rectangle(0, 0, Item.Thumbnail.Width, Item.Thumbnail.Height);
                    e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, Height, Height);
                    e.Graphics.DrawImage(Item.Thumbnail, destRect, srcRect, GraphicsUnit.Pixel);
                    destRect = new Rectangle(0, 0, Height, Height);
                }
                Rectangle rectangle = new Rectangle(destRect.Right + Padding, 0, ClientRectangle.Width - destRect.Right - Padding - Padding, RowHeight);
                e.Graphics.DrawString(Item.Title, BoldFont, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, RowHeight);
                e.Graphics.DrawString(Item.Description, Font, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, RowHeight);
                e.Graphics.DrawString(Item.LocaleAndDate, Font, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.Offset(0, RowHeight);
                e.Graphics.DrawString(Item.CategoryTitle, Font, fontBrush, rectangle, Constants.LeftAligned);
            }
        }
    }
}
