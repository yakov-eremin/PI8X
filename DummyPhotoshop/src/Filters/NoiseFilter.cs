using System;
using System.Collections.Concurrent;
using DummyPhotoshop.Data;

namespace DummyPhotoshop.Filters
{
    public class NoiseFilter : PixelFilter
    {
        private static ConcurrentDictionary<(int, int, int), (int, int, int)> _cashedRandDeltaPixel = new();

        public double Percent { get; set; }
        public bool Monochrome { get; set; }

        private void RandDeltaPixel(int i, int j, IPhoto photo, out int dr, out int dg, out int db)
        {
            var c = photo.GetHashCode();
            if (_cashedRandDeltaPixel.ContainsKey((i, j, c)))
            {
                var value = _cashedRandDeltaPixel[(i, j, c)];
                dr = value.Item1;
                dg = value.Item2;
                db = value.Item3;
                return;
            }
            dr = ((i * 564 + j * 53446 + 4234).ToString() + i * j * 1245 + c).GetHashCode() % 256;
            dg = ((i * 1234 + j * 73380 + 974).ToString() + i * j * 4254 + c).GetHashCode() % 256;
            db = ((i * 237 + j * 3275 + 395).ToString() + i * j * 39437 + c).GetHashCode() % 256;
            _cashedRandDeltaPixel[(i, j, c)] = (dr, dg, db);
        }

        protected override MyColor ProcessPixel(int x, int y, IPhoto photo)
        {
            var pixel = photo.GetPixel(x, y);
            int dr, dg, db;
            RandDeltaPixel(x, y, photo, out dr, out dg, out db);
            dr = (int)(dr * Percent);
            dg = (int)(dg * Percent);
            db = (int)(db * Percent);
            if (Monochrome)
                dg = db = dr;
            return new MyColor(
                Math.Clamp(pixel.R + dr, 0, 255),
                Math.Clamp(pixel.G + dg, 0, 255),
                Math.Clamp(pixel.B + db, 0, 255)
                );
        }

    }
}