using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;

namespace Ushahidi.View.Controls
{
    /// <summary>
    /// Link List Item
    /// </summary>
    public class LinkListItem : ScrollListBoxItem<string>
    {
        /// <summary>
        /// Link List Item
        /// </summary>
        /// <param name="type">link type</param>
        /// <param name="link">link url</param>
        public LinkListItem(string type, string link) : base(1)
        {
            Type = type;
            Link = link;
        }

        /// <summary>
        /// Link Type
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Link URL
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// Draw text onto the control
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush fontBrush = new SolidBrush(ForeColor))
            {
                int width = (int)e.Graphics.MeasureString(Type, Font).Width;
                Rectangle rectangle = new Rectangle(Padding, Padding, width, ClientRectangle.Height - Padding - Padding);
                e.Graphics.DrawString(Type, Font, fontBrush, rectangle, Constants.LeftAligned);

                rectangle.X = rectangle.Right + Padding;
                rectangle.Width = ClientRectangle.Width - width - Padding - Padding - Padding;
                e.Graphics.DrawString(Link, UnderlineFont, fontBrush, rectangle, Constants.LeftAligned);
            }
        }
    }
}
