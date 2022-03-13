using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DummyPhotoshop.Helpers
{
    public class PictureBoxWithInterpolationMode: PictureBox
    {
        public InterpolationMode InterpolationMode { get; set; } = InterpolationMode.NearestNeighbor;

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = InterpolationMode;
            base.OnPaint(pe);
        }
    }
}