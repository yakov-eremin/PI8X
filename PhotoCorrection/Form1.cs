// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoCorrection {


	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
		}

        public static Bitmap original_image_for_recover;
        public static Bitmap original_image;
        public static Bitmap modified_image;

        public static string full_name_of_image = "\0";

        Histograms HistoForm;

        private void OpenFile_ToolStripMenuItem_Click(object sender, EventArgs e) {
			/* Выбор изображение с помощью диалогового окна */

			OpenFileDialog open_dialog = new OpenFileDialog();
			open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (open_dialog.ShowDialog() == DialogResult.OK) {
                try {
                    full_name_of_image = open_dialog.FileName;

                    original_image = new Bitmap(open_dialog.FileName);
                    modified_image = new Bitmap(open_dialog.FileName);
                    original_image_for_recover = new Bitmap(open_dialog.FileName);

                    this.HistoForm = new Histograms(this);
                    UpdateGUI();
                }
                catch {
                    full_name_of_image = "\0";
                    DialogResult result = MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

		private void SaveAsFile_ToolStripMenuItem_Click(object sender, EventArgs e) {
            /* Сохранение изображения с помощью диалогового окна */
            
            if (full_name_of_image != "\0") {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) {
                    try {
                        modified_image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void OriginalRecover_ToolStripMenuItem_Click(object sender, EventArgs e) {
            /* Восстановить исходное изображение как текущее */
            if (full_name_of_image != "\0") {
                original_image.Dispose();
                modified_image.Dispose();

                original_image = new Bitmap(original_image_for_recover);
                modified_image = new Bitmap(original_image_for_recover);

                UpdateGUI();
            }
		}

        private void UpdateGUI() {
            /* Обновить элементы управления на форме */
            trackBar_brightness.Value = 0;
            trackBar_contrast.Value = 0;

            label_brightness_value.Text = "0";
            label_contrast_value.Text = "0";

            UpDown_binarization.Value = 1;

            HistoForm.SetTrackBarsZero();

            pictureBox_original.Image = original_image;
            pictureBox_modified.Image = modified_image;
        }

        public void ShowModified(int index) {
            pictureBox_modified.Image = modified_image;
            HistoForm.UpdateGUI(index);
        }

        private void TestPVS(object sender, EventArgs e)
        {
            int a = 123;
            int b = 19999;

        }
		private void trackBar_brightness_scroll(object sender, EventArgs e) {
            /* Изменение яркости изображение на коэфициент. При изменении значения ползунка */
            trackBar_brightness.Enabled = false;

            label_brightness_value.Text = trackBar_brightness.Value.ToString();
            
            if (full_name_of_image != "\0") {
                float coef = 7 * trackBar_brightness.Value;

                BrightnessContrast.Brigtness(original_image, ref modified_image, coef);
                ShowModified(-1);
            }

            trackBar_brightness.Enabled = true;
        }

		private void trackBar_contrast_scroll(object sender, EventArgs e) {
            /* Изменение контрастности изображение на коэфициент. При изменении значения ползунка */

            trackBar_contrast.Enabled = false;

            label_contrast_value.Text = trackBar_contrast.Value.ToString();
            
            if (full_name_of_image != "\0") {
                float coef = 1.0f + (trackBar_contrast.Maximum / 100.0f) * trackBar_contrast.Value;
                coef = Math.Max(0.1f, Math.Min(1.9f, coef));

                BrightnessContrast.Contrast(original_image, ref modified_image, coef);
                ShowModified(-1);
            }

            trackBar_contrast.Enabled = true;
        }

		private void button_negative_Click(object sender, EventArgs e) {
            /* Применить фильтр "Негатив" к изображение по нажатию на кнопку */
            if (full_name_of_image != "\0") {
                Inversion.Negative(original_image, ref modified_image);
                ShowModified(-1);
			}
		}

		private void button_grayscale_Click(object sender, EventArgs e) {
            /* Применить фильтр "Оттенки серого" по нажатию на кнопку */
            if (full_name_of_image != "\0") {
                BlackAndWhite.Grayscale(original_image, ref modified_image);
                ShowModified(-1);
            }
        }

		private void button_histograms_Click(object sender, EventArgs e) {
            /* Отобразить форму с гистограммами */
            if (full_name_of_image != "\0") {

                if (HistoForm.Visible) HistoForm.Hide(); else HistoForm.Show();
            }
            else {
                MessageBox.Show("Сначала откройте изображение");
            }
		}

		private void button_binarization_Click(object sender, EventArgs e) {
            /* Применить фильтр "Бинаризация" по нажатию на кнопку */
            UpDown_binarization.Enabled = false;

            if (full_name_of_image != "\0") {

                BlackAndWhite.Binarization(original_image, ref modified_image, (float)UpDown_binarization.Value);

                ShowModified(-1);
            }

            UpDown_binarization.Enabled = true;
        }

		private void button_remember_modified_Click(object sender, EventArgs e) {
            /* Сохранить последнюю модификацию как текущее изображение */
            if (full_name_of_image != "\0") {
                Bitmap temp = new Bitmap(modified_image);

                original_image.Dispose();
                modified_image.Dispose();
                original_image = new Bitmap(temp);
                modified_image = new Bitmap(temp);

                temp.Dispose();

                UpdateGUI();
            }
		}
	
    }
}
