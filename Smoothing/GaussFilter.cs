using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Smoothing
{
    public class GaussFilter : MatrixFilter
    {
        private static Dictionary<(int, double), double[,]> gaussKernels = new Dictionary<(int, double), double[,]>();
        private double sigma;

        public GaussFilter(double sigma)
        {
            this.sigma = sigma;
        }

        protected override int ProcessPixel(int[,] source, int x, int y, int m)
        {
            double red = 0;
            double green = 0;
            double blue = 0;
            int k = 2 * m + 1;
            double[,] kernel = GetGaussMatrix(this.sigma, m);
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

        private static double[,] GetGaussMatrix(double sigma, int m)
        {
            if (gaussKernels.ContainsKey((m, sigma)))
            {
                return gaussKernels[(m, sigma)];
            }

            int k = 2 * m + 1;
            double sigmaSqr = sigma * sigma;
            var result = new double[k, k];
            double sum = 0;
            for (int y = -m; y <= m; y++)
            {
                for (int x = -m; x <= m; x++)
                {
                    result[y + m, x + m] = 1 / (2 * Math.PI * sigmaSqr) * Math.Exp(-(x * x + y * y) / (2 * sigmaSqr));
                    sum += result[y + m, x + m];
                }
            }

            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    result[i, j] /= sum;
                }
            }

            gaussKernels.Add((m, sigma), result);
            return result;
        }

    }
}
