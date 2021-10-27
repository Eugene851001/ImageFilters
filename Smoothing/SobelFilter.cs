using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Smoothing
{
    public class SobelFilter : MatrixFilter
    {
        private static int[,] sobelKernelY =
            {
                { -1, -2, -1},
                {0, 0, 0 },
                { 1, 2, 1}
            };

        private static int[,] sobelKernelX =
            {
                {-1, 0, 1 },
                { -2, 0, 2},
                { -1, 0, 1}
            };

        protected override int ProcessPixel(int[,] source, int x, int y, int m)
        {
            int gxRed = 0;
            int gyRed = 0;

            int gxGreen = 0;
            int gyGreen = 0;

            int gxBlue = 0;
            int gyBlue = 0;

            int k = 2 * m + 1;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Color temp = Color.FromArgb(source[y + i - m, x + j - m]);

                    gxRed += sobelKernelX[i, j] * temp.R;
                    gyRed += sobelKernelY[i, j] * temp.R;

                    gxGreen += sobelKernelX[i, j] * temp.G;
                    gyGreen += sobelKernelY[i, j] * temp.G;

                    gxBlue += sobelKernelX[i, j] * temp.B;
                    gyBlue += sobelKernelY[i, j] * temp.B;
                }
            }

            int red = Math.Min((int)GetDistance(gxRed, gyRed), 255);
            int green = Math.Min((int)GetDistance(gxGreen, gyGreen), 255);
            int blue = Math.Min((int)GetDistance(gxBlue, gyBlue), 255);

            return Color.FromArgb(red, green, blue).ToArgb();
        }

        private static double GetDistance(int x, int y) => Math.Sqrt(x * x + y * y);
    }
}
