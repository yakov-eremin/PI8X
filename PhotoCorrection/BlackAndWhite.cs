// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com


using System.Drawing;

namespace PhotoCorrection {
	class BlackAndWhite {

		public static void Binarization(Bitmap original, ref Bitmap modified, float coef) {
            /* Переход к черно-белому 
             * ----------------------
             * вычисляем значение separator - значение,
             * относительно которого будем определять
             * черным или белым будет каждый пиксель:
             * если значение пикселя больше separator, то
             * пиксель будет белым, иначе черным
             */

            double separator = 255 / coef / 2 * 3;

            for (int y = 0; y < original.Height; y++)
                for (int x = 0; x < original.Width; x++) {

                    Color pix = original.GetPixel(x, y);
                    int R = pix.R, G = pix.G, B = pix.B, A = pix.A;

                    int total = R + G + B;

                    if (total > separator)
                        modified.SetPixel(x, y, Color.FromArgb(A, 255, 255, 255));
                    else
                        modified.SetPixel(x, y, Color.FromArgb(A, 0, 0, 0));
                }
        }

        public static void Grayscale(Bitmap original, ref Bitmap modified) {
            /* Переход к оттенкам серого 
             * -------------------------
             * для каждого пикселя изображения
             * определяем его цвет в серых тонах
             * по формуле (R * 0.2126 + G * 0.7152 + B * 0.0722)
             * устанавливаем каждому пикселю его новое значение
             */

            for (int y = 0; y < original.Height; y++)
                for (int x = 0; x < original.Width; x++) {

                    Color pix = original.GetPixel(x, y);
                    int R = pix.R, G = pix.G, B = pix.B, A = pix.A;

                    int gray = (int)(R * 0.2126 + G * 0.7152 + B * 0.0722);

                    modified.SetPixel(x, y, Color.FromArgb(A, gray, gray, gray));
                }
        }
    }
}
