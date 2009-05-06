using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Scroll List Box Item
    /// </summary>
    public abstract class ScrollListBoxItem<T> : Control
    {
        /// <summary>
        /// Scroll List Box Item
        /// </summary>
        /// <param name="rowCount">row count</param>
        protected ScrollListBoxItem(int rowCount)
        {
            RowCount = rowCount;
            CalculateHeight(base.Font);
            BoldFont = base.Font.ToBold();
            UnderlineFont = base.Font.ToUnderline();
        }

        /// <summary>
        /// Bold Font
        /// </summary>
        public Font BoldFont { get; private set; }

        /// <summary>
        /// Underline Font
        /// </summary>
        public Font UnderlineFont { get; private set; }

        /// <summary>
        /// Font
        /// </summary>
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

        /// <summary>
        /// Calculate Height
        /// </summary>
        /// <param name="font">font</param>
        protected void CalculateHeight(Font font)
        {
            using (Graphics graphic = CreateGraphics())
            {
                Height = (int)(graphic.MeasureString("A", font).Height + Padding + Padding) * RowCount;
            }
        }

        /// <summary>
        /// Row Count
        /// </summary>
        public int RowCount
        {
            get { return _RowCount; }
            protected set { _RowCount = value > 0 ? value : 1; }
        }private int _RowCount = 1;

        /// <summary>
        /// Row Height
        /// </summary>
        public int RowHeight
        {
            get { return Height / RowCount; }
        }

        /// <summary>
        /// List Item
        /// </summary>
        public T Item { get; protected set; }

        /// <summary>
        /// Left Aligned
        /// </summary>
        protected static readonly StringFormat LeftAligned = new StringFormat
        {
            FormatFlags = StringFormatFlags.NoWrap,
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        /// <summary>
        /// Right Aligned
        /// </summary>
        protected static readonly StringFormat RightAligned = new StringFormat
        {
            FormatFlags = StringFormatFlags.NoWrap,
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Center
        };

        /// <summary>
        /// Padding
        /// </summary>
        protected readonly int Padding = 2;

        /// <summary>
        /// Line Pen
        /// </summary>
        protected static readonly Pen LinePen = new Pen(Color.DarkGray, 1);

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
