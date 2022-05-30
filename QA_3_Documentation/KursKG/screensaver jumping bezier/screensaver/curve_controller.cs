using System.Collections.Generic;

namespace screensaver
{
    /// <summary>
    /// Класс контроллера вращений
    /// </summary>
    /// <remarks>Здесь точки объединяются в массив и полуают координаты центра, чтобы вокруг него уже и происходилоо вращение.</remarks>
    class curve_controller
    {
        List<dot> dotsArray;
        // Массив точек
        public List<dot> getDots()
        {
            return dotsArray;
        }
        public curve_controller()
        {
            dotsArray = new List<dot>();
        }
        public curve_controller(List<dot> dots)
        {
            dotsArray = dots;
        }
        // Добавляем точку
        public void addDot(dot a)
        {
            dotsArray.Add(a);
        }
        //Координаты линии центра
        public line middleline(line ab, line bc, float t)
        {
            dot d, e;
            d = new dot();
            e = new dot();
            d.setX((ab.getB().getX() - ab.getA().getX()) * t + ab.getA().getX());
            d.setY((ab.getB().getY() - ab.getA().getY()) * t + ab.getA().getY());
            e.setX((bc.getB().getX() - bc.getA().getX()) * t + bc.getA().getX());
            e.setY((bc.getB().getY() - bc.getA().getY()) * t + bc.getA().getY());
            return new line(d, e);
        }
        private dot recursive_processing(float t, List<line> lineArray)
        {
            if (lineArray.Count > 1)
            {
                List<line> newlineArray = new List<line>();
                for (int i = 1; i < lineArray.Count; i++)
                    newlineArray.Add(middleline(lineArray[i - 1], lineArray[i], t));
                return recursive_processing(t, newlineArray);
            }
            else
            {
                dot d;
                d = new dot();
                d.setX((lineArray[0].getB().getX() - lineArray[0].getA().getX()) * t + lineArray[0].getA().getX());
                d.setY((lineArray[0].getB().getY() - lineArray[0].getA().getY()) * t + lineArray[0].getA().getY());
                return d;
            }
        }
        public dot tdot(float t)
        {
            List<line> lineArray = new List<line>();
            for (int i = 0; i < dotsArray.Count-1; i++)
                lineArray.Add(new line(dotsArray[i], dotsArray[i+1]));
            return recursive_processing(t, lineArray);
        }
    }
}
