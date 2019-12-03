using System;
using static System.Math;

namespace Wave
{
    class Fourier
    {

        public double[] DFT(double[] s)
        {
            int N = s.Length;
            double real, imag;
            double[] A = new double[N];
            int f=0;

            while (f < N)
            {
                real = 0;
                imag = 0;
                for (int t = 0; t <= N - 1; t++)
                {
                    real += s[t] * Cos(2 * PI * t * f / N);
                    imag -= s[t] * Sin(2 * PI * t * f / N);
                }
                A[f] = Sqrt(real * real + imag * imag);
                f+=1;
            }
            return A;
        }
    }

    class Filter
    {
        public double[] applyFilter(double high, double low, double[] f)
        {
            double[] ff = f;
            int nyquist = (ff.Length / 2);

            if (high > 0)
            {
                for (int i = 0; i < nyquist; i++)
                {
                    if (i < high)
                    {
                        ff[i] *= 0;
                        ff[(ff.Length - 1 - i)] *= 0;
                    }
                }
            }

            if (low > 0)
            {
                for (int i = 0; i < nyquist; i++)
                {
                    if (i > low)
                    {
                        ff[i] *= 0;
                        ff[(ff.Length - 1 - i)] *= 0;
                    }
                }
            }

            return ff;
        }
    }
}


