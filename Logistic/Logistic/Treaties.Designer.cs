
namespace Logistic
{
    partial class Treaties
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
            this.CreateTreatieButton = new System.Windows.Forms.Button();
            this.TreatieRegistryButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateTreatieButton
            // 
            this.CreateTreatieButton.Location = new System.Drawing.Point(-10, 118);
            this.CreateTreatieButton.Name = "CreateTreatieButton";
            this.CreateTreatieButton.Size = new System.Drawing.Size(500, 100);
            this.CreateTreatieButton.TabIndex = 0;
            this.CreateTreatieButton.Text = "Создать новый договор";
            this.CreateTreatieButton.UseVisualStyleBackColor = true;
            this.CreateTreatieButton.Click += new System.EventHandler(this.CreateTreatieButton_Click);
            // 
            // TreatieRegistryButton
            // 
            this.TreatieRegistryButton.Location = new System.Drawing.Point(-10, 224);
            this.TreatieRegistryButton.Name = "TreatieRegistryButton";
            this.TreatieRegistryButton.Size = new System.Drawing.Size(500, 100);
            this.TreatieRegistryButton.TabIndex = 2;
            this.TreatieRegistryButton.Text = "Реестр договоров";
            this.TreatieRegistryButton.UseVisualStyleBackColor = true;
            this.TreatieRegistryButton.Click += new System.EventHandler(this.TreatieRegistryButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(-10, 330);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(500, 100);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(65, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 46);
            this.label1.TabIndex = 6;
            this.label1.Text = "Работа с договорами";
            // 
            // Treaties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 427);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.TreatieRegistryButton);
            this.Controls.Add(this.CreateTreatieButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Treaties";
            this.Text = "Договоры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateTreatieButton;
        private System.Windows.Forms.Button TreatieRegistryButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label1;
    }
}