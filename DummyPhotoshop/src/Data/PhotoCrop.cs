using System.Drawing;

namespace DummyPhotoshop.Data
{
    public class PhotoCrop: IPhoto
    {
        public Bitmap Bitmap
        {
            get { return CropedPhoto.Bitmap; }
        }

        public int Width => Crop.Width;
        public int Height => Crop.Height;
        public Rectangle Crop { get; set; }

        public Photo CropedPhoto { get; set; }
        public PhotoCrop(Photo cropedPhoto, Rectangle crop)
        {
            CropedPhoto = cropedPhoto;
            Crop = crop;
        }

        public void SetPixel(int x, int y, MyColor colour)
        {
            
            CropedPhoto.SetPixel(Crop.X + x, Crop.Y + y, colour);
        }

        public MyColor GetPixel(int x, int y)
        {
            return CropedPhoto.GetPixel(Crop.X + x, Crop.Y + y);
        }

        public MyColor GetAverageColor()
        {
            return CropedPhoto.GetAverageColor();
        }

        public void Dispose()
        {
            CropedPhoto.Dispose();
        }

        public object Clone()
        {
            return new PhotoCrop((Photo)CropedPhoto.Clone(), Crop);
        }
    }
}