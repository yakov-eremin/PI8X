using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace screensaver
{
    /// <summary>
    /// Класс формы для отображения.
    /// </summary>
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<clr> colors = new List<clr>();
            for (int k = 0; k < 255; k+=8)
                for(int i=0;i<255;i++)
                    colors.Add(new clr(i, k,i));

            List<animation_controller> ac = new List<animation_controller>();
            for(int i=0;i< Properties.Settings.Default.QuantLines; i++)
                ac.Add(new animation_controller(pictureBox1, colors));
            foreach (animation_controller a in ac)
                for(int i=0;i< Properties.Settings.Default.QuantDots; i++)
                    a.addDot(rnd.Next() % pictureBox1.Size.Width, rnd.Next() % pictureBox1.Size.Height);

            for (int i=0; i<ac.Count-1;i++)
                ac[i].glueToNext(ac[i+1]);
            ac[ac.Count - 1].glueToNext(ac[0]);
            foreach (animation_controller a in ac)
                a.glueToTail();

            superior_ac sac = new superior_ac(pictureBox1,ac);
        }
        

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
