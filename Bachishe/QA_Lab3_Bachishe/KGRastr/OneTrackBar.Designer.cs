
namespace KGRastr
{
    partial class OneTrackBar
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
            this.transformationParam = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.ParametrValue = new System.Windows.Forms.TextBox();
            this.TransformationParametrTrackBar = new System.Windows.Forms.TrackBar();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TransformationParametrTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // transformationParam
            // 
            this.transformationParam.AutoSize = true;
            this.transformationParam.Location = new System.Drawing.Point(25, 9);
            this.transformationParam.Name = "transformationParam";
            this.transformationParam.Size = new System.Drawing.Size(79, 20);
            this.transformationParam.TabIndex = 6;
            this.transformationParam.Text = "Параметр";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(115, 109);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(104, 29);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Применить";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // ParametrValue
            // 
            this.ParametrValue.Location = new System.Drawing.Point(449, 47);
            this.ParametrValue.MaxLength = 4;
            this.ParametrValue.Name = "ParametrValue";
            this.ParametrValue.Size = new System.Drawing.Size(56, 27);
            this.ParametrValue.TabIndex = 2;
            this.ParametrValue.Text = "0";
            // 
            // TransformationParametrTrackBar
            // 
            this.TransformationParametrTrackBar.Location = new System.Drawing.Point(12, 47);
            this.TransformationParametrTrackBar.Maximum = 1;
            this.TransformationParametrTrackBar.Minimum = 1;
            this.TransformationParametrTrackBar.Name = "TransformationParametrTrackBar";
            this.TransformationParametrTrackBar.Size = new System.Drawing.Size(431, 56);
            this.TransformationParametrTrackBar.TabIndex = 0;
            this.TransformationParametrTrackBar.Value = 1;
            this.TransformationParametrTrackBar.Scroll += new System.EventHandler(this.TransformationParametrTrackBar_Scroll);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(291, 109);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(104, 29);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OneTrackBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 167);
            this.Controls.Add(this.ParametrValue);
            this.Controls.Add(this.transformationParam);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.TransformationParametrTrackBar);
            this.Controls.Add(this.updateButton);
            this.Name = "OneTrackBar";
            this.Text = "OneTrackBar";
            this.Load += new System.EventHandler(this.OneTrackBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TransformationParametrTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label transformationParam;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox ParametrValue;
        private System.Windows.Forms.TrackBar TransformationParametrTrackBar;
        private System.Windows.Forms.Button CancelButton;
    }
}