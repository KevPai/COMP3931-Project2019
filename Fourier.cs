using System;
using static System.Math;

namespace Wave
{
    class Fourier
    {
        double[] real, imag;

        public double[] DFT(double[] s)
        {
            int N = s.Length;
            double[] A = new double[N];
            int f = 0;

            real = new double[N];
            imag = new double[N];

            while (f < N)
            {
                for (int t = 0; t <= N - 1; t++)
                {
                    real[f] += s[t] * Cos(2 * PI * t * f / N);
                    imag[f] -= s[t] * Sin(2 * PI * t * f / N);
                }
                A[f] = Sqrt(real[f] * real[f] + imag[f] * imag[f]);
                f += 1;
            }
            return A;
        }

        public double[] inverseDFT(double[] s)
        {
            double[] a = new double[s.Length];
            int f = 0;

            for (int k = 0; k < s.Length; k++)
            {
                real[k] /= (s.Length / 2);
                imag[k] /= (s.Length / 2);
            }

            real[0] /= 2;
            real[s.Length-1] /= 2;

            while (f < a.Length)
            {
                for (int t = 0; t < a.Length; t++)
                {
                    a[f] += real[t] * Cos(2 * PI * t * f / s.Length);
                    a[f] -= imag[t] * Sin(2 * PI * t * f / s.Length);
                }

                f += 1;
            }

            return a;
        }



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
                        real[i] *= 0;
                        real[(ff.Length - 1 - i)] *= 0;

                        imag[i] *= 0;
                        imag[(ff.Length - 1 - i)] *= 0;

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
                        real[i] *= 0;
                        real[(ff.Length - 1 - i)] *= 0;

                        imag[i] *= 0;
                        imag[(ff.Length - 1 - i)] *= 0;

                        ff[i] *= 0;
                        ff[(ff.Length - 1 - i)] *= 0;
                    }
                }
            }

            return ff;
        }
    }
}
