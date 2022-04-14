// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com


using System;
using System.Drawing;
using System.Collections.Generic;


namespace PhotoCorrection {
	class BrightnessContrast {

        public static void Brigtness(Bitmap original, ref Bitmap modified, float coef) {
            /* Изменение яркости 
             * ------------------
             * для каждого пикселя изображения, для каждой его компоненты
             * вычисляем новое значение, как 
             * разница старого значения компоненты и коэфициента;
             * также следим за переполнением: 
             * 0 <= новое значение компоненты <= 255
             */

            for (int y = 0; y < original.Height; y++)
                for (int x = 0; x < original.Width; x++) {

                    Color pix = original.GetPixel(x, y);
                    int R = pix.R, G = pix.G, B = pix.B, A = pix.A;

                    int red = (int)(R + coef);
                    red = Math.Min(255, Math.Max(0, red));

                    int green = (int)(G + coef);
                    green = Math.Min(255, Math.Max(0, green));

                    int blue = (int)(B + coef);
                    blue = Math.Min(255, Math.Max(0, blue));

                    modified.SetPixel(  x,y, Color.FromArgb(A, red, green, blue));
                }
		}

        public static void Concat()
        {
            string a = "foo" + "bar";
            string b = "foo" + 10;
            a += b;
        }

        public static void Capture(string[] args)
        {
            var actions = new List<Func<int>>();
            int variable = 5;
            while (variable < 5)
            {
                int copy = variable;
                actions.Add(() => copy * 2);
                ++variable;
            }

        }

        public static void Contrast(Bitmap original, ref Bitmap modified, float coef) {
            /* Изменение контрастности 
             * -----------------------
             * 1. считаем усредненное значение яркости для всего изображения
             * 2. после этого для каждого канала каждого пикселя находим 
             * отклонение от усредненного значения, найденного на предыдущем шаге, 
             * и увеличиваем/уменьшаем его на заданный пользователем коэффициент. 
             */

            double avg = 0;

            for (int y = 0; y < original.Height; y++)
                for (int x = 0; x < original.Width; x++) {
                    Color pix = original.GetPixel(x, y);
                    int R = pix.R, G = pix.G, B = pix.B;

                    avg += 0.299 * R + 0.587 * G + 0.114 * B;
                }

            avg /= (original.Width * original.Height);

            const int RANGE_COLOR = 256;
            int[] palette = new int[RANGE_COLOR];

            for (int i = 0; i < RANGE_COLOR; i++) {
                int temp = (int)(avg + coef * (i - avg));

                if (temp < 0) { temp = 0; } else { if (temp > RANGE_COLOR - 1) { temp = 255; } }
                palette[i] = temp;
            }

            for (int y = 0; y < original.Height; y++)
                for (int x = 0; x < original.Width; x++) {

                    Color pix = original.GetPixel(x, y);
                    int R = pix.R, G = pix.G, B = pix.B, A = pix.A;

                    modified.SetPixel(x, y, Color.FromArgb(A, palette[R], palette[G], palette[B]));
                }
        }
	}
}
