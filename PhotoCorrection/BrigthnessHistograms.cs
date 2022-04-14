// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com


using System;
using System.Drawing;

namespace PhotoCorrection {
	class BrigthnessHistograms {

		public static void GetHistograms(Bitmap image, ref Bitmap bmpL, ref Bitmap bmpRGB, ref Bitmap bmpR, ref Bitmap bmpG, ref Bitmap bmpB) {
			/* Вычисление данных, необходимых для построения гистограмм
			 * и вызов функции построения гистограмм
			 * --------------------------------------
			 * для каждого пикселя изображения берем компоненты R,G,B
			 * и инкриментируем соотвественное значение в массиве по индексу R,G,B
			 * индекс для массива гистограммы яркости для пикселя вычисляется
			 * по формуле 0.299 * R + 0.5876 * G + 0.114 * B
			 * для гистограммы RGB по индексу каждой компоненты инкриментируется значение
			 * после значения массива делятся на 3
			 */
			int[] histoLum = new int[256];
			int[] histoR = new int[256];
			int[] histoG = new int[256];
			int[] histoB = new int[256];
			int[] histoRGB = new int[256];

			for (int y = 0; y < image.Height; y++)
				for (int x = 0; x < image.Width; x++) {
					Color pix = image.GetPixel(x, y);
					int R = pix.R, G = pix.G, B = pix.B;

					int index = (int)(0.299 * R + 0.5876 * G + 0.114 * B);

					histoLum[index] += 1;

					histoR[R] += 1;
					histoG[G] += 1;
					histoB[B] += 1;

					histoRGB[R] += 1;
					histoRGB[G] += 1;
					histoRGB[B] += 1;
				}

			for (int i = 0; i < 256; i++) histoRGB[i] /= 3;

			DrawHisto(ref bmpL, histoLum);
			DrawHisto(ref bmpR, histoR);
			DrawHisto(ref bmpG, histoG);
			DrawHisto(ref bmpB, histoB);
			DrawHisto(ref bmpRGB, histoRGB);
		}

		private static void DrawHisto(ref Bitmap histo_bmp, int[] histo) {
			/* Построение гистограммы 
			 * ------------------------
			 * находим максимальное значение в массиве
			 * и рисуем линии от 0 до 255 на изображении
			 * учитывая высоту столбиков относительно максимального значения
			 */

			Graphics g = Graphics.FromImage(histo_bmp);

			g.Clear(Color.FromArgb(28, 28, 28));

			float max_value = 0;
			foreach (var value in histo) max_value = Math.Max(max_value, value);

			if (max_value == 0) return;

			for (int i = 0; i < 256; i++)
				g.DrawLine(new Pen(Color.White), i, histo_bmp.Height, i, histo_bmp.Height - (int)(histo[i] / max_value * histo_bmp.Height));
		}
	}
}
