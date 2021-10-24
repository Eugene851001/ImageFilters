using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Smoothing
{
    public static class BitmapExtension
    {
        public static int[,] GetPixels(this Bitmap source)
        {
            var result = new int[source.Height, source.Width];
            for (int i = 0; i < source.Height; i++)
            {
                for (int j = 0; j < source.Width; j++)
                {
                    result[i, j] = source.GetPixel(j, i).ToArgb();
                }
            }

            return result;
        }

        public static Bitmap SetPixels(this Bitmap source, int[,] pixels)
        {
            for (int i = 0; i < source.Height; i++)
            {
                for (int j = 0; j < source.Width; j++)
                {
                    source.SetPixel(j, i, Color.FromArgb(pixels[i, j]));
                }
            }

            return source;
        }
    }
}
