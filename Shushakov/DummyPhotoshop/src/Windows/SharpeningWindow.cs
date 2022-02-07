using System;
using System.Windows.Forms;
using DummyPhotoshop.Data;
using DummyPhotoshop.Filters;

namespace DummyPhotoshop.Windows
{
    public partial class SharpeningWindow : Form
    {
        private IPhoto _photo;
        private SharpeningFilter _filter;
        private MainWindow _mainWindow;
        private double _coefMultiplier = 0.01;
        private double _maxCoef = 25;
        public SharpeningWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _photo = mainWindow.Photo;
            _filter = new SharpeningFilter();
            _mainWindow = mainWindow;
            radiusTrackbar.Minimum = 1;
            radiusTrackbar.Maximum = 10;
            radiusTrackbar.Value = 1;
            radiusTrackbar.LargeChange = 1;
            coefTrackbar.Minimum = 0;
            coefTrackbar.Maximum = (int)(_maxCoef / _coefMultiplier);
            coefTrackbar.Value = 0;
            
            varianceTextBox.Text = coefTrackbar.Value.ToString();
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
            _filter.Coefficient = coefTrackbar.Value * _coefMultiplier;
            _filter.Radius = radiusTrackbar.Value;
            var resPhoto = _filter.ProcessImage(_photo);
            _mainWindow.SetPhoto(resPhoto);
        }

        private void variationTrackbar_ValueChanged(object sender, EventArgs e)
        {
            varianceTextBox.Text = coefTrackbar.Value.ToString();
            UpdatePhoto();
        }

        private void radiusTrackbar_ValueChanged(object sender, EventArgs e)
        {
            radiusTextBox.Text =  radiusTrackbar.Value.ToString();
            UpdatePhoto();
        }

        private void SharpeningWindow_Load(object sender, EventArgs e)
        {
            UpdatePhoto();
        }
    }
}
