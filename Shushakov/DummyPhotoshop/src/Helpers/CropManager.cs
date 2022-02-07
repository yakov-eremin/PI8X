using System;
using System.Drawing;
using System.Threading;
using DummyPhotoshop.Data;

namespace DummyPhotoshop.Helpers
{
    public class CropManager
    {
        public Photo OriginalPhoto => _photo;
        public bool IsCropping { get; private set; }

        public void StartCrop(Photo photo, Point startPoint)
        {
            _photo = photo;
            _startPoint = _curPoint = startPoint;
            IsCropping = true;
        }

        public bool IsNothingSelected => GetCurrentRectangle().Size == Size.Empty;

        public void StopCrop() => IsCropping = false;

        public void Update(Point curPoint) => _curPoint = curPoint;

        public Rectangle GetCurrentRectangle()
        {
            var lu = new Point(Math.Min(_startPoint.X, _curPoint.X), Math.Min(_startPoint.Y, _curPoint.Y));
            var rd = new Point(Math.Max(_startPoint.X, _curPoint.X), Math.Max(_startPoint.Y, _curPoint.Y));
            lu.X = Math.Clamp(lu.X, 0, _photo.Width);
            rd.X = Math.Clamp(rd.X, 0, _photo.Width);
            lu.Y = Math.Clamp(lu.Y, 0, _photo.Height);
            rd.Y = Math.Clamp(rd.Y, 0, _photo.Height);
            return Rectangle.FromLTRB(lu.X, lu.Y, rd.X, rd.Y);
        }

        private Photo _photo;
        private Point _startPoint;
        private Point _curPoint;
    }
}