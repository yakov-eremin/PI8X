using System;

namespace DummyPhotoshop.Filters
{
    public class GaussianDenoiseFilter : MaskFilter
    {
        public double Variance { get; set; } = 1;

        protected override void InitMask()
        {
            for (int i = 0; i < Radius + 1; i++)
                for (int j = i; j < Radius + 1; j++)
                {
                    var value = CalcH(i, j);
                    var c = Radius;
                    Mask[c + i, c + j] = value;
                    Mask[c + i, c - j] = value;
                    Mask[c - i, c + j] = value;
                    Mask[c - i, c - j] = value;
                    Mask[c + j, c + i] = value;
                    Mask[c + j, c - i] = value;
                    Mask[c - j, c + i] = value;
                    Mask[c - j, c - i] = value;
                }

            double hSum = 0;
            for (int i = 0; i <= 2 * Radius; i++)
                for (int j = 0; j <= 2 * Radius; j++)
                    hSum += Mask[i, j];

            double a = 1.0 / hSum;
            for (int i = 0; i < 2 * Radius + 1; i++)
            {
                for (int j = 0; j < 2 * Radius + 1; j++)
                {
                    Mask[i, j] *= a;
                }
            }
        }

        private double CalcH(int x, int y) => Math.Exp(-(x * x + y * y) / (2 * Variance * Variance));

    }
}