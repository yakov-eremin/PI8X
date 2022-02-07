using System;
using System.Windows.Forms;
using DummyPhotoshop.Data;
using DummyPhotoshop.Filters;

namespace DummyPhotoshop.Windows
{
    public partial class GaussianDenoiseWindow : Form
    {
        private IPhoto _photo;
        private GaussianDenoiseFilter _gaussianFilter;
        private MainWindow _mainWindow;
        private double _varianceMultiplier = 0.01;
        private double _maxVariance = 8;
        public GaussianDenoiseWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _photo = mainWindow.Photo;
            _gaussianFilter = new GaussianDenoiseFilter();
            _mainWindow = mainWindow;
            radiusTrackbar.Minimum = 0;
            radiusTrackbar.Maximum = 10;
            radiusTrackbar.Value = 0;
            radiusTrackbar.LargeChange = 1;
            varianceTrackbar.Minimum = 1;
            varianceTrackbar.Maximum = (int)(_maxVariance / _varianceMultiplier);
            varianceTrackbar.Value = 400;

            varianceTextBox.Text = varianceTrackbar.Value.ToString();
            radiusTextBox.Text = radiusTrackbar.Value.ToString();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void UpdatePhoto()
        {
            _gaussianFilter.Variance = varianceTrackbar.Value * _varianceMultiplier;
            _gaussianFilter.Radius = radiusTrackbar.Value;
            var resPhoto = _gaussianFilter.ProcessImage(_photo);
            _mainWindow.SetPhoto(resPhoto);
        }
        private void variationTrackbar_ValueChanged(object sender, EventArgs e)
        {
            varianceTextBox.Text = varianceTrackbar.Value.ToString();
            UpdatePhoto();
        }

        private void radiusTrackbar_ValueChanged(object sender, EventArgs e)
        {
            radiusTextBox.Text = radiusTrackbar.Value.ToString();
            UpdatePhoto();
        }

        private void GaussianDenoiseWindow_Load(object sender, EventArgs e)
        {
            UpdatePhoto();
        }
    }
}
