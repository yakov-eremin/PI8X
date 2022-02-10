using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Einstein:Entity
    {
        public Einstein(Form1 frm, string name, bool firstPlayer) : base(frm, name, firstPlayer)
        {
            health = 3;
            damage = 2;
            manaCost = 3;
            isCanBeat = true;
            if (firstPlayer)
            {
                setStats();
                SetDescription();
            }
        }

        public override void SetDescription()
        {
            description.Text = "Рывок";
        }
    }
}
