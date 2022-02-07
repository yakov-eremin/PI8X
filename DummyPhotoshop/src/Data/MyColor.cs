using System.Drawing;

namespace DummyPhotoshop.Data
{
    public struct MyColor
    {
        public readonly byte R, G, B;
        public readonly int Value;

        public MyColor(int value)
        {
            R = unchecked((byte)(value >> RedShift));
            G = unchecked((byte)(value >> GreenShift));
            B = unchecked((byte)(value >> BlueShift));
            Value = value;
        }

        public MyColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
            Value = (r << RedShift) + (g << GreenShift) + (b << BlueShift) + (255 << AlphaShift);
        }
        public MyColor(int r, int g, int b) : this((byte)r, (byte)g, (byte)b)
        {
        }

        public MyColor(Color color) : this(color.R, color.G, color.B)
        {
        }

        public static implicit operator Color(MyColor r) => Color.FromArgb(r.Value);

        private const int AlphaShift = 24;
        private const int RedShift = 16;
        private const int GreenShift = 8;
        private const int BlueShift = 0;
    }
}