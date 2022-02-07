
namespace DummyPhotoshop.Windows
{
    partial class SharpeningWindow
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.varianceTextBox = new System.Windows.Forms.TextBox();
            this.coefTrackbar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radiusTextBox = new System.Windows.Forms.TextBox();
            this.radiusTrackbar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coefTrackbar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radiusTrackbar)).BeginInit();
            this.SuspendLayout();
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.varianceTextBox);
            this.panel2.Controls.Add(this.coefTrackbar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 70);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(478, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "%";
            // 
            // varianceTextBox
            // 
            this.varianceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.varianceTextBox.Location = new System.Drawing.Point(416, 3);
            this.varianceTextBox.Name = "varianceTextBox";
            this.varianceTextBox.ReadOnly = true;
            this.varianceTextBox.Size = new System.Drawing.Size(58, 27);
            this.varianceTextBox.TabIndex = 4;
            // 
            // coefTrackbar
            // 
            this.coefTrackbar.AutoSize = false;
            this.coefTrackbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.coefTrackbar.Location = new System.Drawing.Point(0, 36);
            this.coefTrackbar.Maximum = 100;
            this.coefTrackbar.Name = "coefTrackbar";
            this.coefTrackbar.Size = new System.Drawing.Size(502, 34);
            this.coefTrackbar.TabIndex = 1;
            this.coefTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.coefTrackbar.Scroll += new System.EventHandler(this.variationTrackbar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Коэффициент";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.radiusTextBox);
            this.panel1.Controls.Add(this.radiusTrackbar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(15, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 70);
            this.panel1.TabIndex = 7;
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radiusTextBox.Location = new System.Drawing.Point(413, 3);
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.ReadOnly = true;
            this.radiusTextBox.Size = new System.Drawing.Size(58, 27);
            this.radiusTextBox.TabIndex = 4;
            // 
            // radiusTrackbar
            // 
            this.radiusTrackbar.AutoSize = false;
            this.radiusTrackbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radiusTrackbar.Location = new System.Drawing.Point(0, 36);
            this.radiusTrackbar.Maximum = 100;
            this.radiusTrackbar.Minimum = 1;
            this.radiusTrackbar.Name = "radiusTrackbar";
            this.radiusTrackbar.Size = new System.Drawing.Size(502, 34);
            this.radiusTrackbar.TabIndex = 1;
            this.radiusTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.radiusTrackbar.Value = 1;
            this.radiusTrackbar.ValueChanged += new System.EventHandler(this.radiusTrackbar_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Радиус";
            // 
            // SharpeningWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 184);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "SharpeningWindow";
            this.Text = "Увеличение резкости";
            this.Load += new System.EventHandler(this.SharpeningWindow_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coefTrackbar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radiusTrackbar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar coefTrackbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox varianceTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.TrackBar radiusTrackbar;
        private System.Windows.Forms.Label label4;
    }
}