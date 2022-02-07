using System.Collections.Generic;
using DummyPhotoshop.Data;
using Photoshop.Filters;

namespace DummyPhotoshop.Filters
{
    public class CompoundFilter:IFilter
    {
        public LinkedList<IFilter> Filters { get; set; }

        public CompoundFilter()
        {
            Filters = new LinkedList<IFilter>();
        }
        public IPhoto ProcessImage(IPhoto photo)
        {
            foreach (var filter in Filters)
            {
                photo = filter.ProcessImage(photo);
            }
            return photo;
        }

    }
}