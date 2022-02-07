using System.Drawing;
using System.Linq;
using DummyPhotoshop.Data;

namespace DummyPhotoshop
{
    public class BrightnessHistogram
    {
        public int MaxValue { get; set; }
        public void Draw(IPhoto photo, Graphics gr)
        {
            float wigth = gr.VisibleClipBounds.Width;
            float height = gr.VisibleClipBounds.Height;
            var distribution = new int[256];
            for (int i = 0; i < photo.Height; i++)
                for (int j = 0; j < photo.Width; j++)
                    distribution[(int)(photo.GetPixel(j, i).CalcBrightness())]++;
            MaxValue = (int)distribution.Average() * 6;
           // MaxValue = (int)distribution.Max();
            float prevX = 0;
            Brush br = new SolidBrush(Color.Black);
            for (int i = 0; i < 256; i++)
            {
                float x = (float)(i + 1) / 256 * wigth;
                float y = (float)distribution[i] / MaxValue * height;
                gr.FillRectangle(br, prevX, height - y, x - prevX, y);

                prevX = x;
            }
            br.Dispose();

        }

    }
}