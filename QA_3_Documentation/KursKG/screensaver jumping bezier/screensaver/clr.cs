namespace screensaver
{
    /// <summary>
    /// Класс цветов для изображения.
    /// </summary>
    /// <remarks>Получаем цвета и изменяем их</remarks>
    class clr
    {

        private int r;
        private int g;
        private int b;
        bool changeRRight = true;
        bool changeGRight = true;
        bool changeBRight = true;
        public clr(int rn, int gn, int bn)
        {
            r = rn; g = gn; b = bn;
        }
        public int getR() { return r; }
        public int getG() { return g; }
        public int getB() { return b; }
        public void setR(int rn) { r = rn; }
        public void setG(int gn) { g = gn; }
        public void setB(int bn) { b = bn; }
        public void changeClr()
        {
            if (changeRRight) r += 2; else r -= 2;
            if (r < 0) { changeRRight = true; r = 0; }
            else if (r > 255) { changeRRight = false; r = 255; }
            
            if (changeGRight) g += 2; else g -= 2;
            if (g < 0) { changeGRight = true; g = 0; }
            else if (g > 255) { changeGRight = false; g = 255; }
            
            if (changeBRight) b += 2; else b -= 2;
            if (b < 0) { changeBRight = true; b = 0; }
            else if (b > 255) { changeBRight = false; b = 255; }
        }
    }
}
