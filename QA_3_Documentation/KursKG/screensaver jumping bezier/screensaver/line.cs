namespace screensaver
{
    /// <summary>
    /// Класс линий.
    /// </summary>
    /// <remarks>Сначала получает координаты двух точек, а затем соединяет в линию.</remarks>
    class line
    {
        private dot a;
        private dot b;
        public void setA(dot newa) { a = newa; }
        public void setB(dot newb) { b = newb; }
        public void setA(float newx, float newy) { a.setX(newx); a.setY(newy); }
        public void setB(float newx, float newy) { b.setX(newx); b.setY(newy); }
        public dot getA() { return a; }
        public dot getB() { return b; }
        public line()
        {
            a = new dot();
            b = new dot();
        }
        public line(dot newa, dot newb)
        {
            a = newa;
            b = newb;
        }
        public line(float newax, float neway, float newbx, float newby)
        {
            a = new dot(newax,neway);
            b = new dot(newbx, newby);
        }
    }
}
