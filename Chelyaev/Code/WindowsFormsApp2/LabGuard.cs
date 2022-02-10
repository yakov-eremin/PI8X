using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class LabGuard : Entity
    {
        public LabGuard(Form1 frm, string name, bool firstPlayer) : base(frm, name, firstPlayer)
        {
            health = 4;
            damage = 2;
            manaCost = 4;
            provocation = true;
            if (firstPlayer)
            {
                setStats();
                description.Text = "Провокация";
            }
            
        }
        public override void SetDescription()
        {
            description.Text = "Провокация";
        }
    }
}
