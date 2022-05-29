
namespace Logistic
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TreatiesButton = new System.Windows.Forms.Button();
            this.ReferenceBooksButton = new System.Windows.Forms.Button();
            this.OrdersButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TreatiesButton
            // 
            this.TreatiesButton.Location = new System.Drawing.Point(-8, 125);
            this.TreatiesButton.Name = "TreatiesButton";
            this.TreatiesButton.Size = new System.Drawing.Size(500, 100);
            this.TreatiesButton.TabIndex = 0;
            this.TreatiesButton.Text = "Договоры";
            this.TreatiesButton.UseVisualStyleBackColor = true;
            this.TreatiesButton.Click += new System.EventHandler(this.TreatiesButton_Click);
            // 
            // ReferenceBooksButton
            // 
            this.ReferenceBooksButton.Location = new System.Drawing.Point(-8, 337);
            this.ReferenceBooksButton.Name = "ReferenceBooksButton";
            this.ReferenceBooksButton.Size = new System.Drawing.Size(500, 100);
            this.ReferenceBooksButton.TabIndex = 1;
            this.ReferenceBooksButton.Text = "Справочники";
            this.ReferenceBooksButton.UseVisualStyleBackColor = true;
            this.ReferenceBooksButton.Click += new System.EventHandler(this.ReferenceBooksButton_Click);
            // 
            // OrdersButton
            // 
            this.OrdersButton.Location = new System.Drawing.Point(-8, 231);
            this.OrdersButton.Name = "OrdersButton";
            this.OrdersButton.Size = new System.Drawing.Size(500, 100);
            this.OrdersButton.TabIndex = 2;
            this.OrdersButton.Text = "Заявки";
            this.OrdersButton.UseVisualStyleBackColor = true;
            this.OrdersButton.Click += new System.EventHandler(this.OrdersButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(114, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Главное меню";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(-8, 443);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(500, 100);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 539);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrdersButton);
            this.Controls.Add(this.ReferenceBooksButton);
            this.Controls.Add(this.TreatiesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(500, 586);
            this.MinimumSize = new System.Drawing.Size(500, 586);
            this.Name = "MainForm";
            this.Text = "Главная";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TreatiesButton;
        private System.Windows.Forms.Button ReferenceBooksButton;
        private System.Windows.Forms.Button OrdersButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
    }
}

