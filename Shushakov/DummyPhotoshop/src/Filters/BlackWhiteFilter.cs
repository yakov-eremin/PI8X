using DummyPhotoshop.Data;

namespace DummyPhotoshop.Filters
{
    public class BlackWhiteFilter:PixelFilter
    {
        protected override MyColor ProcessPixel(int x, int y, IPhoto photo)
        {
            MyColor pixel = photo.GetPixel(x, y);
            var br = (int)pixel.CalcBrightness();
            return new MyColor(br, br, br);
        }
    }
}