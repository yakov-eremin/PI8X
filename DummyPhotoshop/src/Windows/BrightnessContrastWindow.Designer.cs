
namespace DummyPhotoshop.Windows
{
    partial class BrightnessContrastWindow
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contrastTextBox = new System.Windows.Forms.TextBox();
            this.contrastTrackbar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.brightnessTextBox = new System.Windows.Forms.TextBox();
            this.brightnessTrackbar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackbar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(425, 166);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.contrastTextBox);
            this.panel2.Controls.Add(this.contrastTrackbar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 70);
            this.panel2.TabIndex = 3;
            // 
            // contrastTextBox
            // 
            this.contrastTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.contrastTextBox.Location = new System.Drawing.Point(359, 3);
            this.contrastTextBox.Name = "contrastTextBox";
            this.contrastTextBox.ReadOnly = true;
            this.contrastTextBox.Size = new System.Drawing.Size(58, 27);
            this.contrastTextBox.TabIndex = 3;
            // 
            // contrastTrackbar
            // 
            this.contrastTrackbar.AutoSize = false;
            this.contrastTrackbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.contrastTrackbar.Location = new System.Drawing.Point(0, 36);
            this.contrastTrackbar.Maximum = 200;
            this.contrastTrackbar.Name = "contrastTrackbar";
            this.contrastTrackbar.Size = new System.Drawing.Size(420, 34);
            this.contrastTrackbar.TabIndex = 1;
            this.contrastTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.contrastTrackbar.Value = 100;
            this.contrastTrackbar.ValueChanged += new System.EventHandler(this.contrastTrackbar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Контрастность";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.brightnessTextBox);
            this.panel1.Controls.Add(this.brightnessTrackbar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 70);
            this.panel1.TabIndex = 0;
            // 
            // brightnessTextBox
            // 
            this.brightnessTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.brightnessTextBox.Location = new System.Drawing.Point(359, 3);
            this.brightnessTextBox.Name = "brightnessTextBox";
            this.brightnessTextBox.ReadOnly = true;
            this.brightnessTextBox.Size = new System.Drawing.Size(58, 27);
            this.brightnessTextBox.TabIndex = 2;
            // 
            // brightnessTrackbar
            // 
            this.brightnessTrackbar.AutoSize = false;
            this.brightnessTrackbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.brightnessTrackbar.Location = new System.Drawing.Point(0, 36);
            this.brightnessTrackbar.Maximum = 255;
            this.brightnessTrackbar.Minimum = -255;
            this.brightnessTrackbar.Name = "brightnessTrackbar";
            this.brightnessTrackbar.Size = new System.Drawing.Size(420, 34);
            this.brightnessTrackbar.TabIndex = 1;
            this.brightnessTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brightnessTrackbar.ValueChanged += new System.EventHandler(this.brightnessTrackbar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Яркость";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(452, 12);
            this.okButton.Name = "okButton";
            this.okButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.okButton.Size = new System.Drawing.Size(106, 29);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "Применить";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.cancelButton.Location = new System.Drawing.Point(452, 66);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cancelButton.Size = new System.Drawing.Size(106, 29);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BrightnessContrastWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 190);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BrightnessContrastWindow";
            this.Text = "Изменение яркости и контрастности";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackbar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackbar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar brightnessTrackbar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox brightnessTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox contrastTextBox;
        private System.Windows.Forms.TrackBar contrastTrackbar;
        private System.Windows.Forms.Label label2;
    }
}