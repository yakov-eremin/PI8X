using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KG_lab_5
{
    class PhotoRedactor
    {
        readonly int CAPACITY = 256; // константа для значений цветов в формате RGB
        readonly int LAST_COLOR = 255; // для обращения к последнему цвету
        readonly int FIRST_COLOR = 0; // для обращения к первому цвету
        readonly int COMPONENT_COUNT = 3; // число компонент в rgb
        private int _windowSize;
        private int _width;
        private int _height;
        private string _fileName;
        private Bitmap _rawImage; // изображение как оно есть только что загруженное в программу
        private Dictionary<int, int> _brightnessGistogramm; // Для подсчета яркости и построения гистограммы
        private Bitmap _lastStateImage { get; set; } // последнее состояние изображения. Будем сохранять сюда все изменения
        public Bitmap _currentStateImage { get; set; } // буферное изображение. Необходимо для отображения изменений на экране бех потери последнего состояния

        public PhotoRedactor(int windowSize)
        {
            _windowSize = windowSize;
        }

        public PhotoRedactor(string fileName, int windowSize)
        {
            _fileName = fileName;
            _windowSize = windowSize;
        }

        public bool loadFile()
        {
            OpenFileDialog OPF = new OpenFileDialog(); //создание диалогового окна для выбора файла
            OPF.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (OPF.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    _fileName = OPF.FileName;
                    _rawImage = new Bitmap(_fileName);
                    _width = _rawImage.Width;
                    _height = _rawImage.Height;

                    if (_rawImage.Width > _windowSize || _rawImage.Height > _windowSize)
                    {  // если картинка больше окна
                        if (_rawImage.Width >= _rawImage.Height)
                        { // если она шире
                            _width = _windowSize;
                            _height = (int)(_rawImage.Height * ((float)_windowSize / _rawImage.Width));
                        }
                        else
                        {
                            _height = _windowSize;
                            _width = (int)(_rawImage.Width * ((float)_windowSize / _rawImage.Height));
                        }
                    }
                    _currentStateImage = new Bitmap(_rawImage, new Size(_width, _height));
                    applyChanges();
                    return true;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Так дела не делаются, не получилось открыть файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return false;
                }
            }
            return false;
        }

        public Bitmap getImageForPrint()
        {
            return _currentStateImage;
        }

        public int getBrightnessPixel(int width, int height)
        {
            Color color = _lastStateImage.GetPixel(width, height);
            // Ну такие константы можно и захардкодить
            return (int)(0.299 * color.R + 0.5876 * color.G + 0.114 * color.B);
        }

        public void getFragmentSize(ref int LUX, ref int LUY, ref int RBX, ref int RBY)
        {
            // передумал делать
        }

        public Dictionary<int, int> calculateBrightnessGistogramm()
        {
            // Вычисление яркости в каждом пикселе и занесение значений в словарь
            _brightnessGistogramm = new Dictionary<int, int>();
            for (int i = 0; i < CAPACITY; i++)
            {
                _brightnessGistogramm.Add(i, 0);
            }

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _brightnessGistogramm[getBrightnessPixel(i, j)]++;
                }
            }
            return _brightnessGistogramm;
        }

        public void changeBrightness(int value)
        {
            // Изменение яркости на величину value
            Bitmap fuckinBuffer = new Bitmap(_width, _height); // Вообще не понятно, если писать сразу в _currentStateImage, то ничего не работает, а с буфером норм
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    Color source = _lastStateImage.GetPixel(i, j);
                    Color result = createColor(source.R + value, source.G + value, source.B + value);

                    fuckinBuffer.SetPixel(i, j, result);
                }
            }
            _currentStateImage = fuckinBuffer;
        }

        public void changeContrast(int value)
        {
            // Изменение контрастности
            // Ну нет, это же не магические числа
            Bitmap fuckinBuffer = new Bitmap(_width, _height);

            if (value < 0) // Формулы не по учебнику
            { // I = (I • (100 + N) - CAPACITY • N) / 100 
                for (int i = 0; i < _width; i++)
                {
                    for (int j = 0; j < _height; j++)
                    {
                        Color source = _lastStateImage.GetPixel(i, j);
                        Color result = createColor(
                            (source.R * (100 + value) - CAPACITY * value) / 100, 
                            (source.G * (100 + value) - CAPACITY * value) / 100, 
                            (source.B * (100 + value) - CAPACITY * value) / 100);
                        fuckinBuffer.SetPixel(i, j, result);
                    }
                }
            }
            else
            { // I = (I • 100 – CAPACITY • N) / (100 – N)
                for (int i = 0; i < _width; i++)
                {
                    for (int j = 0; j < _height; j++)
                    {
                        Color source = _lastStateImage.GetPixel(i, j);
                        Color result = createColor(
                            (source.R * 100 - CAPACITY * value) / (100 - value), 
                            (source.G * 100 - CAPACITY * value) / (100 - value), 
                            (source.B * 100 - CAPACITY * value) / (100 - value));
                        fuckinBuffer.SetPixel(i, j, result);
                    }
                }
            }
            _currentStateImage = fuckinBuffer;
        }

        public void makeBlackWhiteImage(int value)
        {
            // Получение черно-белого изображения

            Bitmap fuckinBuffer = new Bitmap(_width, _height);

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    Color source = _lastStateImage.GetPixel(i, j);
                    if ((source.R + source.G + source.B) / COMPONENT_COUNT < value) 
                    {
                        fuckinBuffer.SetPixel(i, j, Color.White);
                    }
                    else
                    {
                        fuckinBuffer.SetPixel(i, j, Color.Black);
                    }
                }
            }
            _currentStateImage = fuckinBuffer;
        }

        public void grayScale()
        {
            // Переаодит изображение а градации серого
            Bitmap fuckinBuffer = new Bitmap(_width, _height);

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    int brightness = getBrightnessPixel(i, j);
                    fuckinBuffer.SetPixel(i, j, Color.FromArgb(brightness, brightness, brightness));
                }
            }
            _currentStateImage = fuckinBuffer;
        }

        public void negative()
        {
            // Переводит изображение а негатив

            Bitmap fuckinBuffer = new Bitmap(_width, _height);

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    Color source = _lastStateImage.GetPixel(i, j);
                    fuckinBuffer.SetPixel(i, j, Color.FromArgb(LAST_COLOR - source.R, LAST_COLOR - source.G, LAST_COLOR - source.B));
                }
            }
            _currentStateImage = fuckinBuffer;
        }

        private Color createColor(int newR, int newG, int newB)
        {
            if (newR > LAST_COLOR)
                newR = LAST_COLOR;
            if (newR < FIRST_COLOR)
                newR = FIRST_COLOR;
            if (newG > LAST_COLOR)
                newG = LAST_COLOR;
            if (newG < FIRST_COLOR)
                newG = FIRST_COLOR;
            if (newB > LAST_COLOR)
                newB = LAST_COLOR;
            if (newB < FIRST_COLOR)
                newB = FIRST_COLOR;
            return Color.FromArgb(newR, newG, newB);
        }
        public void applyChanges()
        {
            _lastStateImage = _currentStateImage;
        }

        public void cancelChanges()
        {
            _currentStateImage = _lastStateImage;
        }
    }
}
