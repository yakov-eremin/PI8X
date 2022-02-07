namespace DummyPhotoshop.Filters
{
    public class SharpeningFilter : MaskFilter
    {
        public double Coefficient { get; set; } = 2;
        protected override void InitMask()
        {
            int cnt = (2 * Radius + 1) * (2 * Radius + 1);
            for (int i = 0; i <= 2 * Radius; i++)
                for (int j = 0; j <= 2 * Radius; j++)
                    Mask[i, j] = -Coefficient / (cnt - 1);
            Mask[Radius, Radius] = Coefficient + 1;
        }
    }
}