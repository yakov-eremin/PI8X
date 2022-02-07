
using System.Drawing.Drawing2D;
using DummyPhotoshop.Helpers;

namespace DummyPhotoshop.Windows
{
    partial class MainWindow
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
            this.histogramBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadButton = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreButton = new System.Windows.Forms.ToolStripMenuItem();
            this.коррекцияИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessContrastButton = new System.Windows.Forms.ToolStripMenuItem();
            this.blackWhiteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.binarizationButton = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianDenoiseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.uniformDenoiseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.medianDenoiseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpeningButton = new System.Windows.Forms.ToolStripMenuItem();
            this.embossingButton = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.histogramBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // histogramBox
            // 
            this.histogramBox.BackColor = System.Drawing.Color.White;
            this.histogramBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramBox.Location = new System.Drawing.Point(5, 5);
            this.histogramBox.Name = "histogramBox";
            this.histogramBox.Size = new System.Drawing.Size(421, 190);
            this.histogramBox.TabIndex = 2;
            this.histogramBox.TabStop = false;
            this.histogramBox.Paint += new System.Windows.Forms.PaintEventHandler(this.HistogramBoxPaint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.canvas);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1316, 753);
            this.panel1.TabIndex = 4;
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.Location = new System.Drawing.Point(41, 60);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(786, 574);
            this.canvas.TabIndex = 10;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasMouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadButton,
            this.restoreButton,
            this.коррекцияИзображенияToolStripMenuItem,
            this.фильтрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1316, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadButton
            // 
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(191, 24);
            this.loadButton.Text = "Загрузить изображение";
            this.loadButton.Click += new System.EventHandler(this.LoadButtonClicked);
            // 
            // restoreButton
            // 
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(218, 24);
            this.restoreButton.Text = "Восстановить изображение";
            this.restoreButton.Click += new System.EventHandler(this.RestoreButtonClick);
            // 
            // коррекцияИзображенияToolStripMenuItem
            // 
            this.коррекцияИзображенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.brightnessContrastButton,
            this.blackWhiteButton,
            this.negativeButton,
            this.binarizationButton});
            this.коррекцияИзображенияToolStripMenuItem.Name = "коррекцияИзображенияToolStripMenuItem";
            this.коррекцияИзображенияToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.коррекцияИзображенияToolStripMenuItem.Text = "Коррекция изображения";
            // 
            // brightnessContrastButton
            // 
            this.brightnessContrastButton.Name = "brightnessContrastButton";
            this.brightnessContrastButton.Size = new System.Drawing.Size(258, 26);
            this.brightnessContrastButton.Text = "Яркость/Контрасность...";
            this.brightnessContrastButton.Click += new System.EventHandler(this.BrightnessContrastButtonClick);
            // 
            // blackWhiteButton
            // 
            this.blackWhiteButton.Name = "blackWhiteButton";
            this.blackWhiteButton.Size = new System.Drawing.Size(258, 26);
            this.blackWhiteButton.Text = "Черное-белое";
            this.blackWhiteButton.Click += new System.EventHandler(this.BlackWhiteButtonClick);
            // 
            // negativeButton
            // 
            this.negativeButton.Name = "negativeButton";
            this.negativeButton.Size = new System.Drawing.Size(258, 26);
            this.negativeButton.Text = "Инверсия";
            this.negativeButton.Click += new System.EventHandler(this.NegativeButtonClick);
            // 
            // binarizationButton
            // 
            this.binarizationButton.Name = "binarizationButton";
            this.binarizationButton.Size = new System.Drawing.Size(258, 26);
            this.binarizationButton.Text = "Бинаризация...";
            this.binarizationButton.Click += new System.EventHandler(this.BinarizationButtonClick);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.noiseButton,
            this.sharpeningButton,
            this.embossingButton});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gaussianDenoiseButton,
            this.uniformDenoiseButton,
            this.medianDenoiseButton});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(251, 26);
            this.toolStripMenuItem1.Text = "Шумоподавление";
            // 
            // gaussianDenoiseButton
            // 
            this.gaussianDenoiseButton.Name = "gaussianDenoiseButton";
            this.gaussianDenoiseButton.Size = new System.Drawing.Size(197, 26);
            this.gaussianDenoiseButton.Text = "По Гауссу...";
            this.gaussianDenoiseButton.Click += new System.EventHandler(this.GaussianDenoiseButtonClick);
            // 
            // uniformDenoiseButton
            // 
            this.uniformDenoiseButton.Name = "uniformDenoiseButton";
            this.uniformDenoiseButton.Size = new System.Drawing.Size(197, 26);
            this.uniformDenoiseButton.Text = "Равномерное...";
            this.uniformDenoiseButton.Click += new System.EventHandler(this.UniformDenoiseButtonClick);
            // 
            // medianDenoiseButton
            // 
            this.medianDenoiseButton.Name = "medianDenoiseButton";
            this.medianDenoiseButton.Size = new System.Drawing.Size(197, 26);
            this.medianDenoiseButton.Text = "Медиана...";
            this.medianDenoiseButton.Click += new System.EventHandler(this.MedianDenoiseButtonClick);
            // 
            // noiseButton
            // 
            this.noiseButton.Name = "noiseButton";
            this.noiseButton.Size = new System.Drawing.Size(251, 26);
            this.noiseButton.Text = "Добавить шум...";
            this.noiseButton.Click += new System.EventHandler(this.NoiseButtonClick);
            // 
            // sharpeningButton
            // 
            this.sharpeningButton.Name = "sharpeningButton";
            this.sharpeningButton.Size = new System.Drawing.Size(251, 26);
            this.sharpeningButton.Text = "Увеличение резкости...";
            this.sharpeningButton.Click += new System.EventHandler(this.sharpeningButton_Click);
            // 
            // embossingButton
            // 
            this.embossingButton.Name = "embossingButton";
            this.embossingButton.Size = new System.Drawing.Size(251, 26);
            this.embossingButton.Text = "Тиснение";
            this.embossingButton.Click += new System.EventHandler(this.embossingButton_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.histogramBox);
            this.panel2.Location = new System.Drawing.Point(885, 28);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(431, 200);
            this.panel2.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1316, 753);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "DummyPhotoshop";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.histogramBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox histogramBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem коррекцияИзображенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessContrastButton;
        private System.Windows.Forms.ToolStripMenuItem blackWhiteButton;
        private System.Windows.Forms.ToolStripMenuItem negativeButton;
        private System.Windows.Forms.ToolStripMenuItem binarizationButton;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gaussianDenoiseButton;
        private System.Windows.Forms.ToolStripMenuItem uniformDenoiseButton;
        private System.Windows.Forms.ToolStripMenuItem medianDenoiseButton;
        private System.Windows.Forms.ToolStripMenuItem noiseButton;
        private System.Windows.Forms.ToolStripMenuItem loadButton;
        private System.Windows.Forms.ToolStripMenuItem restoreButton;
        private System.Windows.Forms.ToolStripMenuItem sharpeningButton;
        private System.Windows.Forms.ToolStripMenuItem embossingButton;
        private System.Windows.Forms.PictureBox canvas;
    }
}

