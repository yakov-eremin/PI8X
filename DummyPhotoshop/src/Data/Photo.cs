using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DummyPhotoshop.Data
{
    public class Photo : IPhoto, IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        private bool _isModifiedAverageColor = true;
        private MyColor _averageColor;

        public Photo(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        ~Photo()
        {
            Dispose();
        }
        public Photo(Bitmap bmp)
        {
            Width = bmp.Width;
            Height = bmp.Height;

            BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int numbytes = bmpdata.Stride * bmp.Height;
            Bits = new int[numbytes / 4];
            IntPtr ptr = bmpdata.Scan0;
            Marshal.Copy(ptr, Bits, 0, numbytes / 4);
            bmp.UnlockBits(bmpdata);

            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }



        public virtual void SetPixel(int x, int y, MyColor colour)
        {
            _isModifiedAverageColor = true;
            int index = x + (y * Width);
            int col = colour.Value;
            
            Bits[index] = col;
        }

        public virtual MyColor GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            MyColor result = new MyColor(col);

            return result;
        }

        public MyColor GetAverageColor()
        {
            if (!_isModifiedAverageColor)
            {
                return _averageColor;
            }

            _isModifiedAverageColor = false;
            long r = 0, g = 0, b = 0;
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                {
                    var pixel = GetPixel(j, i);
                    r += pixel.R;
                    g += pixel.G;
                    b += pixel.B;
                }

            long cnt = Height * Width;
            return _averageColor = new MyColor((int)(r / cnt), (int)(g / cnt), (int)(b / cnt));
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }

        public object Clone()
        {
            var clone = new Photo(Bitmap);
            return clone;
        }
    }
}