using DummyPhotoshop.Data;
using Photoshop.Filters;

namespace DummyPhotoshop.Filters
{
    public class EmbossingFilter:IFilter
    {
        private CompoundFilter _filter;
        public EmbossingFilter()
        {
            _filter = new CompoundFilter();
            var maskFilter = new UserMaskFilter
            {
                Mask = new double[,]
                {
                    {0.0, 1.0, 0.0},
                    {1.0, 0.0,-1.0},
                    {0.0,-1.0, 0.0}
                }
            };
            var brightFilter = new BrightnessFilter();
            brightFilter.Coefficient = 128;
            _filter.Filters.AddLast(maskFilter);
            _filter.Filters.AddLast(brightFilter);
        }
        public IPhoto ProcessImage(IPhoto photo)
        {
            return _filter.ProcessImage(photo);
        }
    }
}