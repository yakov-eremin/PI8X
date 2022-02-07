using System.ComponentModel;

namespace OtdelZasel
{
    partial class RegForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.Surname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FatherName = new System.Windows.Forms.TextBox();
            this.signUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(58, 178);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(69, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Логин";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(136, 178);
            this.password.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(224, 23);
            this.password.TabIndex = 16;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(136, 148);
            this.login.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(224, 23);
            this.login.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(73, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Имя";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(52, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Фамилия";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(136, 88);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(224, 23);
            this.NameTextBox.TabIndex = 11;
            // 
            // Surname
            // 
            this.Surname.Location = new System.Drawing.Point(136, 58);
            this.Surname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Surname.Name = "Surname";
            this.Surname.Size = new System.Drawing.Size(224, 23);
            this.Surname.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(52, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Отчество";
            // 
            // FatherName
            // 
            this.FatherName.Location = new System.Drawing.Point(136, 118);
            this.FatherName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FatherName.Name = "FatherName";
            this.FatherName.Size = new System.Drawing.Size(224, 23);
            this.FatherName.TabIndex = 14;
            // 
            // signUp
            // 
            this.signUp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.signUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.signUp.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.signUp.Location = new System.Drawing.Point(136, 243);
            this.signUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.signUp.Name = "signUp";
            this.signUp.Size = new System.Drawing.Size(224, 62);
            this.signUp.TabIndex = 17;
            this.signUp.Text = "Зарегистрироваться";
            this.signUp.UseVisualStyleBackColor = true;
            this.signUp.Click += new System.EventHandler(this.signUp_Click);
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 360);
            this.Controls.Add(this.signUp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FatherName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.Surname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RegForm";
            this.Text = "Регистрация нового гражданина";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button signUp;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox FatherName;

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox Surname;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;

        #endregion
    }
}