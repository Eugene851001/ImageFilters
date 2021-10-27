using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smoothing
{
    public class MiddleFilter : MatrixFilter
    {
        protected override int ProcessPixel(int[,] source, int x, int y, int m)
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
    }
}
