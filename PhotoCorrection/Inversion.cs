// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com


using System.Drawing;

namespace PhotoCorrection {
	class Inversion {
		public static void Negative(Bitmap original, ref Bitmap modified) {
			/* Переход к негативу 
			 * ------------------
			 * проходим по всем пикселям изображения
			 * берем пиксель, его значения A,R,G,B
			 * записываем на его место значения: 
			 * A, 255 - R, 255 - G, 255 - B
			 * значение A играет роль для PNG файлов
			 */

			for (int y = 0; y < original.Height; y++)
				for (int x = 0; x < original.Width; x++) {

					Color pix = original.GetPixel(x, y);
					int R = pix.R, G = pix.G, B = pix.B, A = pix.A;

					modified.SetPixel(x, y, Color.FromArgb(A, 255 - R, 255 - G, 255 - B));
				}
		}
	}
}
