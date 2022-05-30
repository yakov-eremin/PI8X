using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace screensaver
{
    /// <summary>
    /// Класс отрисовки анимации.
    /// </summary>
    class animation_controller
    {
        PictureBox pb;
        curve_controller cc;
        List<clr> colors;
        animation_controller next;
        /// <summary>
        /// Получаем точки.
        /// </summary>
        public List<dot> getDots()
        {
            return cc.getDots();
        }

        // Соединяем точки
        
        public void glueToNext(animation_controller nextn)
        {
            next = nextn;
        }

        // Присваиваем цвета и инициализируем PictureBox
        public animation_controller(PictureBox pbn, List<clr> clrs)
        {
            colors = clrs;
            pb = pbn;

            cc = new curve_controller();
            
            pb.Paint += new PaintEventHandler(pb_Paint);            
        }
        // Соединяем точки с хвостовой
        public void glueToTail()
        {
            cc.getDots()[0].setX(next.getDots()[next.getDots().Count - 1].getX());
            cc.getDots()[0].setY(next.getDots()[next.getDots().Count - 1].getY());
        }
        public void addDot(int x, int y)
        {
            cc.addDot(new dot(x,y));
        }
        public void move()
        {
            for (int i = 1; i < cc.getDots().Count; i++)
                cc.getDots()[i].animate(pb.Size.Width, pb.Size.Height);
        }
        // Рисуем точки
        private void pb_Paint(object sender, PaintEventArgs e)
        {            
            int count = 0;
            for (float i = 0; i <= 1; i += 0.001f)
            {
                dot d = cc.tdot(i);
                e.Graphics.DrawEllipse(new Pen( Color.FromArgb(255,colors[count].getR(), colors[count].getG(), colors[count].getB())), d.getX(), d.getY(), 1, 1);
                count++;
                if (count >= colors.Count)
                    count = 0;
            }
            foreach(dot d in getDots())
                e.Graphics.DrawEllipse(new Pen(Color.White), d.getX(), d.getY(), 1, 1);
            foreach (clr color in colors)
                color.changeClr();
        }
    }
}
