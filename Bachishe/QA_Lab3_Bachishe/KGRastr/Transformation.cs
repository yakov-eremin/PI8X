using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KGRastr
{
    /*!
        \brief Статический класс, объединяющий методы для обработки изображений
     */
    static class Rastr
    {
        /*! \defgroup rastr_graphic_module Обработка изображений
    @{
*/
        /*!
        \brief Построить столбчатую диаграмму яркости изображения
        \param image Обрабатываемое изображение
        \param activeArea  Обрабатываемая область изображения
        \return Одномерный массив размером 256. В ячейке по индексу i харнится количество 
        пикселей области, яркость которых равна i 
        */
        private static int[] getBar(TrueBitmap image, Rectangle activeArea)
        {
            int[] bar = new int[256];
            int maxX = activeArea.X + activeArea.Width;
            int maxY = activeArea.Y + activeArea.Height;
            for (int i = activeArea.X; i < maxX; i++)
            {
                for (int j = activeArea.Y; j < maxY; j++)
                {
                    var br = calcBrightness(image.GetPixel(i, j));
                    bar[br]++;
                }
            }
            return bar;
        }
        /*!
       \brief Вычислить среднюю яркость
       \param image Обрабатываемое изображение
       \param activeArea  Обрабатываемая область изображения
       \return Величина средней яркости рассматриваемой области
       */
        public static int calcAverageBrightness(Rectangle activeArea, TrueBitmap image)
        {
            int maxX = activeArea.X + activeArea.Width;
            int maxY = activeArea.Y + activeArea.Height;
            int sum = 0;
            for (int i = activeArea.X; i < maxX; i++)
            {
                for (int j = activeArea.Y; j < maxY; j++)
                {
                    sum += calcBrightness(image.GetPixel(i, j));
                }
            }

            return sum / (activeArea.Height * activeArea.Width);
        }
        /*!
        \brief Вычислить яркость цвета
        \param c Цвет 
        \return Яркость  
     */
        public static int calcBrightness(Color c)
        {
            return (int)(0.299f * c.R + 0.5876 * c.G + 0.114 * c.B);
        }
        /*!
         \brief Отобразить столбчатую диаграмму яркости\n
         Выводит на элемент экрана столбчатую диаграмму яркости, построенную для выделенной области изображения
         \param image Обрабатываемое изображение
         \param activeArea Обрабатываемая область изображения
         \return Величина средней яркости рассматриваемой области
     */
        public static void DrawBar(Graphics gr, TrueBitmap image, Rectangle activeArea)
        {
            var rect = gr.VisibleClipBounds;
            float dy = rect.Height;
            int[] data = getBar(image, activeArea);
            float maxy = data.Max();
            float prevX = 0;
            Brush br = new SolidBrush(Color.Black);
            for (int i = 0; i < data.Length; i++)
            {
                var x = ((float)i + 1) / data.Length * rect.Width;
                var y = (((float)data[i] / maxy) * rect.Height);
                gr.FillRectangle(br, prevX, dy - y, x - prevX, y);
                prevX = x;
            }
            br.Dispose();
        }
    }
    /*!
       \brief Интерфейс для преобразования изображений
    */
    public interface Transformation
    {
        public void ChangeKoeff(double a)
        {
        }

        /*!
          \brief Применить фильтр к цвету
          \param c Исходный цвет 
          \return Цвет после применения фильтра
        */
        public Color Transform(Color c);

        public void PredCalc(TrueBitmap image, Rectangle area)
        {
        }
        /*!
            \brief Последовательно применить фильтр к каждому пикселю выделенной области
            \param image Изменяемое изображение
            \param activeArea Обрабатываемая область изображения
        */
        public void Execute(TrueBitmap image, Rectangle area)
        {
            PredCalc(image, area);
            int maxX = area.X + area.Width;
            int maxY = area.Y + area.Height;
            for (int i = area.X; i < maxX; i++)
            {
                for (int j = area.Y; j < maxY; j++)
                {
                    image.SetPixel(i, j, Transform(image.GetPixel(i, j)));
                }
            }

        }

    }

    /*!
      \brief Фильтр для изменения яркости изображения
      \param image Обрабатываемое изображение
      \param activeArea Обрабатываемая область изображения
      \return Величина средней яркости рассматриваемой области
  */
    public class LightTransformation : Transformation
    {
        //! Величина, на которую будет увеличена яркость (может быть отрицательной)
        private int _delta;

        public void ChangeKoeff(double a)
        {
            _delta = (int)a;
        }
        public LightTransformation(int delta)
        {
            _delta = delta;
        }
        /*!
   \brief Изменить яркость цвета
   \param c Исходный цвет 
   \return Цвет после применения фильтра
 */
        public Color Transform(Color c)
        {
            var a = Math.Clamp(c.R + _delta, 0, 255);
            return Color.FromArgb(Math.Clamp(c.R + _delta, 0, 255),
                Math.Clamp(c.G + _delta, 0, 255),
                Math.Clamp(c.B + _delta, 0, 255));
        }
    }

    /*!
     \brief Фильтр для черно-белой бинаризации изображения
 */
    public class Binarization : ColoredBinarization
    {
      

        public void ChangeKoeff(double a)
        {
            _level = (int)a;
        }
        /*!
        \brief Конструктор фильтра бинаризации
        \param level Порог бинаризации - уровень яркости, по которому бинаризуется изображение
      */
        public Binarization(int level) : base(level, Color.White, Color.Black)
        {
            _level = level;
        }
        /*!
\brief Бинаризировать цвет
\param c Исходный цвет 
\return Цвет после применения фильтра
*/
        public Color Transform(Color c)
        {
            if (Rastr.calcBrightness(c) > _level)
                return Color.White;
            return Color.Black;
        }
    }
    /*!
  \brief Фильтр для бинаризации изображения в произвольных цветах
*/

    public class ColoredBinarization : Transformation
    {
        //! Порог бинаризации - уровень яркости, по которому бинаризуется изображение
        protected int _level;
        //!Цвет точек, яркость которых выше порога бинаризации
        private Color _lightColor;
        //!Цвет точек, яркость которых ниже или равна порогу бинаризации
        private Color _darkColor;
        /*!
         \brief Конструктор фильтра для цветной бинаризации \n
           Данный фильтр определяет новое значение для цвета пикселя по формуле:
        \f[
             newColor(x) = \left\{
            \begin{array}{lr}
            LightColor & \text{if } l(x) > limit,\\
            DarkColor & \text{if } l(x) <= limit. \\
            \end{array}
            \right.\\
        \f]
        
        где:\n
        newColor(x) - новый  цвет,\n
        limit - порог  бинаризации,\n
        x - исходный  цвет  пикселя,\n
        l(x) - яркость  цвета  х,\n
        LightColor - цвет точек, яркость которых выше порога,\n
        DarkColor - цвет точек, яркость которых ниже или равна порогу бинаризации.\n
        Пример работы фильтра (порог бинаризации 168):
        \image html BinExample.png width=50%
         \param level Порог бинаризации
         \param LightColor Цвет точек, яркость которых выше порога
         \param DarkColor Цвет точек, яркость которых ниже или равна порогу бинаризации
        */

        public ColoredBinarization(int level, Color LightColor, Color DarkColor) 
        {
            this._lightColor = LightColor;
            this._darkColor = DarkColor;
        }
        /*!
\brief Бинаризировать цвет
\param c Исходный цвет 
\return Цвет после применения фильтра
*/
        public Color Transform(Color c)
        {
            if (Rastr.calcBrightness(c) > _level)
                return _lightColor;
            return _darkColor;
        }
    }

    /*! @} */
    
}
