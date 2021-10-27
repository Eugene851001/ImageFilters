using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Smoothing
{
    public class AverageFilter : MatrixFilter
    {
        protected override int ProcessPixel(int[,] source, int x, int y, int m)
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
    }
}
