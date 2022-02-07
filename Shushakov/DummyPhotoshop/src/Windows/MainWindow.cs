using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DummyPhotoshop.Data;
using DummyPhotoshop.Filters;
using DummyPhotoshop.Helpers;
using Photoshop.Filters;

namespace DummyPhotoshop.Windows
{
    public partial class MainWindow : Form
    {
        public IPhoto Photo { get; private set; }
        public Stack<IPhoto> UndoStack, RedoStack;

        private BrightnessHistogram _brightnessHistogram;
        private CropManager _cropManager;

        public MainWindow()
        {
            InitializeComponent();

            canvas.SizeMode = PictureBoxSizeMode.StretchImage;

            SetPhoto(new Photo(canvas.Width, canvas.Height));
            UndoStack = new Stack<IPhoto>();
            RedoStack = new Stack<IPhoto>();
            UndoStack.Push(Photo);
            _brightnessHistogram = new BrightnessHistogram();
            _cropManager = new CropManager();
        }

        public void SetPhoto(IPhoto bitmap)
        {
            Photo = bitmap;
            canvas.Image = bitmap.Bitmap;
            RefreshCanvasAndHistogram();
        }

        public void AddPhotoToUndo(IPhoto photo)
        {
            UndoStack.Push(photo);
            RedoStack.Clear();
        }

        public void Undo()
        {
            if (UndoStack.Count <= 0) return;

            RedoStack.Push(Photo);
            SetPhoto(UndoStack.Peek());
            UndoStack.Pop();
            RefreshCanvasAndHistogram();
        }

        public void Redo()
        {
            if (RedoStack.Count <= 0) return;

            UndoStack.Push(Photo);
            SetPhoto(RedoStack.Peek());
            RedoStack.Pop();
        }

        private void RefreshCanvasAndHistogram()
        {
            canvas.Refresh();
            histogramBox.Refresh();
        }

        private void LoadButtonClicked(object sender, EventArgs e)
        {
            var diag = new OpenFileDialog();
            diag.Filter = @"Files|*.jpg;*.jpeg;*.png";
            if (diag.ShowDialog() != DialogResult.OK) return;

            UndoStack.Clear();
            UndoStack.Push(new Photo(new Bitmap(diag.FileName)));
            SetPhoto(UndoStack.Peek());

        }

        private void OpenFilterWindow(Form window)
        {
            var backup = Photo;
            if (window.ShowDialog() != DialogResult.OK)
                SetPhoto(backup);
            else
                AddPhotoToUndo(backup);
        }

        private void BrightnessContrastButtonClick(object sender, EventArgs e) => OpenFilterWindow(new BrightnessContrastWindow(this));
        private void BinarizationButtonClick(object sender, EventArgs e) => OpenFilterWindow(new BinarizationWindow(this));
        private void NoiseButtonClick(object sender, EventArgs e) => OpenFilterWindow(new AddNoiseWindow(this));
        private void GaussianDenoiseButtonClick(object sender, EventArgs e) => OpenFilterWindow(new GaussianDenoiseWindow(this));
        private void UniformDenoiseButtonClick(object sender, EventArgs e) => OpenFilterWindow(new MaskFilterWindow<UniformDenoiseFilter>(this, "Равномерное шумоподавление"));
        private void MedianDenoiseButtonClick(object sender, EventArgs e) => OpenFilterWindow(new MaskFilterWindow<MedianDenoiseFilter>(this, "Медианное шумоподавление"));
        private void sharpeningButton_Click(object sender, EventArgs e) => OpenFilterWindow(new SharpeningWindow(this));

        private void ApplyFilter(IFilter filter)
        {
            AddPhotoToUndo(Photo);
            SetPhoto(filter.ProcessImage(Photo));
        }

        private void BlackWhiteButtonClick(object sender, EventArgs e) => ApplyFilter(new BlackWhiteFilter());
        private void NegativeButtonClick(object sender, EventArgs e) => ApplyFilter(new NegativeFilter());
        private void embossingButton_Click(object sender, EventArgs e) => ApplyFilter(new EmbossingFilter());


        private Point CanvasPointToPhoto(Point p, int photoHeight, int photoWidth) => new(p.X * photoWidth / canvas.Size.Width, p.Y * photoHeight / canvas.Size.Height);
        private Point PhotoPointToCanvas(Point p, int photoHeight, int photoWidth) => new(p.X * canvas.Size.Width / photoWidth, p.Y * canvas.Size.Height / photoHeight);
        private Rectangle PhotoRectToCanvas(Rectangle rect, int photoHeight, int photoWidth)
            => new(PhotoPointToCanvas(rect.Location, photoHeight, photoWidth), (Size)PhotoPointToCanvas((Point)rect.Size, photoHeight, photoWidth));

        private void CanvasMouseDown(object sender, MouseEventArgs e)
        {
            if (Photo is PhotoCrop photoCrop)
                Photo = photoCrop.CropedPhoto;
            _cropManager.StartCrop((Photo)Photo, CanvasPointToPhoto(e.Location, Photo.Height, Photo.Width));
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (!_cropManager.IsCropping) return;

            _cropManager.Update(CanvasPointToPhoto(e.Location, _cropManager.OriginalPhoto.Height,
                _cropManager.OriginalPhoto.Width));
            Photo = new PhotoCrop(_cropManager.OriginalPhoto, _cropManager.GetCurrentRectangle());
            RefreshCanvasAndHistogram();
        }

        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            if (!_cropManager.IsCropping) return;

            if (_cropManager.IsNothingSelected && Photo is PhotoCrop photoCrop)
            {
                //Is Click
                Photo = photoCrop.CropedPhoto;
            }
            _cropManager.StopCrop();
            RefreshCanvasAndHistogram();
        }

        private void CanvasPaint(object sender, PaintEventArgs e)
        {
            if (Photo is PhotoCrop photoCrop)
                e.Graphics.DrawRectangle(new Pen(Color.Black),
                    PhotoRectToCanvas(photoCrop.Crop, photoCrop.CropedPhoto.Height, photoCrop.CropedPhoto.Width));
        }

        private void RestoreButtonClick(object sender, EventArgs e)
        {
            while (UndoStack.Count > 1)
                UndoStack.Pop();
            if (UndoStack.Count != 0)
                SetPhoto(UndoStack.Peek());
        }

        private void HistogramBoxPaint(object sender, PaintEventArgs e) => _brightnessHistogram.Draw(Photo, e.Graphics);

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && e.Control)
                Undo();
            else if (e.KeyCode == Keys.Y && e.Control)
                Redo();
        }
    }
}
