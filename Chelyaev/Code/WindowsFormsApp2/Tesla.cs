using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Tesla: Entity
    {
        public Tesla(Form1 frm, string name, bool firstPlayer) : base(frm, name, firstPlayer)
        {
            health = 8;
            damage = 6;
            manaCost = 9;
            provocation = true;
            if (firstPlayer)
            {
                setStats();
                SetDescription();
            }
        }

        public override void SetDescription()
        {
            description.Text = "Провокация";
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Tesla
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Name = "Tesla";
            this.ResumeLayout(false);

        }
    }
}
