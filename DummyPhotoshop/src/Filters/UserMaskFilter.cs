namespace DummyPhotoshop.Filters
{
    public class UserMaskFilter:MaskFilter
    {
        public double[,] Mask { get; set; }

        protected override void InitMask()
        {
            base.Mask = Mask;
            Radius = Mask.GetLength(0) / 2;
        }
    }
}