namespace WindowsFormsApp2
{
    partial class Card
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Card));
            this.CardImage = new System.Windows.Forms.PictureBox();
            this.CardName = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.PictureBox();
            this.description = new System.Windows.Forms.Label();
            this.sphereAndText1 = new WindowsFormsApp2.SphereAndText();
            ((System.ComponentModel.ISupportInitialize)(this.CardImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.status)).BeginInit();
            this.SuspendLayout();
            // 
            // CardImage
            // 
            this.CardImage.Enabled = false;
            this.CardImage.Location = new System.Drawing.Point(18, 30);
            this.CardImage.Name = "CardImage";
            this.CardImage.Size = new System.Drawing.Size(100, 75);
            this.CardImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CardImage.TabIndex = 0;
            this.CardImage.TabStop = false;
            // 
            // CardName
            // 
            this.CardName.Font = new System.Drawing.Font("Felix Titling", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CardName.Location = new System.Drawing.Point(15, 106);
            this.CardName.MaximumSize = new System.Drawing.Size(110, 0);
            this.CardName.Name = "CardName";
            this.CardName.Size = new System.Drawing.Size(110, 18);
            this.CardName.TabIndex = 1;
            this.CardName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CardName.Click += new System.EventHandler(this.CardName_Click);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(18, 23);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(100, 7);
            this.status.TabIndex = 2;
            this.status.TabStop = false;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(13, 127);
            this.description.MaximumSize = new System.Drawing.Size(110, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(110, 22);
            this.description.TabIndex = 4;
            this.description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.description.Click += new System.EventHandler(this.description_Click);
            // 
            // sphereAndText1
            // 
            this.sphereAndText1.BackColor = System.Drawing.Color.Transparent;
            this.sphereAndText1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sphereAndText1.BackgroundImage")));
            this.sphereAndText1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sphereAndText1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sphereAndText1.Location = new System.Drawing.Point(0, -1);
            this.sphereAndText1.Margin = new System.Windows.Forms.Padding(2);
            this.sphereAndText1.MaximumSize = new System.Drawing.Size(30, 30);
            this.sphereAndText1.Name = "sphereAndText1";
            this.sphereAndText1.Size = new System.Drawing.Size(30, 30);
            this.sphereAndText1.TabIndex = 3;
            // 
            // Card
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.CardBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.sphereAndText1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.CardName);
            this.Controls.Add(this.CardImage);
            this.Controls.Add(this.description);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximumSize = new System.Drawing.Size(135, 200);
            this.Name = "Card";
            this.Size = new System.Drawing.Size(135, 200);
            this.Load += new System.EventHandler(this.Card_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Card_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.CardImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.status)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox CardImage;
        private System.Windows.Forms.PictureBox status;
        protected SphereAndText sphereAndText1;
        protected System.Windows.Forms.Label description;
        protected System.Windows.Forms.Label CardName;
    }
}
