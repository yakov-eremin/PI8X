using System;
using System.CodeDom;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KGRastr
{

    public class TrueBitmap : IDisposable
    {

        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }
        public bool isColorChanged = true;
        public Color AveracheBrigthness { get; set; }

        public virtual void SetPixel(int x, int y, Color color)
        {
            isColorChanged = true;
            int index = x + (y * Width);
            int col = color.ToArgb();

            Bits[index] = col;
        }

        public virtual Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }
        public TrueBitmap(Bitmap bmp)
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
        public TrueBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void Dispose()
        {
            Bitmap?.Dispose();
        }
    }
}