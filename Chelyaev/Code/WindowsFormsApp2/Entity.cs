using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Windows.Forms;


namespace WindowsFormsApp2
{
    


    public partial class Entity : Card
    {
        public bool provocation = false;
        protected int damage;        
        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
                if (damage < 0) damage = 0;
                setStats();
            }
        }
        protected int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if(value < health)
                {
                    health = value;
                    setStats();
                    bumpImage.Visible = true;
                    this.Update();
                    Thread.Sleep(400);
                    bumpImage.Visible = false;                    
                    this.Update();
                }
                else
                {
                    health = value;
                    setStats();
                    this.Update();
                }
            }
        }

        public Entity()
        {
            InitializeComponent();
        }

        public Entity(Form1 frm, string name, bool firstPlayer) : base(frm, name, firstPlayer)
        {
            InitializeComponent();
            if(!firstPlayer)
            {
                this.BackgroundImage = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("CardBackPl2");
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.Size = new System.Drawing.Size(135, 195);

                damageSphere.Visible = false;
                healthSphere.Visible = false;
            }

        }
        
        /*protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            // Insert code to do custom painting.  
            // If you want to completely change the appearance of your control,  
            // do not call base.OnPaint(pe).  
        }*/

        public override void bump(Entity bumpedCard)
        {

            bumpedCard.Health -= this.damage;
            this.Health -= bumpedCard.damage;
           
            
            if (bumpedCard.health <= 0)
                frm.deleteCardFromTable(bumpedCard);
            if (this.health <= 0)
                frm.deleteCardFromTable(this);
            
        }
        public override void AddCardOnBattleField()
        {
            if (isFirstsPlayerCard)
            {
                if (frm.player[0].addEntityOnBattleField(this))
                {
                    frm.battleFieldPlayer1.Controls.Add(this);
                    frm.HandPlayer1.Controls.Remove(this);
                    frm.History.Text += "Вы добавили на стол карточку " + this.name + "\r\n"; //                       
                }
                else
                {
                    frm.History.Text += "Недостаточно маны, чтобы добавить " + this.name + " на стол\r\n";
                }
            }
            else
            {
                frm.player[1].addEntityOnBattleField(this);
                frm.battleFieldPlayer2.BackgroundImage = Properties.Resources.add;
                frm.Update();
                Thread.Sleep(700);
                frm.battleFieldPlayer2.Controls.Add(this);
                frm.HandPlayer2.Controls.Remove(this);
                this.ShowElem();
                frm.battleFieldPlayer2.BackgroundImage = null;
                frm.History.Text += "Противник добавил на стол карточку " + this.name + "\r\n";
                Update();
                
            }
        }


        //отобразить элементы, добавленные в энтити и не содержащиеся в кард
        public override void Showother()
        {
            damageSphere.Visible = true;
            healthSphere.Visible = true;            
            setStats();
            SetDescription();
        }
        public virtual void SetDescription()
        {

        }

        //отобразить характеристики на карточке
        protected void setStats()
        {
            sphereAndText1.Amount.Text = Convert.ToString(manaCost);
            damageSphere.Amount.Text = Convert.ToString(damage);
            healthSphere.Amount.Text = Convert.ToString(health);
            if (provocation) Shild.Visible = true;
        }

        private void InitializeComponent()
        {
            this.bumpImage = new System.Windows.Forms.PictureBox();
            this.Shild = new System.Windows.Forms.PictureBox();
            this.healthSphere = new WindowsFormsApp2.SphereAndText();
            this.damageSphere = new WindowsFormsApp2.SphereAndText();
            ((System.ComponentModel.ISupportInitialize)(this.bumpImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shild)).BeginInit();
            this.SuspendLayout();
            // 
            // bumpImage
            // 
            this.bumpImage.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.cardBump;
            this.bumpImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bumpImage.Location = new System.Drawing.Point(70, 161);
            this.bumpImage.Name = "bumpImage";
            this.bumpImage.Size = new System.Drawing.Size(40, 33);
            this.bumpImage.TabIndex = 2;
            this.bumpImage.TabStop = false;
            this.bumpImage.Visible = false;
            // 
            // Shild
            // 
            this.Shild.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.Shild;
            this.Shild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Shild.Location = new System.Drawing.Point(36, 161);
            this.Shild.Name = "Shild";
            this.Shild.Size = new System.Drawing.Size(28, 33);
            this.Shild.TabIndex = 3;
            this.Shild.TabStop = false;
            this.Shild.Visible = false;
            // 
            // healthSphere
            // 
            this.healthSphere.BackColor = System.Drawing.Color.Transparent;
            this.healthSphere.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.health;
            this.healthSphere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.healthSphere.ForeColor = System.Drawing.SystemColors.ControlText;
            this.healthSphere.Location = new System.Drawing.Point(105, 165);
            this.healthSphere.MaximumSize = new System.Drawing.Size(30, 30);
            this.healthSphere.Name = "healthSphere";
            this.healthSphere.Size = new System.Drawing.Size(30, 30);
            this.healthSphere.TabIndex = 1;
            // 
            // damageSphere
            // 
            this.damageSphere.BackColor = System.Drawing.Color.Transparent;
            this.damageSphere.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.damage;
            this.damageSphere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.damageSphere.ForeColor = System.Drawing.SystemColors.ControlText;
            this.damageSphere.Location = new System.Drawing.Point(0, 164);
            this.damageSphere.MaximumSize = new System.Drawing.Size(30, 30);
            this.damageSphere.Name = "damageSphere";
            this.damageSphere.Size = new System.Drawing.Size(30, 30);
            this.damageSphere.TabIndex = 0;
            // 
            // Entity
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.healthSphere);
            this.Controls.Add(this.damageSphere);
            this.Controls.Add(this.Shild);
            this.Controls.Add(this.bumpImage);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Entity";
            this.Size = new System.Drawing.Size(135, 200);
            ((System.ComponentModel.ISupportInitialize)(this.bumpImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shild)).EndInit();
            this.ResumeLayout(false);

        }

        
    }
}
