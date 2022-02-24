using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGRastr
{
    static class Rastr
    {
        public static int[] getBar(TrueBitmap current, Rectangle activeArea)
        {
            int[] bar = new int[256];
            int maxX = activeArea.X + activeArea.Width;
            int maxY = activeArea.Y + activeArea.Height;
            for (int i = activeArea.X; i < maxX; i++)
            {
                for (int j = activeArea.Y; j < maxY; j++)
                {
                    var br = calcBrightness(current.GetPixel(i, j));
                    bar[br]++;
                } 
            }
            return bar;
        }

        public static int calcAverageBrightness(Rectangle activeArea, TrueBitmap image)
        {
            int maxX = activeArea.X + activeArea.Width;
            int maxY = activeArea.Y + activeArea.Height;
            int sum = 0;
            for (int i = activeArea.X; i < maxX; i++)
            {
                for (int j = activeArea.Y; j < maxY; j++)
                {
                    sum += calcBrightness(image.GetPixel(i, j));
                }
            }

            return sum / (activeArea.Height * activeArea.Width);
        }
        public static int calcBrightness(Color c)
        {
            return (int)(0.299f * c.R + 0.5876 * c.G + 0.114 * c.B);
        }
        public static void DrawBar(Graphics gr, TrueBitmap current, Rectangle activeArea)
        {
            var rect = gr.VisibleClipBounds;
            float dy = rect.Height;
            int[] data = getBar(current, activeArea);
            float maxy = data.Max();
            float prevX = 0;
            Brush br = new SolidBrush(Color.Black);
            for (int i = 0; i < data.Length; i++)
            {
                var x = ((float)i + 1) / data.Length * rect.Width;
                var y = (((float)data[i] / maxy) * rect.Height);
                gr.FillRectangle(br, prevX, dy - y, x - prevX, y);
                prevX = x;
            }
            br.Dispose();
        }
    }

    public interface Transformation
    {
        public void ChangeKoeff(double a)
        {
        }

        public Color Transform(Color c);

        public void PredCalc(TrueBitmap image, Rectangle area)
        {
        }

        public void Execute(TrueBitmap image, Rectangle area)
        {
            PredCalc(image, area);
            int maxX = area.X + area.Width;
            int maxY = area.Y + area.Height;
            for (int i = area.X; i < maxX; i++)
            {
                for (int j = area.Y; j < maxY; j++)
                {
                    image.SetPixel(i, j, Transform(image.GetPixel(i, j)));
                }
            }

        }

    }

    public class LightTransformation : Transformation
    {
        private int _delta;

        public void ChangeKoeff(double a)
        {
            _delta = (int)a;
        }
        public LightTransformation(int delta)
        {
            _delta = delta;
        }
        public Color Transform(Color c)
        {
            var a = Math.Clamp(c.R + _delta, 0, 255);
            return Color.FromArgb(Math.Clamp(c.R + _delta, 0, 255),
                Math.Clamp(c.G + _delta, 0, 255),
                Math.Clamp(c.B + _delta, 0, 255));
        }
    }

    public class ContrastTransformation : Transformation
    {
        private double _k;
        private double _middleLight;

        public void ChangeKoeff(double a)
        {
            _k = a;
        }
        public void PredCalc(TrueBitmap image, Rectangle area)
        {
            _middleLight = Rastr.calcAverageBrightness(area, image);
        }


        public ContrastTransformation(double k)
        {
            _k = k;
        }

        private int currentY(int canal)
        {
            return Math.Clamp((int)(_k * (canal - _middleLight) + _middleLight), 0, 255);
        }
        public Color Transform(Color c)
        {
            return Color.FromArgb(currentY(c.R),
                currentY(c.G),
                currentY(c.B));
        }
    }

    public class Binarization : Transformation
    {
        private int _level;

        public void ChangeKoeff(double a)
        {
            _level = (int)a;
        }
        public Binarization(int level)
        {
            _level = level;
        }
        public Color Transform(Color c)
        {
            if (Rastr.calcBrightness(c) > _level)
                return Color.White;
            return Color.Black;
        }
    }
    public class UniformDistributionNoise : Transformation
    {
        private double _intensive;
        private Random rand;
        public void ChangeKoeff(double a)
        {
            _intensive = a;
        }
        public UniformDistributionNoise(double intensive)
        {
            _intensive = intensive;
            rand = new Random();
        }

        private byte NoisedColor(byte channel)
        {

           // return (byte)Math.Clamp((int)(channel  + rand.NextBytes() * _intensive), 0, 255);
           return 1;
        }
        public Color Transform(Color c)
        {
            return Color.FromArgb(NoisedColor(c.R), NoisedColor(c.G), NoisedColor(c.B));
        }
    }
    public class ShadowOfGray : Transformation
    {

        public Color Transform(Color c)
        {
            var value = Rastr.calcBrightness(c);
            return Color.FromArgb(value, value, value);
        }
    }
    public class Negative : Transformation
    {

        public Color Transform(Color c)
        {
            return Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
        }
    }
}
