namespace WindowsFormsApp2
{
    partial class PlayerIcon
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
            this.healthSphere = new WindowsFormsApp2.SphereAndText();
            this.ManaSphere = new WindowsFormsApp2.SphereAndText();
            this.status = new System.Windows.Forms.PictureBox();
            this.bumpImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bumpImage)).BeginInit();
            this.SuspendLayout();
            // 
            // healthSphere
            // 
            this.healthSphere.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.healthSphere.BackColor = System.Drawing.Color.Transparent;
            this.healthSphere.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.healthSq;
            this.healthSphere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.healthSphere.ForeColor = System.Drawing.SystemColors.ControlText;
            this.healthSphere.Location = new System.Drawing.Point(156, 122);
            this.healthSphere.MaximumSize = new System.Drawing.Size(30, 30);
            this.healthSphere.Name = "healthSphere";
            this.healthSphere.Size = new System.Drawing.Size(30, 30);
            this.healthSphere.TabIndex = 1;
            // 
            // ManaSphere
            // 
            this.ManaSphere.BackColor = System.Drawing.Color.Transparent;
            this.ManaSphere.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.manaSq;
            this.ManaSphere.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ManaSphere.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ManaSphere.Location = new System.Drawing.Point(0, 122);
            this.ManaSphere.MaximumSize = new System.Drawing.Size(30, 30);
            this.ManaSphere.Name = "ManaSphere";
            this.ManaSphere.Size = new System.Drawing.Size(30, 30);
            this.ManaSphere.TabIndex = 0;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(30, 144);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(126, 8);
            this.status.TabIndex = 2;
            this.status.TabStop = false;
            // 
            // bumpImage
            // 
            this.bumpImage.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.bump;
            this.bumpImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bumpImage.Location = new System.Drawing.Point(19, 11);
            this.bumpImage.Name = "bumpImage";
            this.bumpImage.Size = new System.Drawing.Size(147, 105);
            this.bumpImage.TabIndex = 3;
            this.bumpImage.TabStop = false;
            this.bumpImage.Visible = false;
            // 
            // PlayerIcon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.Player2Icon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.bumpImage);
            this.Controls.Add(this.status);
            this.Controls.Add(this.healthSphere);
            this.Controls.Add(this.ManaSphere);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(186, 152);
            this.Name = "PlayerIcon";
            this.Size = new System.Drawing.Size(186, 152);
            ((System.ComponentModel.ISupportInitialize)(this.status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bumpImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public SphereAndText ManaSphere;
        public SphereAndText healthSphere;
        public System.Windows.Forms.PictureBox status;
        public System.Windows.Forms.PictureBox bumpImage;
    }
}
