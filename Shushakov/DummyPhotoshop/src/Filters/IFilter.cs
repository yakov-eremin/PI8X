using DummyPhotoshop.Data;

namespace Photoshop.Filters
{
    public interface IFilter
    {
        public IPhoto ProcessImage(IPhoto photo);
    }
}