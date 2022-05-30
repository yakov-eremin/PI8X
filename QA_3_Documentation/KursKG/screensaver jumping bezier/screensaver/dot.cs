namespace screensaver
{
    /// <summary>
    /// Класс точек.
    /// </summary>
    /// <remarks>Создаём тут точки, устанавливаем их скорость</remarks>
    class dot
    {
        private float x;
        private float y;
        private bool anLeft;
        private bool anUp;
        private int speed = 10;
        public dot()
        {
            x = 0; y = 0;
            anLeft = true;
            anUp = true;
        }
        public dot(float xn,float yn)
        {
            x = xn; y = yn;
            anLeft = true;
            anUp = true;
        }
        public float getX() { return x; }
        public float getY() { return y; }
        public void setX(float newx) { x = newx; }
        public void setY(float newy) { y = newy; }

        public void animate(int width, int height)
        {
            /// <summary>
            /// Класс анимации движения точек.
            /// </summary>
            /// <remarks>Здесь точки получают скорость в зависимости от их расположения на экране.</remarks>
            if (anLeft)
                x -= speed;
            else
                x += speed;

            if (anUp)
                y += speed;
            else
                y -= speed;

            if (x < 0)
            {   anLeft = false; x = 0;  }
            else if (x > width)
            {   anLeft = true;  x = width;  }

            if (y < 0)
            {   anUp = true;    y = 0;  }
            else if (y > height)
            {   anUp = false;   y = height; }
        }
    }
}
