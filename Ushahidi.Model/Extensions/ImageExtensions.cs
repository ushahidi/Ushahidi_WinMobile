using System.Drawing;
using System.Drawing.Imaging;

namespace Ushahidi.Model.Extensions
{
    public static class ImageExtensions
    {
        public static Bitmap Rotate90Unsafe(this Bitmap originalBitmap)
        {
            Bitmap rotatedBitmap = new Bitmap(originalBitmap.Height, originalBitmap.Width);
            int newWidth = rotatedBitmap.Width;
            int originalWidth = originalBitmap.Width;
            int originalHeight = originalBitmap.Height;
            int newWidthMinusOne = newWidth - 1;

            BitmapData originalData = originalBitmap.LockBits(new Rectangle(0, 0, originalWidth, originalHeight), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            BitmapData rotatedData = rotatedBitmap.LockBits(new Rectangle(0, 0, rotatedBitmap.Width, rotatedBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
            unsafe
            {
                int* originalPointer = (int*)originalData.Scan0.ToPointer();
                int* rotatedPointer = (int*)rotatedData.Scan0.ToPointer();
                for (int y = 0; y < originalHeight; ++y)
                {
                    int destinationX = newWidthMinusOne - y;
                    for (int x = 0; x < originalWidth; ++x)
                    {
                        int sourcePosition = (x + y * originalWidth);
                        int destinationY = x;
                        int destinationPosition = (destinationX + destinationY * newWidth);
                        rotatedPointer[destinationPosition] = originalPointer[sourcePosition];
                    }
                }
                originalBitmap.UnlockBits(originalData);
                rotatedBitmap.UnlockBits(rotatedData);
            }
            return rotatedBitmap;
        }

        public static Bitmap Rotate90(this Bitmap originalBitmap)
        {
            Bitmap rotatedBitmap = new Bitmap(originalBitmap.Height, originalBitmap.Width);
            int rotatedWidthMinusOne = rotatedBitmap.Width - 1;
            int originalWidth = originalBitmap.Width;
            int originalHeight = originalBitmap.Height;
            for (int y = 0; y < originalHeight; ++y)
            {
                for (int x = 0; x < originalWidth; ++x)
                {
                    rotatedBitmap.SetPixel(rotatedWidthMinusOne - y, x, originalBitmap.GetPixel(x, y));
                }
            }
            return rotatedBitmap;
        }

    }
}
