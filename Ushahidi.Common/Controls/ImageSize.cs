using System.Drawing;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Image Size
    /// </summary>
    public class ImageSize
    {
        public ImageSize(int width, int height)
        {
            Width = width;
            Height = height;
            Name = string.Format("{0} x {1}", Width, Height);
        }

        public ImageSize(Size size)
        {
            Width = size.Width;
            Height = size.Height;
            Name = string.Format("{0} x {1}", Width, Height);
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public string Name { get; private set; } 

        public bool Equals(int width, int height)
        {
            return Width == width && Height == height;
        }

        public Size ToSize()
        {
            return new Size(Width, Height);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
