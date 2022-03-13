using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using DummyPhotoshop.Data;
using DummyPhotoshop.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Photoshop.Filters;

namespace DummyPhotoshopTests
{
    public class FastBitmapComparator
    {
        [DllImport("msvcrt.dll")]
        private static extern int memcmp(IntPtr b1, IntPtr b2, long count);

        public static bool AreEqual(Bitmap b1, Bitmap b2)
        {
            if (b1.Size != b2.Size) return false;

            var bd1 = b1.LockBits(new Rectangle(new Point(0, 0), b1.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var bd2 = b2.LockBits(new Rectangle(new Point(0, 0), b2.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                IntPtr bd1scan0 = bd1.Scan0;
                IntPtr bd2scan0 = bd2.Scan0;

                int stride = bd1.Stride;
                int len = stride * b1.Height;

                return memcmp(bd1scan0, bd2scan0, len) == 0;
            }
            finally
            {
                b1.UnlockBits(bd1);
                b2.UnlockBits(bd2);
            }
        }
    }


    [TestClass]
    public class FiltersTests
    {
        [TestMethod]
        public void TestBrightness()
        {
            var filter = new BrightnessFilter { Coefficient = 60 };
            TestFilter(Resources.brightness60, filter);
        }

        [TestMethod]
        public void TestBinarization()
        {
            var filter = new BinarizationFilter { Threshold = 125 };
            TestFilter(Resources.binarization_125, filter);
        }

        [TestMethod]
        public void TestBlackWhite()
        {
            var filter = new BlackWhiteFilter();
            TestFilter(Resources.blackwhite, filter);
        }

        [TestMethod]
        public void TestCrop()
        {
            var filter = new BlackWhiteFilter();
            var orig = new Photo(Resources.orig);
            var croppedOrig = new PhotoCrop(orig, new Rectangle(1, 1, 3, 3));
            var result = new Photo(Resources.blackwhite_rect_1_1_3_3);
            TestFilter(croppedOrig, result, filter);
        }

        [TestMethod]
        public void TestContrast()
        {
            var filter = new ContrastFilter { Coefficient = 2 };
            TestFilter(Resources.contrast2, filter);
        }

        [TestMethod]
        public void TestEmbossing()
        {
            var filter = new EmbossingFilter();
            TestFilter(Resources.embossing, filter);
        }

        [TestMethod]
        public void TestGaussianDenoise()
        {
            var filter = new GaussianDenoiseFilter { Radius = 2, Variance = 4 };
            TestFilter(Resources.gauss_c4_r2, filter);
        }

        [TestMethod]
        public void TestMedianDenoise()
        {
            var filter = new MedianDenoiseFilter { Radius = 2 };
            TestFilter(Resources.median_r2, filter);
        }

        [TestMethod]
        public void TestSharpening()
        {
            var filter = new SharpeningFilter { Coefficient = 2, Radius = 2 };
            TestFilter(Resources.sharpening_r2_c2, filter);
        }

        [TestMethod]
        public void TestUniformDenoise()
        {
            var filter = new UniformDenoiseFilter { Radius = 2 };
            TestFilter(Resources.uniform_r2, filter);
        }

        private void TestFilter(IPhoto origPhoto, IPhoto resultPhoto, IFilter filter)
        {
            var processed = filter.ProcessImage(origPhoto);
            Assert.IsTrue(FastBitmapComparator.AreEqual(processed.Bitmap, resultPhoto.Bitmap));
        }

        private void TestFilter(Bitmap origBitmap, Bitmap resultBitmap, IFilter filter)
        {
            TestFilter(new Photo(origBitmap), new Photo(resultBitmap), filter);
        }

        private void TestFilter(Bitmap resultBitmap, IFilter filter)
        {
            TestFilter(Resources.orig, resultBitmap, filter);
        }
    }
}
