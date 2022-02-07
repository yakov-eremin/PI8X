
namespace DummyPhotoshop.Filters
{
    public class UniformDenoiseFilter : MaskFilter
    {
        protected override void InitMask()
        {
            for(int i = 0; i <=2*Radius; i++)
            for (int j = 0; j <= 2 * Radius; j++)
                Mask[i,j] = 1.0 / (2 * Radius + 1) / (2 * Radius + 1);
        }
    }
}