using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static class Program
    {
       
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form frm = new Form1();
            Application.Run(frm);
            
            /*//Player player1 = new Player();
            frm.AddNewCardToPlayer1();
            Card crd = new Card();
            frm.BackColor = Color.Black;
            frm.BackgroundImage = null;
            MessageBox.Show("a");*/
        }
    }
}
