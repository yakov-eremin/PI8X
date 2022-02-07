using System;
using System.Windows.Forms;
using DummyPhotoshop.Data;
using DummyPhotoshop.Filters;

namespace DummyPhotoshop.Windows
{
    public partial class MaskFilterWindow<TFilter> : Form where TFilter: MaskFilter, new()
    {
        private IPhoto _photo;
        private MaskFilter _filter;
        private MainWindow _mainWindow;
        public MaskFilterWindow(MainWindow mainWindow, string title)
        {
            InitializeComponent();
            this.Text = title;
            _photo = mainWindow.Photo;
            _filter = new TFilter();
            _mainWindow = mainWindow;
            radiusTrackbar.Minimum = 0;
            radiusTrackbar.Maximum = 10;
            radiusTrackbar.Value = 0;
            radiusTrackbar.LargeChange = 1;
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

        private void radiusTrackbar_ValueChanged(object sender, EventArgs e)
        {
            radiusTextBox.Text =  radiusTrackbar.Value.ToString();
            _filter.Radius = radiusTrackbar.Value;
            var resPhoto = _filter.ProcessImage(_photo);
            _mainWindow.SetPhoto(resPhoto);
        }
    }
}
