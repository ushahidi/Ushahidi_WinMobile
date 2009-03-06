using System.Drawing;

namespace Ushahidi.Common.Controls
{
    public static class Constants
    {
        /// <summary>
        /// Text center aligned
        /// </summary>
        public static readonly StringFormat CenterAligned = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center,
            FormatFlags = StringFormatFlags.NoWrap
        };

        /// <summary>
        /// Left aligned
        /// </summary>
        public static readonly StringFormat LeftAligned = new StringFormat
        {
            FormatFlags = StringFormatFlags.NoWrap,
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        };

        /// <summary>
        /// Right aligned
        /// </summary>
        public static readonly StringFormat RightAligned = new StringFormat
        {
            FormatFlags = StringFormatFlags.NoWrap,
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Center
        };
    }
}
