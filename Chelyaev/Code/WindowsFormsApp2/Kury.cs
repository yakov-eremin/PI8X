using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Kury:Entity
    {
        public Kury(Form1 frm, string name, bool isFirstPlayer) :base(frm, name, isFirstPlayer)
        {
            health = 2;
            damage = 1;
            manaCost = 1;
            if (isFirstPlayer) setStats();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Kury
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "Kury";
            this.ResumeLayout(false);

        }
    }
   
}
