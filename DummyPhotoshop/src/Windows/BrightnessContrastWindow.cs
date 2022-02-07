using System;
using System.Globalization;
using System.Windows.Forms;
using DummyPhotoshop.Data;
using DummyPhotoshop.Filters;

namespace DummyPhotoshop.Windows
{
    public partial class BrightnessContrastWindow : Form
    {
        private IPhoto _photo;
        private BrightnessFilter _brightnessFilter;
        private ContrastFilter _contrastFilter;
        private MainWindow _mainWindow;
        private double _contrastMultiplier = 0.01;
        private double _maxContrast = 5;

        private bool _isModifiedBrightness = true;
        private IPhoto _brightnessPhoto;
        public BrightnessContrastWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _photo = mainWindow.Photo;
            _brightnessFilter = new BrightnessFilter();
            _contrastFilter = new ContrastFilter();
            contrastTrackbar.Minimum = 0;
            contrastTrackbar.Maximum = (int)(_maxContrast / _contrastMultiplier);
            contrastTrackbar.Value = (int)(1 / _contrastMultiplier);

            brightnessTextBox.Text = brightnessTrackbar.Value.ToString();
            contrastTextBox.Text = GetCurrentContrast().ToString(CultureInfo.InvariantCulture);
            _mainWindow = mainWindow;
        }

        private double GetCurrentContrast()
        {
            return contrastTrackbar.Value * _contrastMultiplier;
        }

        private void UpdatePhoto()
        {
            if (_isModifiedBrightness)
                _brightnessPhoto = _brightnessFilter.ProcessImage(_photo);
            _isModifiedBrightness = false;
            var resPhoto = _contrastFilter.ProcessImage(_brightnessPhoto);
            _mainWindow.SetPhoto(resPhoto);
        }
        private void brightnessTrackbar_ValueChanged(object sender, EventArgs e)
        {
            brightnessTextBox.Text = brightnessTrackbar.Value.ToString();
            _brightnessFilter.Coefficient = brightnessTrackbar.Value;
            _isModifiedBrightness = true;
            UpdatePhoto();
        }
        private void contrastTrackbar_ValueChanged(object sender, EventArgs e)
        {
            contrastTextBox.Text = GetCurrentContrast().ToString(CultureInfo.InvariantCulture);
            _contrastFilter.Coefficient = GetCurrentContrast();
            UpdatePhoto();
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

   
    }
}
