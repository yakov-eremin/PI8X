using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Spell : Card
    {
        public Spell()
        {
            InitializeComponent();

        }
        public Spell(Form1 frm, string name, bool firstPlayer) : base(frm, name, firstPlayer)
        {
            //InitializeComponent();

            if (!firstPlayer)
            {
                this.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("CardBackPl2");
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.Size = new System.Drawing.Size(135, 195);
            }
            else description.Height = 57;
        }
        public override void Showother()
        {
            setStats();
        }
        public override void AddCardOnBattleField()
        {
            if (isFirstsPlayerCard)
            {
                if (frm.player[0].AddSpellOnBattleField(this))
                {
                    frm.HandPlayer1.Controls.Remove(this);
                    BattleCry();
                    frm.History.Text += "Вы использовали заклинание " + this.name + "\r\n"; //                       
                }
                else
                {
                    frm.History.Text += "Недостаточно маны, чтобы добавить " + this.name + " на стол\r\n";
                }
            }
            else
            {
                if (frm.battleFieldPlayer2.Controls.Count != 0)
                {
                    frm.player[1].AddSpellOnBattleField(this);
                    frm.HandPlayer2.Controls.Remove(this);
                    BattleCry();
                    frm.History.Text += "Противник использовал заклинание " + this.name + "\r\n"; //  
                }
            }
        }

      
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            // Insert code to do custom painting.  
            // If you want to completely change the appearance of your control,  
            // do not call base.OnPaint(pe).  
        }
        protected void setStats()
        {
            sphereAndText1.Amount.Text = Convert.ToString(manaCost);
        }
    }
}
