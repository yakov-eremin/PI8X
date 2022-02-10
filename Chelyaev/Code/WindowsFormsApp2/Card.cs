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
    
    public partial class Card : UserControl
    {
        //private String a = "Kury";
        //bool isDown = false;
        protected Form1 frm;
        public bool isFirstsPlayerCard;
        public bool isCardOnTable = false;
        public bool isCanBeat = false;
        
        protected int manaCost;
        public int ManaCost
        {
            get { return manaCost; }
            set
            {
                if (value < 0) manaCost = 0;
                else manaCost = value;
            }
        }
        public string name;
       
        public Card()
        {

        }

        public void ShowElem()
        {
            InitializeComponent();
            object obj = Properties.Resources.ResourceManager.GetObject(name);
            CardImage.Image = ((System.Drawing.Bitmap)(obj));
            CardName.Text = name;
            Showother();
        }
        
        public virtual void Showother()
        {

        }
        public virtual void bump(Entity bumpedCard)
        {
           
        }
        

            //для любой карточки устанавливается картинка и название
        public Card(Form1 frmm, string name, bool firstPlayer)
        {
            
            frm = frmm;
            this.name = name;
            isFirstsPlayerCard = firstPlayer;
            if (firstPlayer)
            {
                InitializeComponent();
                //соответствующая картинка
                object obj = Properties.Resources.ResourceManager.GetObject(name);
                CardImage.Image = ((System.Drawing.Bitmap)(obj));
                CardName.Text = name;
            }
            
        }
        
      
        //если на карточку нажали 
        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.isFirstsPlayerCard)
            {
                if (!frm.isChoosen)
                {
                    frm.CardClicked(this);
                    this.status.BackColor = Color.Yellow;
                }
                else
                {
                    this.status.BackColor = Color.Transparent;
                    frm.CardClicked(this);
                }
            }
            else frm.CardClicked(this);
        }

        public virtual void AddCardOnBattleField()
        {
            
        }
        public virtual void BattleCry()
        {

        }
        public void isCurrent(bool currentNow)
        {
            if (currentNow) this.status.BackColor = Color.Yellow;
            else this.status.BackColor = Color.Transparent;
        }

        public void isAvailable(bool show)
        {
            if (show) this.status.BackColor = Color.Green;
            else this.status.BackColor = Color.Transparent;
        }

        private void description_Click(object sender, EventArgs e)
        {
            Card_MouseDown(sender, (MouseEventArgs)e);
        }

        private void CardName_Click(object sender, EventArgs e)
        {
            Card_MouseDown(sender, (MouseEventArgs)e);
        }

        private void Card_Load(object sender, EventArgs e)
        {

        }
    }
    
}
