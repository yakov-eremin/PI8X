using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Lose : Form
    {
        public Lose()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PlayAgain_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void Lose_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
