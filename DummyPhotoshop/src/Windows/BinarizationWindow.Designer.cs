
namespace DummyPhotoshop.Windows
{
    partial class BinarizationWindow
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
            this.histogramBox = new System.Windows.Forms.PictureBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.binarizationTrackbar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.rightColorButton = new System.Windows.Forms.Button();
            this.leftColorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.histogramBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.binarizationTrackbar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // histogramBox
            // 
            this.histogramBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.histogramBox.BackColor = System.Drawing.Color.White;
            this.histogramBox.Location = new System.Drawing.Point(10, 2);
            this.histogramBox.Name = "histogramBox";
            this.histogramBox.Size = new System.Drawing.Size(481, 158);
            this.histogramBox.TabIndex = 3;
            this.histogramBox.TabStop = false;
            this.histogramBox.Paint += new System.Windows.Forms.PaintEventHandler(this.histogramBox_Paint);
            // 
            // cancelButton
            // 
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.cancelButton.Location = new System.Drawing.Point(523, 53);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(6);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cancelButton.Size = new System.Drawing.Size(106, 29);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(523, 12);
            this.okButton.Margin = new System.Windows.Forms.Padding(6);
            this.okButton.Name = "okButton";
            this.okButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.okButton.Size = new System.Drawing.Size(106, 29);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Применить";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // binarizationTrackbar
            // 
            this.binarizationTrackbar.AutoSize = false;
            this.binarizationTrackbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.binarizationTrackbar.Location = new System.Drawing.Point(0, 163);
            this.binarizationTrackbar.Margin = new System.Windows.Forms.Padding(0);
            this.binarizationTrackbar.Maximum = 255;
            this.binarizationTrackbar.Name = "binarizationTrackbar";
            this.binarizationTrackbar.Size = new System.Drawing.Size(502, 38);
            this.binarizationTrackbar.TabIndex = 6;
            this.binarizationTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.binarizationTrackbar.Value = 100;
            this.binarizationTrackbar.Scroll += new System.EventHandler(this.binarizationTrackbar_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.histogramBox);
            this.panel1.Controls.Add(this.binarizationTrackbar);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 201);
            this.panel1.TabIndex = 7;
            // 
            // rightColorButton
            // 
            this.rightColorButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.rightColorButton.Location = new System.Drawing.Point(471, 222);
            this.rightColorButton.Margin = new System.Windows.Forms.Padding(6);
            this.rightColorButton.Name = "rightColorButton";
            this.rightColorButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rightColorButton.Size = new System.Drawing.Size(32, 32);
            this.rightColorButton.TabIndex = 8;
            this.rightColorButton.UseVisualStyleBackColor = true;
            this.rightColorButton.Click += new System.EventHandler(this.rightColorButton_Click);
            this.rightColorButton.Paint += new System.Windows.Forms.PaintEventHandler(this.rightColorButton_Paint);
            // 
            // leftColorButton
            // 
            this.leftColorButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.leftColorButton.Location = new System.Drawing.Point(105, 222);
            this.leftColorButton.Margin = new System.Windows.Forms.Padding(6);
            this.leftColorButton.Name = "leftColorButton";
            this.leftColorButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.leftColorButton.Size = new System.Drawing.Size(32, 32);
            this.leftColorButton.TabIndex = 9;
            this.leftColorButton.UseVisualStyleBackColor = true;
            this.leftColorButton.Click += new System.EventHandler(this.leftColorButton_Click);
            this.leftColorButton.Paint += new System.Windows.Forms.PaintEventHandler(this.leftColorButton_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Левый цвет";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Правый цвет";
            // 
            // BinarizationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 263);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.leftColorButton);
            this.Controls.Add(this.rightColorButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "BinarizationWindow";
            this.Text = "Бинаризация";
            this.Load += new System.EventHandler(this.BinarizationWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.histogramBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.binarizationTrackbar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox histogramBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TrackBar binarizationTrackbar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button rightColorButton;
        private System.Windows.Forms.Button leftColorButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}