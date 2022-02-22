
namespace KG_lab_5
{
    partial class Form1
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
            this.pictureBox_main = new System.Windows.Forms.PictureBox();
            this.loadImage = new System.Windows.Forms.Button();
            this.deleteImage = new System.Windows.Forms.Button();
            this.calculateBrightnessGistogrammButton = new System.Windows.Forms.Button();
            this.brightnessPictureBox = new System.Windows.Forms.PictureBox();
            this.brightnessGistogrammGroupBox = new System.Windows.Forms.GroupBox();
            this.maxBrightnessCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.brightnessGB = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.brightnessValueTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.cancelChangesBrightness = new System.Windows.Forms.Button();
            this.applyChangesBrightness = new System.Windows.Forms.Button();
            this.contrastGB = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.contrastValueTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.BWGB = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.BWValueTB = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.BWTrackBar = new System.Windows.Forms.TrackBar();
            this.grayButton = new System.Windows.Forms.Button();
            this.negative = new System.Windows.Forms.Button();
            this.fragment = new System.Windows.Forms.GroupBox();
            this.rightBottomY = new System.Windows.Forms.NumericUpDown();
            this.rightBottomX = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.leftUpY = new System.Windows.Forms.NumericUpDown();
            this.leftUpX = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessPictureBox)).BeginInit();
            this.brightnessGistogrammGroupBox.SuspendLayout();
            this.brightnessGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
            this.contrastGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            this.BWGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BWTrackBar)).BeginInit();
            this.fragment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightBottomY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBottomX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftUpY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftUpX)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_main
            // 
            this.pictureBox_main.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox_main.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_main.Name = "pictureBox_main";
            this.pictureBox_main.Size = new System.Drawing.Size(720, 720);
            this.pictureBox_main.TabIndex = 2;
            this.pictureBox_main.TabStop = false;
            // 
            // loadImage
            // 
            this.loadImage.Location = new System.Drawing.Point(938, 12);
            this.loadImage.Name = "loadImage";
            this.loadImage.Size = new System.Drawing.Size(131, 23);
            this.loadImage.TabIndex = 3;
            this.loadImage.Text = "Загрузить картинку";
            this.loadImage.UseVisualStyleBackColor = true;
            this.loadImage.Click += new System.EventHandler(this.loadImage_Click);
            // 
            // deleteImage
            // 
            this.deleteImage.Location = new System.Drawing.Point(938, 41);
            this.deleteImage.Name = "deleteImage";
            this.deleteImage.Size = new System.Drawing.Size(131, 23);
            this.deleteImage.TabIndex = 4;
            this.deleteImage.Text = "Удалить картинку";
            this.deleteImage.UseVisualStyleBackColor = true;
            this.deleteImage.Click += new System.EventHandler(this.deleteImage_Click);
            // 
            // calculateBrightnessGistogrammButton
            // 
            this.calculateBrightnessGistogrammButton.Location = new System.Drawing.Point(48, 143);
            this.calculateBrightnessGistogrammButton.Name = "calculateBrightnessGistogrammButton";
            this.calculateBrightnessGistogrammButton.Size = new System.Drawing.Size(255, 23);
            this.calculateBrightnessGistogrammButton.TabIndex = 6;
            this.calculateBrightnessGistogrammButton.Text = "Построить гистограмму яркости";
            this.calculateBrightnessGistogrammButton.UseVisualStyleBackColor = true;
            this.calculateBrightnessGistogrammButton.Click += new System.EventHandler(this.calculateBrightnessGistogrammButton_Click);
            // 
            // brightnessPictureBox
            // 
            this.brightnessPictureBox.Location = new System.Drawing.Point(48, 22);
            this.brightnessPictureBox.Name = "brightnessPictureBox";
            this.brightnessPictureBox.Size = new System.Drawing.Size(256, 100);
            this.brightnessPictureBox.TabIndex = 7;
            this.brightnessPictureBox.TabStop = false;
            // 
            // brightnessGistogrammGroupBox
            // 
            this.brightnessGistogrammGroupBox.Controls.Add(this.maxBrightnessCountLabel);
            this.brightnessGistogrammGroupBox.Controls.Add(this.calculateBrightnessGistogrammButton);
            this.brightnessGistogrammGroupBox.Controls.Add(this.label3);
            this.brightnessGistogrammGroupBox.Controls.Add(this.label2);
            this.brightnessGistogrammGroupBox.Controls.Add(this.label1);
            this.brightnessGistogrammGroupBox.Controls.Add(this.brightnessPictureBox);
            this.brightnessGistogrammGroupBox.Location = new System.Drawing.Point(738, 197);
            this.brightnessGistogrammGroupBox.Name = "brightnessGistogrammGroupBox";
            this.brightnessGistogrammGroupBox.Size = new System.Drawing.Size(322, 178);
            this.brightnessGistogrammGroupBox.TabIndex = 8;
            this.brightnessGistogrammGroupBox.TabStop = false;
            this.brightnessGistogrammGroupBox.Text = "Гистограмма яркости";
            // 
            // maxBrightnessCountLabel
            // 
            this.maxBrightnessCountLabel.AutoSize = true;
            this.maxBrightnessCountLabel.Location = new System.Drawing.Point(17, 22);
            this.maxBrightnessCountLabel.Name = "maxBrightnessCountLabel";
            this.maxBrightnessCountLabel.Size = new System.Drawing.Size(13, 15);
            this.maxBrightnessCountLabel.TabIndex = 11;
            this.maxBrightnessCountLabel.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "255";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "0";
            // 
            // brightnessGB
            // 
            this.brightnessGB.Controls.Add(this.label7);
            this.brightnessGB.Controls.Add(this.brightnessValueTB);
            this.brightnessGB.Controls.Add(this.label6);
            this.brightnessGB.Controls.Add(this.label5);
            this.brightnessGB.Controls.Add(this.label4);
            this.brightnessGB.Controls.Add(this.brightnessTrackBar);
            this.brightnessGB.Location = new System.Drawing.Point(738, 381);
            this.brightnessGB.Name = "brightnessGB";
            this.brightnessGB.Size = new System.Drawing.Size(322, 107);
            this.brightnessGB.TabIndex = 9;
            this.brightnessGB.TabStop = false;
            this.brightnessGB.Text = "Изменение яркости";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Значение:";
            // 
            // brightnessValueTB
            // 
            this.brightnessValueTB.Location = new System.Drawing.Point(76, 77);
            this.brightnessValueTB.Name = "brightnessValueTB";
            this.brightnessValueTB.Size = new System.Drawing.Size(58, 23);
            this.brightnessValueTB.TabIndex = 4;
            this.brightnessValueTB.TextChanged += new System.EventHandler(this.brightnessValueTB_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "255";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "-255";
            // 
            // brightnessTrackBar
            // 
            this.brightnessTrackBar.Location = new System.Drawing.Point(6, 22);
            this.brightnessTrackBar.Maximum = 255;
            this.brightnessTrackBar.Minimum = -255;
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Size = new System.Drawing.Size(308, 45);
            this.brightnessTrackBar.TabIndex = 0;
            this.brightnessTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brightnessTrackBar.Scroll += new System.EventHandler(this.brightnessTrackBar_Scroll);
            // 
            // cancelChangesBrightness
            // 
            this.cancelChangesBrightness.Location = new System.Drawing.Point(938, 99);
            this.cancelChangesBrightness.Name = "cancelChangesBrightness";
            this.cancelChangesBrightness.Size = new System.Drawing.Size(131, 23);
            this.cancelChangesBrightness.TabIndex = 7;
            this.cancelChangesBrightness.Text = "Отменить";
            this.cancelChangesBrightness.UseVisualStyleBackColor = true;
            this.cancelChangesBrightness.Click += new System.EventHandler(this.cancelChangesBrightness_Click);
            // 
            // applyChangesBrightness
            // 
            this.applyChangesBrightness.Location = new System.Drawing.Point(938, 70);
            this.applyChangesBrightness.Name = "applyChangesBrightness";
            this.applyChangesBrightness.Size = new System.Drawing.Size(131, 23);
            this.applyChangesBrightness.TabIndex = 6;
            this.applyChangesBrightness.Text = "Применить";
            this.applyChangesBrightness.UseVisualStyleBackColor = true;
            this.applyChangesBrightness.Click += new System.EventHandler(this.applyChangesBrightness_Click);
            // 
            // contrastGB
            // 
            this.contrastGB.Controls.Add(this.label8);
            this.contrastGB.Controls.Add(this.contrastValueTB);
            this.contrastGB.Controls.Add(this.label9);
            this.contrastGB.Controls.Add(this.label10);
            this.contrastGB.Controls.Add(this.label11);
            this.contrastGB.Controls.Add(this.contrastTrackBar);
            this.contrastGB.Location = new System.Drawing.Point(738, 494);
            this.contrastGB.Name = "contrastGB";
            this.contrastGB.Size = new System.Drawing.Size(322, 107);
            this.contrastGB.TabIndex = 10;
            this.contrastGB.TabStop = false;
            this.contrastGB.Text = "Изменение контрастности";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Значение:";
            // 
            // contrastValueTB
            // 
            this.contrastValueTB.Location = new System.Drawing.Point(76, 77);
            this.contrastValueTB.Name = "contrastValueTB";
            this.contrastValueTB.Size = new System.Drawing.Size(58, 23);
            this.contrastValueTB.TabIndex = 4;
            this.contrastValueTB.TextChanged += new System.EventHandler(this.contrastValueTB_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(155, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(285, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "50";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "-50";
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point(6, 22);
            this.contrastTrackBar.Maximum = 50;
            this.contrastTrackBar.Minimum = -50;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size(308, 45);
            this.contrastTrackBar.TabIndex = 0;
            this.contrastTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackBar_Scroll);
            // 
            // BWGB
            // 
            this.BWGB.Controls.Add(this.label12);
            this.BWGB.Controls.Add(this.BWValueTB);
            this.BWGB.Controls.Add(this.label13);
            this.BWGB.Controls.Add(this.label14);
            this.BWGB.Controls.Add(this.BWTrackBar);
            this.BWGB.Location = new System.Drawing.Point(738, 607);
            this.BWGB.Name = "BWGB";
            this.BWGB.Size = new System.Drawing.Size(322, 107);
            this.BWGB.TabIndex = 11;
            this.BWGB.TabStop = false;
            this.BWGB.Text = "Переход к черно-белому";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 15);
            this.label12.TabIndex = 12;
            this.label12.Text = "Значение:";
            // 
            // BWValueTB
            // 
            this.BWValueTB.Location = new System.Drawing.Point(76, 78);
            this.BWValueTB.Name = "BWValueTB";
            this.BWValueTB.Size = new System.Drawing.Size(58, 23);
            this.BWValueTB.TabIndex = 11;
            this.BWValueTB.TextChanged += new System.EventHandler(this.BWValueTB_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(288, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "255";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 15);
            this.label14.TabIndex = 9;
            this.label14.Text = "0";
            // 
            // BWTrackBar
            // 
            this.BWTrackBar.Location = new System.Drawing.Point(9, 22);
            this.BWTrackBar.Maximum = 255;
            this.BWTrackBar.Name = "BWTrackBar";
            this.BWTrackBar.Size = new System.Drawing.Size(308, 45);
            this.BWTrackBar.TabIndex = 8;
            this.BWTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BWTrackBar.Scroll += new System.EventHandler(this.BWTrackBar_Scroll);
            // 
            // grayButton
            // 
            this.grayButton.Location = new System.Drawing.Point(741, 138);
            this.grayButton.Name = "grayButton";
            this.grayButton.Size = new System.Drawing.Size(328, 23);
            this.grayButton.TabIndex = 12;
            this.grayButton.Text = "Градации серого";
            this.grayButton.UseVisualStyleBackColor = true;
            this.grayButton.Click += new System.EventHandler(this.grayButton_Click);
            // 
            // negative
            // 
            this.negative.Location = new System.Drawing.Point(741, 168);
            this.negative.Name = "negative";
            this.negative.Size = new System.Drawing.Size(328, 23);
            this.negative.TabIndex = 13;
            this.negative.Text = "Негатив";
            this.negative.UseVisualStyleBackColor = true;
            this.negative.Click += new System.EventHandler(this.negative_Click);
            // 
            // fragment
            // 
            this.fragment.Controls.Add(this.rightBottomY);
            this.fragment.Controls.Add(this.rightBottomX);
            this.fragment.Controls.Add(this.label16);
            this.fragment.Controls.Add(this.leftUpY);
            this.fragment.Controls.Add(this.leftUpX);
            this.fragment.Controls.Add(this.label15);
            this.fragment.Location = new System.Drawing.Point(738, 12);
            this.fragment.Name = "fragment";
            this.fragment.Size = new System.Drawing.Size(194, 120);
            this.fragment.TabIndex = 14;
            this.fragment.TabStop = false;
            this.fragment.Text = "Фрагмент";
            // 
            // rightBottomY
            // 
            this.rightBottomY.Location = new System.Drawing.Point(99, 86);
            this.rightBottomY.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.rightBottomY.Name = "rightBottomY";
            this.rightBottomY.Size = new System.Drawing.Size(84, 23);
            this.rightBottomY.TabIndex = 5;
            // 
            // rightBottomX
            // 
            this.rightBottomX.Location = new System.Drawing.Point(9, 87);
            this.rightBottomX.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.rightBottomX.Name = "rightBottomX";
            this.rightBottomX.Size = new System.Drawing.Size(84, 23);
            this.rightBottomX.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(155, 15);
            this.label16.TabIndex = 3;
            this.label16.Text = "Правый нижний угол (х, у)";
            // 
            // leftUpY
            // 
            this.leftUpY.Location = new System.Drawing.Point(99, 41);
            this.leftUpY.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.leftUpY.Name = "leftUpY";
            this.leftUpY.Size = new System.Drawing.Size(84, 23);
            this.leftUpY.TabIndex = 2;
            // 
            // leftUpX
            // 
            this.leftUpX.Location = new System.Drawing.Point(9, 42);
            this.leftUpX.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.leftUpX.Name = "leftUpX";
            this.leftUpX.Size = new System.Drawing.Size(84, 23);
            this.leftUpX.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(149, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Левый верхний угол (х, у)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 745);
            this.Controls.Add(this.fragment);
            this.Controls.Add(this.negative);
            this.Controls.Add(this.cancelChangesBrightness);
            this.Controls.Add(this.grayButton);
            this.Controls.Add(this.applyChangesBrightness);
            this.Controls.Add(this.BWGB);
            this.Controls.Add(this.contrastGB);
            this.Controls.Add(this.brightnessGB);
            this.Controls.Add(this.brightnessGistogrammGroupBox);
            this.Controls.Add(this.deleteImage);
            this.Controls.Add(this.loadImage);
            this.Controls.Add(this.pictureBox_main);
            this.Name = "Form1";
            this.Text = "Компьютерная графика, Потапов, ПИ-82, лабораторная работа 5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessPictureBox)).EndInit();
            this.brightnessGistogrammGroupBox.ResumeLayout(false);
            this.brightnessGistogrammGroupBox.PerformLayout();
            this.brightnessGB.ResumeLayout(false);
            this.brightnessGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
            this.contrastGB.ResumeLayout(false);
            this.contrastGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            this.BWGB.ResumeLayout(false);
            this.BWGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BWTrackBar)).EndInit();
            this.fragment.ResumeLayout(false);
            this.fragment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightBottomY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBottomX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftUpY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftUpX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_main;
        private System.Windows.Forms.Button loadImage;
        private System.Windows.Forms.Button deleteImage;
        private System.Windows.Forms.Button calculateBrightnessGistogrammButton;
        private System.Windows.Forms.PictureBox brightnessPictureBox;
        private System.Windows.Forms.GroupBox brightnessGistogrammGroupBox;
        private System.Windows.Forms.Label maxBrightnessCountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox brightnessGB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar brightnessTrackBar;
        private System.Windows.Forms.TextBox brightnessValueTB;
        private System.Windows.Forms.Button cancelChangesBrightness;
        private System.Windows.Forms.Button applyChangesBrightness;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox contrastGB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox contrastValueTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.GroupBox BWGB;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar BWTrackBar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox BWValueTB;
        private System.Windows.Forms.Button grayButton;
        private System.Windows.Forms.Button negative;
        private System.Windows.Forms.GroupBox fragment;
        private System.Windows.Forms.NumericUpDown rightBottomY;
        private System.Windows.Forms.NumericUpDown rightBottomX;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown leftUpY;
        private System.Windows.Forms.NumericUpDown leftUpX;
        private System.Windows.Forms.Label label15;
    }
}

