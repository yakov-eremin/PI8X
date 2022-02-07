using DummyPhotoshop.Data;

namespace DummyPhotoshop.Filters
{
    public class BinarizationFilter : PixelFilter
    {
        public int Threshold { get; set; }
        public MyColor LeftColor { get; set; } = new MyColor(0,0,0);
        public MyColor RightColor { get; set; } =  new MyColor(255,255,255);

        protected override MyColor ProcessPixel(int x, int y, IPhoto photo)
        {
            MyColor pixel = photo.GetPixel(x, y);
            return pixel.CalcBrightness() > Threshold ? RightColor : LeftColor;
        }
    }
}