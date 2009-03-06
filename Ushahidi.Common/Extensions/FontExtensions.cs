using System.Drawing;

namespace Ushahidi.Common.Extensions
{
    public static class FontExtensions
    {
        /// <summary>
        /// Font to BOLD
        /// </summary>
        public static Font ToBold(this Font font)
        {
            return new Font(font.Name, font.Size, FontStyle.Bold);
        }

        /// <summary>
        /// Font to BOLD, with size increase by the specified amount
        /// </summary>
        public static Font ToBold(this Font font, int sizeToIncrease)
        {
            return new Font(font.Name, font.Size + sizeToIncrease, FontStyle.Bold);
        }

        /// <summary>
        /// Font to REGULAR
        /// </summary>
        public static Font ToRegular(this Font font)
        {
            return new Font(font.Name, font.Size, FontStyle.Regular);
        }

        /// <summary>
        /// Font to Italic
        /// </summary>
        public static Font ToItalic(this Font font)
        {
            return new Font(font.Name, font.Size, FontStyle.Italic);
        }

        /// <summary>
        /// Increase the font size by the specified amount
        /// </summary>
        public static Font IncreaseSize(this Font font, int sizeToIncrease)
        {
            return new Font(font.Name, font.Size + sizeToIncrease, font.Style);
        }
    }
}
