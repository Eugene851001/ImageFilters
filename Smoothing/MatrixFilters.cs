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
                { 0.01, 0.08, 0.01},
                { 0.08, 0.64, 0.01},
                { 0.01, 0.08, 0.01}
            };

        public static int[,] FilterAverage(int[,] source, int windowSize) =>
            HelpFilter(source, windowSize, GetAverageColor);

        public static int[,] FilterMiddle(int[,] source, int windowSize) =>
            HelpFilter(source, windowSize, GetMiddle);

        public static int[,] FilterGauss(int[,] source, int windowSize) =>
            HelpFilter(source, windowSize, GetGaussColor);


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
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Color temp = Color.FromArgb(source[y + i - m, x + j - m]);
                    red += gaussKernel[i, j] * temp.R;
                    green += gaussKernel[i, j] * temp.G;
                    blue += gaussKernel[i, j] * temp.B;
                }
            }

            return Color.FromArgb((int)red, (int)green, (int)blue).ToArgb();
        }

    }
}
