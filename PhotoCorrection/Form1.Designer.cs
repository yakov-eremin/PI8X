// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com


namespace PhotoCorrection {
	partial class MainForm {
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
            this.pictureBox_original = new System.Windows.Forms.PictureBox();
            this.label_original_image = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.File_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsFile_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OriginalRecover_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_modified_image = new System.Windows.Forms.Label();
            this.pictureBox_modified = new System.Windows.Forms.PictureBox();
            this.trackBar_brightness = new System.Windows.Forms.TrackBar();
            this.label_brightness = new System.Windows.Forms.Label();
            this.label_contrast = new System.Windows.Forms.Label();
            this.trackBar_contrast = new System.Windows.Forms.TrackBar();
            this.label_coef_white = new System.Windows.Forms.Label();
            this.UpDown_binarization = new System.Windows.Forms.NumericUpDown();
            this.button_negative = new System.Windows.Forms.Button();
            this.button_grayscale = new System.Windows.Forms.Button();
            this.button_histograms = new System.Windows.Forms.Button();
            this.label_brightness_value = new System.Windows.Forms.Label();
            this.label_contrast_value = new System.Windows.Forms.Label();
            this.label_binarization = new System.Windows.Forms.Label();
            this.button_binarization = new System.Windows.Forms.Button();
            this.button_remember_modified = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_original)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_modified)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_brightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_binarization)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_original
            // 
            this.pictureBox_original.Location = new System.Drawing.Point(12, 48);
            this.pictureBox_original.Name = "pictureBox_original";
            this.pictureBox_original.Size = new System.Drawing.Size(512, 512);
            this.pictureBox_original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_original.TabIndex = 0;
            this.pictureBox_original.TabStop = false;
            // 
            // label_original_image
            // 
            this.label_original_image.AutoSize = true;
            this.label_original_image.ForeColor = System.Drawing.Color.White;
            this.label_original_image.Location = new System.Drawing.Point(12, 24);
            this.label_original_image.Name = "label_original_image";
            this.label_original_image.Size = new System.Drawing.Size(239, 25);
            this.label_original_image.TabIndex = 1;
            this.label_original_image.Text = "Исходное изображение:";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1054, 30);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "Меню";
            // 
            // File_ToolStripMenuItem
            // 
            this.File_ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.File_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile_ToolStripMenuItem,
            this.SaveAsFile_ToolStripMenuItem,
            this.OriginalRecover_ToolStripMenuItem});
            this.File_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.File_ToolStripMenuItem.Name = "File_ToolStripMenuItem";
            this.File_ToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.File_ToolStripMenuItem.Text = "Файл";
            // 
            // OpenFile_ToolStripMenuItem
            // 
            this.OpenFile_ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.OpenFile_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.OpenFile_ToolStripMenuItem.Name = "OpenFile_ToolStripMenuItem";
            this.OpenFile_ToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.OpenFile_ToolStripMenuItem.Text = "Открыть...";
            this.OpenFile_ToolStripMenuItem.Click += new System.EventHandler(this.OpenFile_ToolStripMenuItem_Click);
            // 
            // SaveAsFile_ToolStripMenuItem
            // 
            this.SaveAsFile_ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.SaveAsFile_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.SaveAsFile_ToolStripMenuItem.Name = "SaveAsFile_ToolStripMenuItem";
            this.SaveAsFile_ToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.SaveAsFile_ToolStripMenuItem.Text = "Сохранить как...";
            this.SaveAsFile_ToolStripMenuItem.Click += new System.EventHandler(this.SaveAsFile_ToolStripMenuItem_Click);
            // 
            // OriginalRecover_ToolStripMenuItem
            // 
            this.OriginalRecover_ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.OriginalRecover_ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.OriginalRecover_ToolStripMenuItem.Name = "OriginalRecover_ToolStripMenuItem";
            this.OriginalRecover_ToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.OriginalRecover_ToolStripMenuItem.Text = "Восстановить исходное";
            this.OriginalRecover_ToolStripMenuItem.Click += new System.EventHandler(this.OriginalRecover_ToolStripMenuItem_Click);
            // 
            // label_modified_image
            // 
            this.label_modified_image.AutoSize = true;
            this.label_modified_image.ForeColor = System.Drawing.Color.White;
            this.label_modified_image.Location = new System.Drawing.Point(530, 24);
            this.label_modified_image.Name = "label_modified_image";
            this.label_modified_image.Size = new System.Drawing.Size(338, 25);
            this.label_modified_image.TabIndex = 4;
            this.label_modified_image.Text = "Модифицированное изображение:";
            // 
            // pictureBox_modified
            // 
            this.pictureBox_modified.Location = new System.Drawing.Point(530, 48);
            this.pictureBox_modified.Name = "pictureBox_modified";
            this.pictureBox_modified.Size = new System.Drawing.Size(512, 512);
            this.pictureBox_modified.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_modified.TabIndex = 3;
            this.pictureBox_modified.TabStop = false;
            // 
            // trackBar_brightness
            // 
            this.trackBar_brightness.Location = new System.Drawing.Point(12, 587);
            this.trackBar_brightness.Maximum = 9;
            this.trackBar_brightness.Minimum = -9;
            this.trackBar_brightness.Name = "trackBar_brightness";
            this.trackBar_brightness.Size = new System.Drawing.Size(200, 56);
            this.trackBar_brightness.TabIndex = 5;
            this.trackBar_brightness.Scroll += new System.EventHandler(this.trackBar_brightness_scroll);
            // 
            // label_brightness
            // 
            this.label_brightness.AutoSize = true;
            this.label_brightness.ForeColor = System.Drawing.Color.White;
            this.label_brightness.Location = new System.Drawing.Point(12, 563);
            this.label_brightness.Name = "label_brightness";
            this.label_brightness.Size = new System.Drawing.Size(89, 25);
            this.label_brightness.TabIndex = 6;
            this.label_brightness.Text = "Яркость";
            // 
            // label_contrast
            // 
            this.label_contrast.AutoSize = true;
            this.label_contrast.ForeColor = System.Drawing.Color.White;
            this.label_contrast.Location = new System.Drawing.Point(218, 563);
            this.label_contrast.Name = "label_contrast";
            this.label_contrast.Size = new System.Drawing.Size(155, 25);
            this.label_contrast.TabIndex = 8;
            this.label_contrast.Text = "Контрастность";
            // 
            // trackBar_contrast
            // 
            this.trackBar_contrast.Location = new System.Drawing.Point(218, 587);
            this.trackBar_contrast.Maximum = 9;
            this.trackBar_contrast.Minimum = -5;
            this.trackBar_contrast.Name = "trackBar_contrast";
            this.trackBar_contrast.Size = new System.Drawing.Size(200, 56);
            this.trackBar_contrast.TabIndex = 7;
            this.trackBar_contrast.Scroll += new System.EventHandler(this.trackBar_contrast_scroll);
            // 
            // label_coef_white
            // 
            this.label_coef_white.AutoSize = true;
            this.label_coef_white.ForeColor = System.Drawing.Color.White;
            this.label_coef_white.Location = new System.Drawing.Point(419, 587);
            this.label_coef_white.Name = "label_coef_white";
            this.label_coef_white.Size = new System.Drawing.Size(221, 25);
            this.label_coef_white.TabIndex = 9;
            this.label_coef_white.Text = "Коэффициент белого";
            // 
            // UpDown_binarization
            // 
            this.UpDown_binarization.DecimalPlaces = 2;
            this.UpDown_binarization.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.UpDown_binarization.Location = new System.Drawing.Point(587, 585);
            this.UpDown_binarization.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.UpDown_binarization.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.UpDown_binarization.Name = "UpDown_binarization";
            this.UpDown_binarization.Size = new System.Drawing.Size(75, 30);
            this.UpDown_binarization.TabIndex = 10;
            this.UpDown_binarization.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_negative
            // 
            this.button_negative.Location = new System.Drawing.Point(168, 638);
            this.button_negative.Name = "button_negative";
            this.button_negative.Size = new System.Drawing.Size(150, 30);
            this.button_negative.TabIndex = 11;
            this.button_negative.Text = "Негатив";
            this.button_negative.UseVisualStyleBackColor = true;
            this.button_negative.Click += new System.EventHandler(this.button_negative_Click);
            // 
            // button_grayscale
            // 
            this.button_grayscale.Location = new System.Drawing.Point(12, 638);
            this.button_grayscale.Name = "button_grayscale";
            this.button_grayscale.Size = new System.Drawing.Size(150, 30);
            this.button_grayscale.TabIndex = 12;
            this.button_grayscale.Text = "Отенки серого";
            this.button_grayscale.UseVisualStyleBackColor = true;
            this.button_grayscale.Click += new System.EventHandler(this.button_grayscale_Click);
            // 
            // button_histograms
            // 
            this.button_histograms.Location = new System.Drawing.Point(892, 566);
            this.button_histograms.Name = "button_histograms";
            this.button_histograms.Size = new System.Drawing.Size(150, 30);
            this.button_histograms.TabIndex = 14;
            this.button_histograms.Text = "Гистограммы";
            this.button_histograms.UseVisualStyleBackColor = true;
            this.button_histograms.Click += new System.EventHandler(this.button_histograms_Click);
            // 
            // label_brightness_value
            // 
            this.label_brightness_value.AutoSize = true;
            this.label_brightness_value.ForeColor = System.Drawing.Color.White;
            this.label_brightness_value.Location = new System.Drawing.Point(85, 563);
            this.label_brightness_value.Name = "label_brightness_value";
            this.label_brightness_value.Size = new System.Drawing.Size(23, 25);
            this.label_brightness_value.TabIndex = 15;
            this.label_brightness_value.Text = "0";
            // 
            // label_contrast_value
            // 
            this.label_contrast_value.AutoSize = true;
            this.label_contrast_value.ForeColor = System.Drawing.Color.White;
            this.label_contrast_value.Location = new System.Drawing.Point(339, 563);
            this.label_contrast_value.Name = "label_contrast_value";
            this.label_contrast_value.Size = new System.Drawing.Size(23, 25);
            this.label_contrast_value.TabIndex = 16;
            this.label_contrast_value.Text = "0";
            // 
            // label_binarization
            // 
            this.label_binarization.AutoSize = true;
            this.label_binarization.ForeColor = System.Drawing.Color.White;
            this.label_binarization.Location = new System.Drawing.Point(419, 563);
            this.label_binarization.Name = "label_binarization";
            this.label_binarization.Size = new System.Drawing.Size(133, 25);
            this.label_binarization.TabIndex = 17;
            this.label_binarization.Text = "Бинаризация";
            // 
            // button_binarization
            // 
            this.button_binarization.Location = new System.Drawing.Point(423, 638);
            this.button_binarization.Name = "button_binarization";
            this.button_binarization.Size = new System.Drawing.Size(239, 30);
            this.button_binarization.TabIndex = 18;
            this.button_binarization.Text = "Применить бинаризацию";
            this.button_binarization.UseVisualStyleBackColor = true;
            this.button_binarization.Click += new System.EventHandler(this.button_binarization_Click);
            // 
            // button_remember_modified
            // 
            this.button_remember_modified.Location = new System.Drawing.Point(792, 638);
            this.button_remember_modified.Name = "button_remember_modified";
            this.button_remember_modified.Size = new System.Drawing.Size(250, 30);
            this.button_remember_modified.TabIndex = 19;
            this.button_remember_modified.Text = "Запомнить модификацию";
            this.button_remember_modified.UseVisualStyleBackColor = true;
            this.button_remember_modified.Click += new System.EventHandler(this.button_remember_modified_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1054, 681);
            this.Controls.Add(this.button_remember_modified);
            this.Controls.Add(this.button_binarization);
            this.Controls.Add(this.label_binarization);
            this.Controls.Add(this.label_contrast_value);
            this.Controls.Add(this.label_brightness_value);
            this.Controls.Add(this.button_histograms);
            this.Controls.Add(this.button_grayscale);
            this.Controls.Add(this.button_negative);
            this.Controls.Add(this.UpDown_binarization);
            this.Controls.Add(this.label_coef_white);
            this.Controls.Add(this.label_contrast);
            this.Controls.Add(this.trackBar_contrast);
            this.Controls.Add(this.label_brightness);
            this.Controls.Add(this.trackBar_brightness);
            this.Controls.Add(this.label_modified_image);
            this.Controls.Add(this.pictureBox_modified);
            this.Controls.Add(this.label_original_image);
            this.Controls.Add(this.pictureBox_original);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Фотокоррекция";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_original)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_modified)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_brightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_binarization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox_original;
		private System.Windows.Forms.Label label_original_image;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem File_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenFile_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveAsFile_ToolStripMenuItem;
		private System.Windows.Forms.Label label_modified_image;
		private System.Windows.Forms.PictureBox pictureBox_modified;
		private System.Windows.Forms.TrackBar trackBar_brightness;
		private System.Windows.Forms.Label label_brightness;
		private System.Windows.Forms.Label label_contrast;
		private System.Windows.Forms.TrackBar trackBar_contrast;
		private System.Windows.Forms.Label label_coef_white;
		private System.Windows.Forms.NumericUpDown UpDown_binarization;
		private System.Windows.Forms.Button button_negative;
		private System.Windows.Forms.Button button_grayscale;
		private System.Windows.Forms.Button button_histograms;
		private System.Windows.Forms.Label label_brightness_value;
		private System.Windows.Forms.Label label_contrast_value;
		private System.Windows.Forms.Label label_binarization;
		private System.Windows.Forms.ToolStripMenuItem OriginalRecover_ToolStripMenuItem;
		private System.Windows.Forms.Button button_binarization;
		private System.Windows.Forms.Button button_remember_modified;
	}
}

