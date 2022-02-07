using System;
using System.Drawing;
using System.Windows.Forms;
using DummyPhotoshop.Data;
using DummyPhotoshop.Filters;

namespace DummyPhotoshop.Windows
{
    public partial class BinarizationWindow : Form
    {
        private IPhoto _photo;
        private BinarizationFilter _binarizationFilter;
        private MainWindow _mainWindow;
        private BrightnessHistogram _brightnessHistogram;
        public BinarizationWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _photo = mainWindow.Photo;
            _binarizationFilter = new BinarizationFilter();
            _brightnessHistogram = new BrightnessHistogram();
            _mainWindow = mainWindow;
            binarizationTrackbar.Value = 125;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
       
        private void binarizationTrackbar_ValueChanged(object sender, EventArgs e)
        {
            _binarizationFilter.Threshold = binarizationTrackbar.Value;
            var resPhoto = _binarizationFilter.ProcessImage(_photo);
            _mainWindow.SetPhoto(resPhoto);
        }

        private void histogramBox_Paint(object sender, PaintEventArgs e)
        {
            _brightnessHistogram.Draw(_photo, e.Graphics);
        }

        private void rightColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _binarizationFilter.RightColor = new MyColor(colorDialog1.Color);
                var resPhoto = _binarizationFilter.ProcessImage(_photo);
                _mainWindow.SetPhoto(resPhoto);
            }
            Refresh();
        }

        private void leftColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _binarizationFilter.LeftColor = new MyColor(colorDialog1.Color);
                var resPhoto = _binarizationFilter.ProcessImage(_photo);
                _mainWindow.SetPhoto(resPhoto);
            }
            Refresh();

        }

        private void rightColorButton_Paint(object sender, PaintEventArgs e)
        {
            rightColorButton.BackColor = _binarizationFilter.RightColor;
        }

        private void leftColorButton_Paint(object sender, PaintEventArgs e)
        {
            leftColorButton.BackColor = _binarizationFilter.LeftColor;
        }

        private void BinarizationWindow_Load(object sender, EventArgs e)
        {
            binarizationTrackbar_ValueChanged(sender, e);
        }
    }
}
