using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG_lab_5
{
    public partial class Form1 : Form
    {
        readonly int CAPACITY = 256;
        private PhotoRedactor PR;
        public Form1()
        {
            InitializeComponent();
            PR = new PhotoRedactor(pictureBox_main.Width);
            enabledControlElement(false);
        }

        private void enabledControlElement(bool value)
        {
            fragment.Enabled = value;
            deleteImage.Enabled = value;
            applyChangesBrightness.Enabled = value;
            cancelChangesBrightness.Enabled = value;
            grayButton.Enabled = value;
            negative.Enabled = value;
            brightnessGistogrammGroupBox.Enabled = value;
            brightnessGB.Enabled = value;
            contrastGB.Enabled = value;
            BWGB.Enabled = value;
        }

        private void loadImage_Click(object sender, EventArgs e)
        {
            if (PR.loadFile())
            {
                drawImage();
                enabledControlElement(true);
            }
        }

        private void getFragmentSize()
        {
            //ref int LUX, ref int LUY, ref int RBX, ref int RBY
        }

        private void drawImage()
        {
            pictureBox_main.Image = PR.getImageForPrint();
            pictureBox_main.Invalidate();
        }

        private void deleteImage_Click(object sender, EventArgs e)
        {
            pictureBox_main.Image = null;
            pictureBox_main.Invalidate();
            enabledControlElement(false);
        }

        private void calculateBrightnessGistogrammButton_Click(object sender, EventArgs e)
        {
            Dictionary<int, int> gistogramm = PR.calculateBrightnessGistogramm();
            Bitmap brightness = new Bitmap(brightnessPictureBox.Width, brightnessPictureBox.Height);
            Graphics grf = Graphics.FromImage(brightness);
            Pen gistogrammPen = new Pen(Color.Cyan);

            int maxValue = 0;
            for (int i = 0; i < CAPACITY; i++)
            {// находим максимальное значение
                if (gistogramm[i] > maxValue)
                    maxValue = gistogramm[i];
            }


            grf.FillRectangle(Brushes.White, 0, 0, Width, Height);
            for (int i = 0; i < CAPACITY; i++)
            {// рисуем линии
                //grf.DrawLine(gistogrammPen, new Point (0, 0), new Point (100, 100));
                grf.DrawLine(gistogrammPen, new Point(i, brightness.Height), new Point(i, brightness.Height - (int)(((float)brightness.Height / maxValue) * gistogramm[i])));
            }
            brightnessPictureBox.Image = brightness;
            brightnessPictureBox.Refresh();
            GC.Collect();

            maxBrightnessCountLabel.Text = "" + maxValue;

        }

        private void brightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            brightnessValueTB.Text = brightnessTrackBar.Value.ToString();
        }

        private void brightnessValueTB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(brightnessValueTB.Text);
                brightnessTrackBar.Value = value;
                PR.changeBrightness(value);
                drawImage();
            }
            catch
            {
                DialogResult rezult = MessageBox.Show("Так дела не делаются, не получилось изменить яркость",
                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                brightnessTrackBar.Value = 0;
            }
        }

        private void applyChangesBrightness_Click(object sender, EventArgs e)
        {
            PR.applyChanges();
            BWValueTB.Text = "0";
            contrastValueTB.Text = "0";
            brightnessValueTB.Text = "0";
            drawImage();
        }

        private void cancelChangesBrightness_Click(object sender, EventArgs e)
        {
            PR.cancelChanges();
            BWValueTB.Text = "0";
            contrastValueTB.Text = "0";
            brightnessValueTB.Text = "0";
            drawImage();
        }

        private void contrastTrackBar_Scroll(object sender, EventArgs e)
        {
            contrastValueTB.Text = contrastTrackBar.Value.ToString();
        }

        private void contrastValueTB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(contrastValueTB.Text);
                contrastTrackBar.Value = value;
                value = value * 100 / 101; // ну да, захардкодил, и что с того???
                PR.changeContrast(value);
                drawImage();
            }
            catch
            {
                DialogResult rezult = MessageBox.Show("Так дела не делаются, не получилось изменить контрастность",
                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contrastTrackBar.Value = 0;
            }
        }

        private void BWTrackBar_Scroll(object sender, EventArgs e)
        {
            BWValueTB.Text = BWTrackBar.Value.ToString();
        }

        private void BWValueTB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(BWValueTB.Text);
                BWTrackBar.Value = value;
                PR.makeBlackWhiteImage(value);
                drawImage();
            }
            catch
            {
                DialogResult rezult = MessageBox.Show("Так дела не делаются, не получилось преобразовать в ЧБ",
                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                brightnessTrackBar.Value = 0;
            }
        }

        private void grayButton_Click(object sender, EventArgs e)
        {
            PR.grayScale();
            drawImage();
        }

        private void negative_Click(object sender, EventArgs e)
        {
            PR.negative();
            drawImage();
        }
    }
}
