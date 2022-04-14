namespace PhotoCorrection {
	partial class Histograms {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pictureBox_current_histo = new System.Windows.Forms.PictureBox();
			this.comboBox_histos = new System.Windows.Forms.ComboBox();
			this.trackBar_CyanRed = new System.Windows.Forms.TrackBar();
			this.trackBar_MagentaGreen = new System.Windows.Forms.TrackBar();
			this.trackBar_YellowBlue = new System.Windows.Forms.TrackBar();
			this.label_cyan = new System.Windows.Forms.Label();
			this.label_red = new System.Windows.Forms.Label();
			this.label_magenta = new System.Windows.Forms.Label();
			this.label_green = new System.Windows.Forms.Label();
			this.label_yellow = new System.Windows.Forms.Label();
			this.label_blue = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_current_histo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_CyanRed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_MagentaGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_YellowBlue)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox_current_histo
			// 
			this.pictureBox_current_histo.Location = new System.Drawing.Point(16, 63);
			this.pictureBox_current_histo.Name = "pictureBox_current_histo";
			this.pictureBox_current_histo.Size = new System.Drawing.Size(256, 300);
			this.pictureBox_current_histo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox_current_histo.TabIndex = 0;
			this.pictureBox_current_histo.TabStop = false;
			// 
			// comboBox_histos
			// 
			this.comboBox_histos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
			this.comboBox_histos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_histos.ForeColor = System.Drawing.Color.White;
			this.comboBox_histos.Location = new System.Drawing.Point(12, 12);
			this.comboBox_histos.Name = "comboBox_histos";
			this.comboBox_histos.Size = new System.Drawing.Size(256, 29);
			this.comboBox_histos.TabIndex = 1;
			this.comboBox_histos.SelectedIndexChanged += new System.EventHandler(this.comboBox_histos_indexChanged);
			// 
			// trackBar_CyanRed
			// 
			this.trackBar_CyanRed.Location = new System.Drawing.Point(12, 410);
			this.trackBar_CyanRed.Minimum = -10;
			this.trackBar_CyanRed.Name = "trackBar_CyanRed";
			this.trackBar_CyanRed.Size = new System.Drawing.Size(260, 45);
			this.trackBar_CyanRed.TabIndex = 2;
			this.trackBar_CyanRed.Scroll += new System.EventHandler(this.trackBar_CyanRed_Scroll);
			// 
			// trackBar_MagentaGreen
			// 
			this.trackBar_MagentaGreen.Location = new System.Drawing.Point(12, 482);
			this.trackBar_MagentaGreen.Minimum = -10;
			this.trackBar_MagentaGreen.Name = "trackBar_MagentaGreen";
			this.trackBar_MagentaGreen.Size = new System.Drawing.Size(260, 45);
			this.trackBar_MagentaGreen.TabIndex = 3;
			this.trackBar_MagentaGreen.Scroll += new System.EventHandler(this.trackBar_MagentaGreen_Scroll);
			// 
			// trackBar_YellowBlue
			// 
			this.trackBar_YellowBlue.Location = new System.Drawing.Point(12, 554);
			this.trackBar_YellowBlue.Minimum = -10;
			this.trackBar_YellowBlue.Name = "trackBar_YellowBlue";
			this.trackBar_YellowBlue.Size = new System.Drawing.Size(260, 45);
			this.trackBar_YellowBlue.TabIndex = 4;
			this.trackBar_YellowBlue.Scroll += new System.EventHandler(this.trackBar_YellowBlue_Scroll);
			// 
			// label_cyan
			// 
			this.label_cyan.AutoSize = true;
			this.label_cyan.ForeColor = System.Drawing.Color.White;
			this.label_cyan.Location = new System.Drawing.Point(12, 386);
			this.label_cyan.Name = "label_cyan";
			this.label_cyan.Size = new System.Drawing.Size(68, 21);
			this.label_cyan.TabIndex = 5;
			this.label_cyan.Text = "Голубой";
			// 
			// label_red
			// 
			this.label_red.AutoSize = true;
			this.label_red.ForeColor = System.Drawing.Color.White;
			this.label_red.Location = new System.Drawing.Point(200, 386);
			this.label_red.Name = "label_red";
			this.label_red.Size = new System.Drawing.Size(72, 21);
			this.label_red.TabIndex = 6;
			this.label_red.Text = "Красный";
			// 
			// label_magenta
			// 
			this.label_magenta.AutoSize = true;
			this.label_magenta.ForeColor = System.Drawing.Color.White;
			this.label_magenta.Location = new System.Drawing.Point(12, 458);
			this.label_magenta.Name = "label_magenta";
			this.label_magenta.Size = new System.Drawing.Size(93, 21);
			this.label_magenta.TabIndex = 7;
			this.label_magenta.Text = "Пурпурный";
			// 
			// label_green
			// 
			this.label_green.AutoSize = true;
			this.label_green.ForeColor = System.Drawing.Color.White;
			this.label_green.Location = new System.Drawing.Point(200, 458);
			this.label_green.Name = "label_green";
			this.label_green.Size = new System.Drawing.Size(72, 21);
			this.label_green.TabIndex = 8;
			this.label_green.Text = "Зеленый";
			// 
			// label_yellow
			// 
			this.label_yellow.AutoSize = true;
			this.label_yellow.ForeColor = System.Drawing.Color.White;
			this.label_yellow.Location = new System.Drawing.Point(12, 530);
			this.label_yellow.Name = "label_yellow";
			this.label_yellow.Size = new System.Drawing.Size(67, 21);
			this.label_yellow.TabIndex = 9;
			this.label_yellow.Text = "Желтый";
			// 
			// label_blue
			// 
			this.label_blue.AutoSize = true;
			this.label_blue.ForeColor = System.Drawing.Color.White;
			this.label_blue.Location = new System.Drawing.Point(216, 530);
			this.label_blue.Name = "label_blue";
			this.label_blue.Size = new System.Drawing.Size(56, 21);
			this.label_blue.TabIndex = 10;
			this.label_blue.Text = "Синий";
			// 
			// Histograms
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
			this.ClientSize = new System.Drawing.Size(284, 611);
			this.ControlBox = false;
			this.Controls.Add(this.label_blue);
			this.Controls.Add(this.label_yellow);
			this.Controls.Add(this.label_green);
			this.Controls.Add(this.label_magenta);
			this.Controls.Add(this.label_red);
			this.Controls.Add(this.label_cyan);
			this.Controls.Add(this.trackBar_YellowBlue);
			this.Controls.Add(this.trackBar_MagentaGreen);
			this.Controls.Add(this.trackBar_CyanRed);
			this.Controls.Add(this.comboBox_histos);
			this.Controls.Add(this.pictureBox_current_histo);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe WP", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Histograms";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Гистограммы";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_current_histo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_CyanRed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_MagentaGreen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_YellowBlue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox_current_histo;
		private System.Windows.Forms.ComboBox comboBox_histos;
		private System.Windows.Forms.TrackBar trackBar_CyanRed;
		private System.Windows.Forms.TrackBar trackBar_MagentaGreen;
		private System.Windows.Forms.TrackBar trackBar_YellowBlue;
		private System.Windows.Forms.Label label_cyan;
		private System.Windows.Forms.Label label_red;
		private System.Windows.Forms.Label label_magenta;
		private System.Windows.Forms.Label label_green;
		private System.Windows.Forms.Label label_yellow;
		private System.Windows.Forms.Label label_blue;
	}
}