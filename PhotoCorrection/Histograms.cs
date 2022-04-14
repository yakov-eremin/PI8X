// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com


using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoCorrection {
	public partial class Histograms : Form {

		// массив доступных (формируемых) гистограмм
		private static String[] available_histos = new string[] {
			"Яркость", 
			"RGB", 
			"Красный", 
			"Зеленый", 
			"Синий"
		};

		// массив битмапов для хранения изображений гистограмм
		private static Bitmap[] bmp_histos = new Bitmap[] {
			new Bitmap(256, 300),
			new Bitmap(256, 300),
			new Bitmap(256, 300),
			new Bitmap(256, 300),
			new Bitmap(256, 300)
		};

		MainForm Owner;

		public Histograms(MainForm form) {
			Owner = form;
			// инициализирую компоненты формы
			InitializeComponent();

			// добавляю в выпадающий список наименования гистограмм
			comboBox_histos.Items.AddRange(available_histos);

			UpdateGUI(0);
		}

		public void UpdateGUI(int index) {
			// создаю гистограммы
			BrigthnessHistograms.GetHistograms(
				MainForm.modified_image,
				ref bmp_histos[0],
				ref bmp_histos[1],
				ref bmp_histos[2],
				ref bmp_histos[3],
				ref bmp_histos[4]
			);

			// устанавливаю выбранным гистограмму по нулевому индексу
			// автоматически вызывается функция comboBox_histos_indexChanged

			if (index != -1)
				comboBox_histos.SelectedIndex = index;
			pictureBox_current_histo.Invalidate();
		}

		public void SetTrackBarsZero() {
			trackBar_CyanRed.Value = 0;
			trackBar_MagentaGreen.Value = 0;
			trackBar_YellowBlue.Value = 0;

			UpdateGUI(-1);
		}

		private void comboBox_histos_indexChanged(object sender, EventArgs e) {
			// в pictureBox загружается изображение гистограммы по индексу, выбранного в выпадающем списке
			pictureBox_current_histo.Image = bmp_histos[comboBox_histos.SelectedIndex];
		}

		private void trackBar_CyanRed_Scroll(object sender, EventArgs e) {
			/* Изменение цветового баланса Голубой-Красный изображения на коэфициент. При изменении значения ползунка */
			trackBar_CyanRed.Enabled = false;

			if (MainForm.full_name_of_image != "\0") {
				float coef = 7 * trackBar_CyanRed.Value;

				ColorBalance.ColorBalanceCyanRed(MainForm.original_image, ref MainForm.modified_image, coef);
				Owner.ShowModified(2);
			}

			trackBar_CyanRed.Enabled = true;
		}

		private void trackBar_MagentaGreen_Scroll(object sender, EventArgs e) {
			/* Изменение цветового баланса Пурпурный-Зеленый изображения на коэфициент. При изменении значения ползунка */
			trackBar_MagentaGreen.Enabled = false;

			if (MainForm.full_name_of_image != "\0") {
				float coef = 7 * trackBar_MagentaGreen.Value;

				ColorBalance.ColorBalanceMagentaGreen(MainForm.original_image, ref MainForm.modified_image, coef);
				Owner.ShowModified(3);
			}

			trackBar_MagentaGreen.Enabled = true;
		}

		private void trackBar_YellowBlue_Scroll(object sender, EventArgs e) {
			/* Изменение цветового баланса Желтый-Синий изображения на коэфициент. При изменении значения ползунка */
			trackBar_YellowBlue.Enabled = false;

			if (MainForm.full_name_of_image != "\0") {
				float coef = 7 * trackBar_YellowBlue.Value;

				ColorBalance.ColorBalanceYellowBlue(MainForm.original_image, ref MainForm.modified_image, coef);
				Owner.ShowModified(4);
			}

			trackBar_YellowBlue.Enabled = true;
		}
	}
}
