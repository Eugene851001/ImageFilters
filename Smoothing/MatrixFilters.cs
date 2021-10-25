using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using RendererConsole;

namespace Smoothing
{
    class MatrixFilters
    {

        private static double[,] gaussKernel = 
            { 
                //{ 0.01, 0.08, 0.01},
                //{ 0.08, 0.64, 0.01},
                //{ 0.01, 0.08, 0.01}
                { 1, 1, 1},
                { 1, 2, 1},
                { 1, 1, 1}
            };

        private static Dictionary<int, double[,]> gaussKernels = new Dictionary<int, double[,]>();

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

        public static int[,] FilterAverage(int[,] source, int windowSize) =>
            HelpFilter(source, windowSize, GetAverageColor);

        public static int[,] FilterMiddle(int[,] source, int windowSize) =>
            HelpFilter(source, windowSize, GetMiddle);

        public static int[,] FilterGauss(int[,] source, int windowSize) =>
            HelpFilter(source, windowSize, GetGaussColor);

        public static int[,] FilterSobel(int[,] source, int windowSize) =>
            HelpFilter(source, windowSize, GetSobelColor);

        private static int[,] HelpFilter(int[,] source, int windowSize, Func<int[,], int, int, int, int> processPixel)
        {
            if (windowSize % 2 == 0)
            {
                throw new ArgumentException("Window size can be only even(or odd)");    
            }

            var result = new int[source.GetUpperBound(0) + 1, source.GetUpperBound(1) + 1];
            for (int i = 0; i <= source.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= source.GetUpperBound(1); j++)
                {
                    result[i, j] = source[i, j];
                }
            }

            int m = (windowSize - 1) / 2;
            for (int i = m; i <= source.GetUpperBound(0) - m; i++)
            {
                for (int j = m; j <= source.GetUpperBound(1) - m; j++)
                {
                    result[i, j] = processPixel(source, j, i, m);
                }
            }
            
            return result;
        }

        private static int GetAverage(int[,] source, int x, int y, int m)
        {
            int result = 0; 
            for (int i = y - m; i <= y + m; i++)
            {
                for (int j = x - m; j <= x + m; j++)
                {
                    result += source[i, j];
                }
            }

            int k = (2 * m + 1);
            return result / (k * k);
        }

        private static int GetMiddle(int[,] source, int x, int y, int m)
        {
            int k = 2 * m + 1;
            var sequence = new int[k * k];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    sequence[i * k + j] = source[i + y - m, j + x - m];
                }
            }

            sequence = sequence.OrderBy(num => num).ToArray();
            return sequence[m * k + m];
        }

        private static int GetAverageColor(int[,] source, int x, int y, int m)
        {
            int red = 0;
            int blue = 0;
            int green = 0;
            for (int i = y - m; i <= y + m; i++)
            {
                for (int j = x - m; j <= x + m; j++)
                {
                    Color temp = Color.FromArgb(source[i, j]);
                    red += temp.R;
                    green += temp.G;
                    blue += temp.B;
                }
            }

            int k = (2 * m + 1);
            int sqrK = k * k;
            return Color.FromArgb(red / sqrK, green / sqrK, blue / sqrK).ToArgb();
        }

        private static int GetGauss(int[,] source, int x, int y, int m)
        {
            double result = 0;
            int k = 2 * m + 1;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    int temp = source[y + i - m, x + j - m];
                    result += gaussKernel[i, j] * temp;
                }
            }

            return (int)result;
        }

        private static int GetGaussColor(int[,] source, int x, int y, int m)
        {
            double red = 0;
            double green = 0;
            double blue = 0;
            int k = 2 * m + 1;
            double[,] kernel = GetGaussMatrix(1.5, m);
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Color temp = Color.FromArgb(source[y + i - m, x + j - m]);
                    red += kernel[i, j] * temp.R;
                    green += kernel[i, j] * temp.G;
                    blue += kernel[i, j] * temp.B;
                }
            }

            return Color.FromArgb(Math.Min((int)red, 255), Math.Min((int)green, 255), Math.Min((int)blue, 255)).ToArgb();
        }

        private static int GetSobel(int[,] source, int x, int y, int m)
        {
            int gx = 0;
            int gy = 0;
            int k = 2 * m + 1;
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    gx += sobelKernelX[i, j] * source[y + i - m , x + j - m];
                    gy += sobelKernelY[i, j] * source[y + i - m, x + j - m];
                }
            }

            return (int)(Math.Sqrt(gx * gx + gy * gy));
        }

        private static int GetSobelColor(int[,] source, int x, int y, int m)
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

        private static double[,] GetGaussMatrix(double sigma, int m)
        {
            if (gaussKernels.ContainsKey(m))
            {
                return gaussKernels[m];
            }

            int k = 2 * m + 1;
            double sigmaSqr = sigma * sigma;
            var result = new double[k, k];
            for (int y = -m; y <= m; y++)
            {
                for (int x = -m; x <= m; x++)
                {
                    result[y + m, x + m] = 1 / (2 * Math.PI * sigmaSqr) * Math.Exp(-(x * x + y * y) / (2 * sigmaSqr)); 
                }
            }

            gaussKernels.Add(m, result);
            return result;
        }

    }
}
