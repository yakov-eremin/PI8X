
namespace Logistic
{
    partial class ReferenceBooks
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
            this.label1 = new System.Windows.Forms.Label();
            this.CounteragentsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(115, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Справочники";
            // 
            // CounteragentsButton
            // 
            this.CounteragentsButton.Location = new System.Drawing.Point(-8, 134);
            this.CounteragentsButton.Name = "CounteragentsButton";
            this.CounteragentsButton.Size = new System.Drawing.Size(500, 100);
            this.CounteragentsButton.TabIndex = 1;
            this.CounteragentsButton.Text = "Клиентская база";
            this.CounteragentsButton.UseVisualStyleBackColor = true;
            this.CounteragentsButton.Click += new System.EventHandler(this.CounteragentsButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-8, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(500, 100);
            this.button1.TabIndex = 2;
            this.button1.Text = "Номенклатура товаров";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(-8, 346);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(500, 100);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ReferenceBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 441);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CounteragentsButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ReferenceBooks";
            this.Text = "Справочники";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CounteragentsButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ExitButton;
    }
}