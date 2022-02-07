using DummyPhotoshop.Data;

namespace DummyPhotoshop.Filters
{
    public class NegativeFilter:PixelFilter
    {
        protected override MyColor ProcessPixel(int x, int y, IPhoto photo)
        {
            MyColor pixel = photo.GetPixel(x, y);
            return new MyColor(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
        }
    }
}