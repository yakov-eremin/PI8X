using System;
using System.Windows.Forms;
using DummyPhotoshop.Data;
using DummyPhotoshop.Filters;

namespace DummyPhotoshop.Windows
{
    public partial class AddNoiseWindow : Form
    {
        private IPhoto _photo;
        private NoiseFilter _noiseFilter;
        private MainWindow _mainWindow;
        private double _noiseMultiplier = 0.01;
        private double _maxNoise = 4;
        public AddNoiseWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _photo = mainWindow.Photo;
            _noiseFilter = new NoiseFilter();
            _mainWindow = mainWindow;
            noiseTrackbar.Value = 0;
            noiseTrackbar.Maximum = (int)(_maxNoise / _noiseMultiplier);
            noiseTextBox.Text = noiseTrackbar.Value.ToString();
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

        private void noiseTrackbar_ValueChanged(object sender, EventArgs e)
        {
            noiseTextBox.Text = noiseTrackbar.Value.ToString();
            _noiseFilter.Percent = noiseTrackbar.Value * _noiseMultiplier;
            var resPhoto = _noiseFilter.ProcessImage(_photo);
            _mainWindow.SetPhoto(resPhoto);
        }

        private void MonocromeCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            _noiseFilter.Monochrome = monocromeCheckBox.Checked;
            var resPhoto = _noiseFilter.ProcessImage(_photo);
            _mainWindow.SetPhoto(resPhoto);
        }
    }
}
