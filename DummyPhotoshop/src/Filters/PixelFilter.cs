using System.Threading.Tasks;
using DummyPhotoshop.Data;
using Photoshop.Filters;

namespace DummyPhotoshop.Filters
{
    public abstract class PixelFilter : IFilter
    {
        public IPhoto ProcessImage(IPhoto photo)
        {

            PreProcess(photo);
            var resPhoto = (IPhoto)photo.Clone();
            int maxThreads = 42;
            Parallel.For(0, maxThreads, thread =>
            {
                int from = thread * photo.Height / maxThreads;
                int to = (thread + 1) * photo.Height / maxThreads;
                for (int i = from; i < to; i++)
                for (int j = 0; j < photo.Width; j++)
                    resPhoto.SetPixel(j, i, ProcessPixel(j, i, photo));
            });
            return resPhoto;
        }

        protected virtual void PreProcess(IPhoto photo)
        {
        }

        protected abstract MyColor ProcessPixel(int x, int y, IPhoto photo);

    }
}

