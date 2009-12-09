using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Ushahidi.Common.Extensions
{
    /// <summary>
    /// Image Extensions
    /// </summary>
    public static class ImageExtensions
    {
        public static bool Resize(this string sourcePath, string destinationPath, Size size)
        {
            if (File.Exists(sourcePath))
            {
                using (Image image = new Bitmap(sourcePath))
                {
                    using (Image resized = image.Resize(size))
                    {
                        resized.Save(destinationPath, ImageFormat.Jpeg);
                    }
                }
                return true;
            }
            return false;
        }

        public static Image Resize(this Image image, Size size)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image", "Image can not be null");
            }
            if (image.Width > size.Width || image.Height > size.Height)
            {
                Image resizedImage = new Bitmap(size.Width, size.Height);
                using (Graphics graphics = Graphics.FromImage(resizedImage))
                {
                    graphics.Clear(Color.White);

                    float widthRatio = (float)size.Width / image.Width;
                    float heightRatio = (float)size.Height / image.Height;

                    int width = size.Width;
                    int height = size.Height;

                    if (widthRatio > heightRatio)
                    {
                        width = (int)Math.Ceiling(size.Width * heightRatio);
                    }
                    else if (heightRatio > widthRatio)
                    {
                        height = (int)Math.Ceiling(size.Height * widthRatio);
                    }
                    graphics.DrawImage(
                      image,
                      new Rectangle(0, 0, width, height),
                      new Rectangle(0, 0, image.Width, image.Height),
                      GraphicsUnit.Pixel);
                }
                return resizedImage;
            }
            return image;
        }

    }
}
