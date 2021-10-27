using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smoothing
{
    public abstract class MatrixFilter
    {
        public int[,] Filter(int[,] source, int windowSize)
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
                    result[i, j] = this.ProcessPixel(source, j, i, m);
                }
            }

            return result;
        }

        protected abstract int ProcessPixel(int[,] source, int x, int y, int m);
    }
}
