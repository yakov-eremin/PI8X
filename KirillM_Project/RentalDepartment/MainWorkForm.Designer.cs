namespace RentalDepartment
{
    partial class MainWorkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SelectAdministrators = new System.Windows.Forms.Button();
            this.SelectClients = new System.Windows.Forms.Button();
            this.SelectRentalObjects = new System.Windows.Forms.Button();
            this.SelectContracts = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AdminsGB = new System.Windows.Forms.GroupBox();
            this.AddAdministratorBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AddClientBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.AddObjectBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.AdminsGB.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(270, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(518, 335);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SelectAdministrators
            // 
            this.SelectAdministrators.Location = new System.Drawing.Point(270, 74);
            this.SelectAdministrators.Name = "SelectAdministrators";
            this.SelectAdministrators.Size = new System.Drawing.Size(125, 23);
            this.SelectAdministrators.TabIndex = 1;
            this.SelectAdministrators.Text = "Администраторы";
            this.SelectAdministrators.UseVisualStyleBackColor = true;
            this.SelectAdministrators.Click += new System.EventHandler(this.SelectAdministrators_Click);
            // 
            // SelectClients
            // 
            this.SelectClients.Location = new System.Drawing.Point(401, 74);
            this.SelectClients.Name = "SelectClients";
            this.SelectClients.Size = new System.Drawing.Size(125, 23);
            this.SelectClients.TabIndex = 2;
            this.SelectClients.Text = "Клиенты";
            this.SelectClients.UseVisualStyleBackColor = true;
            this.SelectClients.Click += new System.EventHandler(this.SelectClients_Click);
            // 
            // SelectRentalObjects
            // 
            this.SelectRentalObjects.Location = new System.Drawing.Point(532, 74);
            this.SelectRentalObjects.Name = "SelectRentalObjects";
            this.SelectRentalObjects.Size = new System.Drawing.Size(125, 23);
            this.SelectRentalObjects.TabIndex = 3;
            this.SelectRentalObjects.Text = "Объекты";
            this.SelectRentalObjects.UseVisualStyleBackColor = true;
            this.SelectRentalObjects.Click += new System.EventHandler(this.SelectRentalObjects_Click);
            // 
            // SelectContracts
            // 
            this.SelectContracts.Location = new System.Drawing.Point(663, 74);
            this.SelectContracts.Name = "SelectContracts";
            this.SelectContracts.Size = new System.Drawing.Size(125, 23);
            this.SelectContracts.TabIndex = 4;
            this.SelectContracts.Text = "Договора";
            this.SelectContracts.UseVisualStyleBackColor = true;
            this.SelectContracts.Click += new System.EventHandler(this.SelectContracts_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(175, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 335);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Договора";
            this.groupBox1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "Продлить аренду";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminsGB
            // 
            this.AdminsGB.Controls.Add(this.AddAdministratorBtn);
            this.AdminsGB.Location = new System.Drawing.Point(140, 97);
            this.AdminsGB.Name = "AdminsGB";
            this.AdminsGB.Size = new System.Drawing.Size(124, 335);
            this.AdminsGB.TabIndex = 6;
            this.AdminsGB.TabStop = false;
            this.AdminsGB.Text = "Администраторы";
            this.AdminsGB.Visible = false;
            // 
            // AddAdministratorBtn
            // 
            this.AddAdministratorBtn.Location = new System.Drawing.Point(6, 19);
            this.AddAdministratorBtn.Name = "AddAdministratorBtn";
            this.AddAdministratorBtn.Size = new System.Drawing.Size(101, 42);
            this.AddAdministratorBtn.TabIndex = 7;
            this.AddAdministratorBtn.Text = "Добавить администратора";
            this.AddAdministratorBtn.UseVisualStyleBackColor = true;
            this.AddAdministratorBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AddClientBtn);
            this.groupBox3.Location = new System.Drawing.Point(146, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(124, 341);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Клиенты";
            this.groupBox3.Visible = false;
            // 
            // AddClientBtn
            // 
            this.AddClientBtn.Location = new System.Drawing.Point(6, 19);
            this.AddClientBtn.Name = "AddClientBtn";
            this.AddClientBtn.Size = new System.Drawing.Size(101, 42);
            this.AddClientBtn.TabIndex = 7;
            this.AddClientBtn.Text = "Добавить клиента";
            this.AddClientBtn.UseVisualStyleBackColor = true;
            this.AddClientBtn.Click += new System.EventHandler(this.AddClientBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.radioButton4);
            this.groupBox4.Controls.Add(this.radioButton3);
            this.groupBox4.Controls.Add(this.radioButton2);
            this.groupBox4.Controls.Add(this.radioButton1);
            this.groupBox4.Controls.Add(this.AddObjectBtn);
            this.groupBox4.Location = new System.Drawing.Point(12, 103);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(252, 335);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Объекты";
            this.groupBox4.Visible = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(145, 239);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 42);
            this.button4.TabIndex = 13;
            this.button4.Text = "Отдать в ремонт";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(21, 239);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 42);
            this.button3.TabIndex = 12;
            this.button3.Text = "Сделать активным для аренды";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 88);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(101, 17);
            this.radioButton4.TabIndex = 11;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "В пользовании";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(78, 17);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "В ремонте";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(114, 17);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Только активные";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(44, 17);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Все";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // AddObjectBtn
            // 
            this.AddObjectBtn.Location = new System.Drawing.Point(145, 287);
            this.AddObjectBtn.Name = "AddObjectBtn";
            this.AddObjectBtn.Size = new System.Drawing.Size(101, 42);
            this.AddObjectBtn.TabIndex = 7;
            this.AddObjectBtn.Text = "Добавить объект";
            this.AddObjectBtn.UseVisualStyleBackColor = true;
            this.AddObjectBtn.Click += new System.EventHandler(this.AddObjectBtn_Click);
            // 
            // MainWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.AdminsGB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SelectContracts);
            this.Controls.Add(this.SelectRentalObjects);
            this.Controls.Add(this.SelectClients);
            this.Controls.Add(this.SelectAdministrators);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainWorkForm";
            this.Text = "Отдел аренды";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.AdminsGB.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SelectAdministrators;
        private System.Windows.Forms.Button SelectClients;
        private System.Windows.Forms.Button SelectRentalObjects;
        private System.Windows.Forms.Button SelectContracts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox AdminsGB;
        private System.Windows.Forms.Button AddAdministratorBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button AddClientBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button AddObjectBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}