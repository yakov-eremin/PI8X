using System;
using DummyPhotoshop.Data;

namespace DummyPhotoshop.Filters
{
    public abstract class MaskFilter : PixelFilter
    {
        public int Radius { get; set; } = 1;
        protected double[,] Mask;

        protected abstract void InitMask();

        protected override void PreProcess(IPhoto photo)
        {
            Mask = new double[2 * Radius + 1, 2 * Radius + 1];
            InitMask();
        }

        protected override MyColor ProcessPixel(int x, int y, IPhoto photo)
        {
            double r = 0, g = 0, b = 0;
            for (int i = 0; i < 2*Radius+1; i++)
                for (int j = 0; j < 2*Radius+1; j++)
                {
                    var c = Radius;
                    var currPixel = photo.ClampGetPixel(x + j - c, y + i - c);
                    double coef = Mask[i, j];
                    r += currPixel.R * coef;
                    g += currPixel.G * coef;
                    b += currPixel.B * coef;
                }

            return new MyColor(
                Math.Clamp((int)(r), 0, 255),
                Math.Clamp((int)(g), 0, 255),
                Math.Clamp((int)(b), 0, 255)
            );

        }
    }

}