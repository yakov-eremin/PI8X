namespace WindowsFormsApp2
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Player1Field = new System.Windows.Forms.Panel();
            this.CardDeckPlayer1 = new System.Windows.Forms.PictureBox();
            this.HandPlayer1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Player2Field = new System.Windows.Forms.Panel();
            this.Mute = new System.Windows.Forms.Button();
            this.CardDeckPlayer2 = new System.Windows.Forms.PictureBox();
            this.HandPlayer2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Table = new System.Windows.Forms.Panel();
            this.History = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CoverButton = new System.Windows.Forms.Button();
            this.EndMove = new System.Windows.Forms.Button();
            this.battleFieldPlayer2 = new System.Windows.Forms.FlowLayoutPanel();
            this.battleFieldPlayer1 = new System.Windows.Forms.FlowLayoutPanel();
            this.player1Icon = new WindowsFormsApp2.PlayerIcon();
            this.player2Icon = new WindowsFormsApp2.PlayerIcon();
            this.Player1Field.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardDeckPlayer1)).BeginInit();
            this.Player2Field.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardDeckPlayer2)).BeginInit();
            this.Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Player1Field
            // 
            this.Player1Field.BackColor = System.Drawing.Color.Transparent;
            this.Player1Field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Player1Field.Controls.Add(this.player1Icon);
            this.Player1Field.Controls.Add(this.CardDeckPlayer1);
            this.Player1Field.Controls.Add(this.HandPlayer1);
            this.Player1Field.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Player1Field.Location = new System.Drawing.Point(0, 726);
            this.Player1Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Player1Field.Name = "Player1Field";
            this.Player1Field.Size = new System.Drawing.Size(1781, 227);
            this.Player1Field.TabIndex = 0;
            // 
            // CardDeckPlayer1
            // 
            this.CardDeckPlayer1.Image = global::WindowsFormsApp2.Properties.Resources.CardDeck;
            this.CardDeckPlayer1.Location = new System.Drawing.Point(1597, 6);
            this.CardDeckPlayer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CardDeckPlayer1.Name = "CardDeckPlayer1";
            this.CardDeckPlayer1.Size = new System.Drawing.Size(172, 218);
            this.CardDeckPlayer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CardDeckPlayer1.TabIndex = 1;
            this.CardDeckPlayer1.TabStop = false;
            // 
            // HandPlayer1
            // 
            this.HandPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HandPlayer1.Location = new System.Drawing.Point(201, 14);
            this.HandPlayer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HandPlayer1.Name = "HandPlayer1";
            this.HandPlayer1.Size = new System.Drawing.Size(1375, 200);
            this.HandPlayer1.TabIndex = 0;
            // 
            // Player2Field
            // 
            this.Player2Field.BackColor = System.Drawing.Color.Transparent;
            this.Player2Field.Controls.Add(this.Mute);
            this.Player2Field.Controls.Add(this.player2Icon);
            this.Player2Field.Controls.Add(this.CardDeckPlayer2);
            this.Player2Field.Controls.Add(this.HandPlayer2);
            this.Player2Field.Dock = System.Windows.Forms.DockStyle.Top;
            this.Player2Field.Location = new System.Drawing.Point(0, 0);
            this.Player2Field.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Player2Field.Name = "Player2Field";
            this.Player2Field.Size = new System.Drawing.Size(1781, 220);
            this.Player2Field.TabIndex = 1;
            // 
            // Mute
            // 
            this.Mute.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.PlayMusic;
            this.Mute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Mute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Mute.Location = new System.Drawing.Point(5, 7);
            this.Mute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Mute.Name = "Mute";
            this.Mute.Size = new System.Drawing.Size(40, 39);
            this.Mute.TabIndex = 6;
            this.Mute.UseVisualStyleBackColor = true;
            this.Mute.Click += new System.EventHandler(this.button1_Click);
            // 
            // CardDeckPlayer2
            // 
            this.CardDeckPlayer2.Image = global::WindowsFormsApp2.Properties.Resources.CardDeck;
            this.CardDeckPlayer2.Location = new System.Drawing.Point(1597, 2);
            this.CardDeckPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CardDeckPlayer2.Name = "CardDeckPlayer2";
            this.CardDeckPlayer2.Size = new System.Drawing.Size(172, 218);
            this.CardDeckPlayer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CardDeckPlayer2.TabIndex = 2;
            this.CardDeckPlayer2.TabStop = false;
            // 
            // HandPlayer2
            // 
            this.HandPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HandPlayer2.Location = new System.Drawing.Point(204, 9);
            this.HandPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HandPlayer2.Name = "HandPlayer2";
            this.HandPlayer2.Size = new System.Drawing.Size(1375, 200);
            this.HandPlayer2.TabIndex = 1;
            // 
            // Table
            // 
            this.Table.BackColor = System.Drawing.Color.Transparent;
            this.Table.Controls.Add(this.History);
            this.Table.Controls.Add(this.pictureBox1);
            this.Table.Controls.Add(this.CoverButton);
            this.Table.Controls.Add(this.EndMove);
            this.Table.Controls.Add(this.battleFieldPlayer2);
            this.Table.Controls.Add(this.battleFieldPlayer1);
            this.Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Table.Location = new System.Drawing.Point(0, 220);
            this.Table.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(1781, 506);
            this.Table.TabIndex = 2;
            // 
            // History
            // 
            this.History.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.History.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(115)))));
            this.History.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.History.Font = new System.Drawing.Font("Felix Titling", 8.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.History.Location = new System.Drawing.Point(11, 37);
            this.History.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.History.Multiline = true;
            this.History.Name = "History";
            this.History.ReadOnly = true;
            this.History.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.History.Size = new System.Drawing.Size(183, 150);
            this.History.TabIndex = 4;
            this.History.TextChanged += new System.EventHandler(this.History_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(5, 258);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 224);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // CoverButton
            // 
            this.CoverButton.FlatAppearance.BorderSize = 0;
            this.CoverButton.Location = new System.Drawing.Point(99, 14);
            this.CoverButton.Margin = new System.Windows.Forms.Padding(0);
            this.CoverButton.Name = "CoverButton";
            this.CoverButton.Size = new System.Drawing.Size(97, 23);
            this.CoverButton.TabIndex = 5;
            this.CoverButton.Text = "Uncover";
            this.CoverButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.CoverButton.UseVisualStyleBackColor = true;
            this.CoverButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // EndMove
            // 
            this.EndMove.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.buttonEndMove;
            this.EndMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EndMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EndMove.Location = new System.Drawing.Point(1597, 208);
            this.EndMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EndMove.Name = "EndMove";
            this.EndMove.Size = new System.Drawing.Size(169, 95);
            this.EndMove.TabIndex = 3;
            this.EndMove.UseVisualStyleBackColor = true;
            this.EndMove.Click += new System.EventHandler(this.EndMove_Click);
            this.EndMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.EndMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // battleFieldPlayer2
            // 
            this.battleFieldPlayer2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.battleFieldPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.battleFieldPlayer2.Location = new System.Drawing.Point(201, 25);
            this.battleFieldPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.battleFieldPlayer2.Name = "battleFieldPlayer2";
            this.battleFieldPlayer2.Size = new System.Drawing.Size(1375, 212);
            this.battleFieldPlayer2.TabIndex = 2;
            this.battleFieldPlayer2.WrapContents = false;
            // 
            // battleFieldPlayer1
            // 
            this.battleFieldPlayer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.battleFieldPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.battleFieldPlayer1.Location = new System.Drawing.Point(201, 281);
            this.battleFieldPlayer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.battleFieldPlayer1.Name = "battleFieldPlayer1";
            this.battleFieldPlayer1.Size = new System.Drawing.Size(1375, 200);
            this.battleFieldPlayer1.TabIndex = 1;
            this.battleFieldPlayer1.Click += new System.EventHandler(this.battleFieldPlayer1_Click);
            // 
            // player1Icon
            // 
            this.player1Icon.BackColor = System.Drawing.Color.Transparent;
            this.player1Icon.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.Player1Icon;
            this.player1Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player1Icon.Location = new System.Drawing.Point(11, 14);
            this.player1Icon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.player1Icon.MinimumSize = new System.Drawing.Size(187, 153);
            this.player1Icon.Name = "player1Icon";
            this.player1Icon.Size = new System.Drawing.Size(187, 153);
            this.player1Icon.TabIndex = 4;
            // 
            // player2Icon
            // 
            this.player2Icon.BackColor = System.Drawing.Color.Transparent;
            this.player2Icon.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.Player2Icon;
            this.player2Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player2Icon.Location = new System.Drawing.Point(12, 57);
            this.player2Icon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.player2Icon.MinimumSize = new System.Drawing.Size(187, 153);
            this.player2Icon.Name = "player2Icon";
            this.player2Icon.Size = new System.Drawing.Size(187, 153);
            this.player2Icon.TabIndex = 3;
            this.player2Icon.Click += new System.EventHandler(this.player2Icon_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.FieldBackground;
            this.ClientSize = new System.Drawing.Size(1781, 953);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.Player1Field);
            this.Controls.Add(this.Player2Field);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Player1Field.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CardDeckPlayer1)).EndInit();
            this.Player2Field.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CardDeckPlayer2)).EndInit();
            this.Table.ResumeLayout(false);
            this.Table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Player1Field;
        private System.Windows.Forms.Panel Player2Field;
        private System.Windows.Forms.Panel Table;
        public System.Windows.Forms.FlowLayoutPanel HandPlayer1;
        private System.Windows.Forms.PictureBox CardDeckPlayer1;
        private System.Windows.Forms.PictureBox CardDeckPlayer2;
        private PlayerIcon player2Icon;
        private System.Windows.Forms.Button EndMove;
        private System.Windows.Forms.Button CoverButton;
        public System.Windows.Forms.TextBox History;
        public PlayerIcon player1Icon;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.FlowLayoutPanel battleFieldPlayer1;
        public System.Windows.Forms.FlowLayoutPanel battleFieldPlayer2;
        public System.Windows.Forms.FlowLayoutPanel HandPlayer2;
        private System.Windows.Forms.Button Mute;
    }
}

