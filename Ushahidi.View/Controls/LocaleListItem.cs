using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Model.Models;

namespace Ushahidi.View.Controls
{
    /// <summary>
    /// Locale List Item
    /// </summary>
    public class LocaleListItem : ScrollListBoxItem<Locale>
    {
        /// <summary>
        /// Locale List Item
        /// </summary>
        /// <param name="locale">locale</param>
        public LocaleListItem(Locale locale) : base(1)
        {
            Item = locale;
        }

        /// <summary>
        /// Draw Text
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush fontBrush = new SolidBrush(ForeColor))
            {
                int width = (int)e.Graphics.MeasureString(Item.Name, Font).Width;
                Rectangle rectangle = new Rectangle(Padding, Padding, width, ClientRectangle.Height- Padding - Padding);
                e.Graphics.DrawString(Item.Name, Font, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.X = rectangle.Right + Padding + Padding;
                rectangle.Width = ClientRectangle.Width - width - Padding - Padding - Padding;
                e.Graphics.DrawString(string.Format("({0}, {1})", Item.Latitude, Item.Longitude), UnderlineFont, fontBrush, rectangle, Constants.LeftAligned);
            }
        }
    }
}
