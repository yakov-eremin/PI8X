using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace screensaver
{
    /// <summary>
    /// Класс контролера анимации.
    /// </summary>
    /// <remarks>Через каждые двадцать тиков соединяет друг с другом новые точки</remarks>
    class superior_ac
    {
        Timer tmr;
        List<animation_controller> acs;
        PictureBox pb;
        public superior_ac(PictureBox pbn, List<animation_controller> acsn)
        {
            acs = acsn;
            pb = pbn;

            tmr = new Timer();
            tmr.Interval = 20;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
        }

        /// <summary>
        /// Класс таймера.
        /// </summary>
        private void tmr_Tick(object sender, EventArgs e)
        {
            foreach (animation_controller ac in acs)
                ac.move();
            foreach (animation_controller ac in acs)
                ac.glueToTail();
            pb.Invalidate();
        }
    }

}
