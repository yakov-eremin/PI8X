﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class DamageSpell3 : Spell
    {
        public DamageSpell3(Form1 frm, string name, bool isFirstPlayer) : base(frm, name, isFirstPlayer)
        {
            manaCost = 5;
            if (isFirstPlayer)
            {
                setStats();
                CardName.Font = new System.Drawing.Font("Algerian", 10);
                description.Text = "+3 урона всем карточкам";
            }


        }

        public override void BattleCry()
        {
            if (isFirstsPlayerCard)
            {
                foreach (Card c in frm.battleFieldPlayer1.Controls)
                {
                    ((Entity)c).Damage += 3;
                }
            }
            else
            {
                foreach (Card c in frm.battleFieldPlayer2.Controls)
                {
                    ((Entity)c).Damage += 3;
                }
            }
        }
    }
}
