using System;
using System.Drawing;
using DummyPhotoshop.Data;

namespace DummyPhotoshop
{
    public static class Extentions
    {
        public static MyColor ClampGetPixel(this IPhoto photo, int x, int y)
        {
            x = Math.Clamp(x, 0, photo.Width - 1);
            y = Math.Clamp(y, 0, photo.Height - 1);
            return photo.GetPixel(x, y);
        }

        public static double CalcBrightness(this MyColor color)
        {
            return 0.299 * color.R + 0.5876 * color.G + 0.114 * color.B;
        }


    }
}