
namespace DummyPhotoshop.Windows
{
    partial class AddNoiseWindow
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
            this.noiseTextBox = new System.Windows.Forms.TextBox();
            this.noiseTrackbar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.monocromeCheckBox = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noiseTrackbar)).BeginInit();
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
            this.panel2.Controls.Add(this.noiseTextBox);
            this.panel2.Controls.Add(this.noiseTrackbar);
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
            // noiseTextBox
            // 
            this.noiseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.noiseTextBox.Location = new System.Drawing.Point(416, 3);
            this.noiseTextBox.Name = "noiseTextBox";
            this.noiseTextBox.ReadOnly = true;
            this.noiseTextBox.Size = new System.Drawing.Size(58, 27);
            this.noiseTextBox.TabIndex = 4;
            // 
            // noiseTrackbar
            // 
            this.noiseTrackbar.AutoSize = false;
            this.noiseTrackbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.noiseTrackbar.Location = new System.Drawing.Point(0, 36);
            this.noiseTrackbar.Maximum = 100;
            this.noiseTrackbar.Name = "noiseTrackbar";
            this.noiseTrackbar.Size = new System.Drawing.Size(502, 34);
            this.noiseTrackbar.TabIndex = 1;
            this.noiseTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.noiseTrackbar.ValueChanged += new System.EventHandler(this.noiseTrackbar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Эффект";
            // 
            // monocromeCheckBox
            // 
            this.monocromeCheckBox.AutoSize = true;
            this.monocromeCheckBox.Location = new System.Drawing.Point(15, 88);
            this.monocromeCheckBox.Name = "monocromeCheckBox";
            this.monocromeCheckBox.Size = new System.Drawing.Size(136, 24);
            this.monocromeCheckBox.TabIndex = 7;
            this.monocromeCheckBox.Text = "Монохромный";
            this.monocromeCheckBox.UseVisualStyleBackColor = true;
            this.monocromeCheckBox.CheckedChanged += new System.EventHandler(this.MonocromeCheckBoxCheckedChanged);
            // 
            // AddNoiseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 144);
            this.Controls.Add(this.monocromeCheckBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "AddNoiseWindow";
            this.Text = "Добавление шума";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noiseTrackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar noiseTrackbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox noiseTextBox;
        private System.Windows.Forms.CheckBox monocromeCheckBox;
    }
}