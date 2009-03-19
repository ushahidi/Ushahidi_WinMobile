using System.Drawing;
using System.Windows.Forms;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Scroll list box item
    /// </summary>
    public class ScrollListBoxItem : Control
    {
        /// <summary>
        /// Is this item selected?
        /// </summary>
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                Refresh();
            }
        }private bool _IsSelected = false;

        /// <summary>
        /// Item index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Paint the background
        /// </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (Brush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }
    }
}
