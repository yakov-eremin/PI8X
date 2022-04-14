// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com


using System;
using System.Drawing;

namespace PhotoCorrection {
	class ColorBalance {
		public static void ColorBalanceCyanRed(Bitmap original, ref Bitmap modified, float coef) {
            /* Изменение цветового баланса Голубой-Красный 
             * ------------------
             * Для каждого пикселя изображения изменяем компоненту R
             * на значение заданного коэффициента
             */

            for (int y = 0; y < original.Height; y++)
                for (int x = 0; x < original.Width; x++) {

                    Color pix = original.GetPixel(x, y);
                    int R = pix.R, G = pix.G, B = pix.B, A = pix.A;

                    int red = (int)(R + coef);
                    red = Math.Min(255, Math.Max(0, red));

                    modified.SetPixel(x, y, Color.FromArgb(A, red, G, B));
                }
        }

        public static void ColorBalanceMagentaGreen(Bitmap original, ref Bitmap modified, float coef) {
            /* Изменение цветового баланса Пурпурный-Зеленый
             * ------------------
             * Для каждого пикселя изображения изменяем компоненту G
             * на значение заданного коэффициента
             */

            for (int y = 0; y < original.Height; y++)
                for (int x = 0; x < original.Width; x++) {

                    Color pix = original.GetPixel(x, y);
                    int R = pix.R, G = pix.G, B = pix.B, A = pix.A;

                    int green = (int)(G + coef);
                    green = Math.Min(255, Math.Max(0, green));

                    modified.SetPixel(x, y, Color.FromArgb(A, R, green, B));
                }
        }

        public static void ColorBalanceYellowBlue(Bitmap original, ref Bitmap modified, float coef) {
            /* Изменение цветового баланса Желтый-Синий
             * ------------------
             * Для каждого пикселя изображения изменяем компоненту B
             * на значение заданного коэффициента
             */

            for (int y = 0; y < original.Height; y++)
                for (int x = 0; x < original.Width; x++) {

                    Color pix = original.GetPixel(x, y);
                    int R = pix.R, G = pix.G, B = pix.B, A = pix.A;

                    int blue = (int)(B + coef);
                    blue = Math.Min(255, Math.Max(0, blue));

                    modified.SetPixel(x, y, Color.FromArgb(A, R, G, blue));
                }
        }
    }
}
