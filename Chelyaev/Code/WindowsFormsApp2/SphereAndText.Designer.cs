namespace WindowsFormsApp2
{
    partial class SphereAndText
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
        private void InitializeComponent()
        {
            this.Amount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Amount
            // 
            this.Amount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Amount.Font = new System.Drawing.Font("Algerian", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount.Location = new System.Drawing.Point(0, 0);
            this.Amount.Margin = new System.Windows.Forms.Padding(0);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(34, 30);
            this.Amount.TabIndex = 0;
            this.Amount.Text = "1";
            this.Amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Amount.TextChanged += new System.EventHandler(this.Amount_TextChanged);
            // 
            // SphereAndText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.manaCost;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.Amount);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximumSize = new System.Drawing.Size(30, 30);
            this.Name = "SphereAndText";
            this.Size = new System.Drawing.Size(30, 30);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Amount;
    }
}
