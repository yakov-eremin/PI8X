
namespace Logistic
{
    partial class Orders
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
            this.ClearFilterButton = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.SummaryTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TreatieNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OrderNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteOrderButton = new System.Windows.Forms.Button();
            this.EditOrderButton = new System.Windows.Forms.Button();
            this.AddOrderButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TreatieNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDateCheckBox = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.StartDateListBox2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.StartDateListBox1 = new System.Windows.Forms.DateTimePicker();
            this.ExportButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.Location = new System.Drawing.Point(1162, 3);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(29, 29);
            this.ClearFilterButton.TabIndex = 10;
            this.ClearFilterButton.Text = "X";
            this.ClearFilterButton.UseVisualStyleBackColor = true;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(1066, 159);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(125, 29);
            this.FindButton.TabIndex = 9;
            this.FindButton.Text = "Найти";
            this.FindButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(347, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Адрес пункта назначения:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Общая сумма заявки (от):";
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(347, 125);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(228, 27);
            this.AddressTextBox.TabIndex = 7;
            // 
            // SummaryTextBox
            // 
            this.SummaryTextBox.Location = new System.Drawing.Point(347, 57);
            this.SummaryTextBox.Name = "SummaryTextBox";
            this.SummaryTextBox.Size = new System.Drawing.Size(228, 27);
            this.SummaryTextBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Номер договора:";
            // 
            // TreatieNumberTextBox
            // 
            this.TreatieNumberTextBox.Location = new System.Drawing.Point(50, 125);
            this.TreatieNumberTextBox.Name = "TreatieNumberTextBox";
            this.TreatieNumberTextBox.Size = new System.Drawing.Size(217, 27);
            this.TreatieNumberTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Номер заявки:";
            // 
            // OrderNumberTextBox
            // 
            this.OrderNumberTextBox.Location = new System.Drawing.Point(50, 57);
            this.OrderNumberTextBox.Name = "OrderNumberTextBox";
            this.OrderNumberTextBox.Size = new System.Drawing.Size(217, 27);
            this.OrderNumberTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Фильтр";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.StartDateCheckBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ClearFilterButton);
            this.panel1.Controls.Add(this.FindButton);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.AddressTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.SummaryTextBox);
            this.panel1.Controls.Add(this.OrderNumberTextBox);
            this.panel1.Controls.Add(this.TreatieNumberTextBox);
            this.panel1.Location = new System.Drawing.Point(8, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1196, 193);
            this.panel1.TabIndex = 12;
            // 
            // DeleteOrderButton
            // 
            this.DeleteOrderButton.Location = new System.Drawing.Point(999, 668);
            this.DeleteOrderButton.Name = "DeleteOrderButton";
            this.DeleteOrderButton.Size = new System.Drawing.Size(206, 29);
            this.DeleteOrderButton.TabIndex = 11;
            this.DeleteOrderButton.Text = "Удалить";
            this.DeleteOrderButton.UseVisualStyleBackColor = true;
            // 
            // EditOrderButton
            // 
            this.EditOrderButton.Location = new System.Drawing.Point(432, 668);
            this.EditOrderButton.Name = "EditOrderButton";
            this.EditOrderButton.Size = new System.Drawing.Size(206, 29);
            this.EditOrderButton.TabIndex = 10;
            this.EditOrderButton.Text = "Редактировать";
            this.EditOrderButton.UseVisualStyleBackColor = true;
            this.EditOrderButton.Click += new System.EventHandler(this.EditOrderButton_Click);
            // 
            // AddOrderButton
            // 
            this.AddOrderButton.Location = new System.Drawing.Point(220, 668);
            this.AddOrderButton.Name = "AddOrderButton";
            this.AddOrderButton.Size = new System.Drawing.Size(206, 29);
            this.AddOrderButton.TabIndex = 9;
            this.AddOrderButton.Text = "Добавить";
            this.AddOrderButton.UseVisualStyleBackColor = true;
            this.AddOrderButton.Click += new System.EventHandler(this.AddOrderButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderNumber,
            this.DateOfOrder,
            this.TreatieNumber,
            this.Summary,
            this.OrderAddress});
            this.dataGridView1.Location = new System.Drawing.Point(8, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1197, 374);
            this.dataGridView1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(552, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 46);
            this.label1.TabIndex = 7;
            this.label1.Text = "Заявки";
            // 
            // OrderNumber
            // 
            this.OrderNumber.HeaderText = "Номер заявки";
            this.OrderNumber.MinimumWidth = 6;
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            // 
            // DateOfOrder
            // 
            this.DateOfOrder.HeaderText = "Дата заключения";
            this.DateOfOrder.MinimumWidth = 6;
            this.DateOfOrder.Name = "DateOfOrder";
            this.DateOfOrder.ReadOnly = true;
            // 
            // TreatieNumber
            // 
            this.TreatieNumber.HeaderText = "Номер договора";
            this.TreatieNumber.MinimumWidth = 6;
            this.TreatieNumber.Name = "TreatieNumber";
            this.TreatieNumber.ReadOnly = true;
            // 
            // Summary
            // 
            this.Summary.HeaderText = "Общая сумма заявки";
            this.Summary.MinimumWidth = 6;
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            // 
            // OrderAddress
            // 
            this.OrderAddress.HeaderText = "Полный адрес пункта назначения";
            this.OrderAddress.MinimumWidth = 6;
            this.OrderAddress.Name = "OrderAddress";
            this.OrderAddress.ReadOnly = true;
            // 
            // StartDateCheckBox
            // 
            this.StartDateCheckBox.AutoSize = true;
            this.StartDateCheckBox.Location = new System.Drawing.Point(669, 20);
            this.StartDateCheckBox.Name = "StartDateCheckBox";
            this.StartDateCheckBox.Size = new System.Drawing.Size(154, 24);
            this.StartDateCheckBox.TabIndex = 20;
            this.StartDateCheckBox.Text = "Дата заключения:";
            this.StartDateCheckBox.UseVisualStyleBackColor = true;
            this.StartDateCheckBox.CheckedChanged += new System.EventHandler(this.StartDateCheckBox_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.StartDateListBox2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.StartDateListBox1);
            this.panel2.Location = new System.Drawing.Point(669, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 109);
            this.panel2.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "По:";
            // 
            // StartDateListBox2
            // 
            this.StartDateListBox2.Enabled = false;
            this.StartDateListBox2.Location = new System.Drawing.Point(45, 65);
            this.StartDateListBox2.Name = "StartDateListBox2";
            this.StartDateListBox2.Size = new System.Drawing.Size(227, 27);
            this.StartDateListBox2.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "С:";
            // 
            // StartDateListBox1
            // 
            this.StartDateListBox1.Enabled = false;
            this.StartDateListBox1.Location = new System.Drawing.Point(45, 21);
            this.StartDateListBox1.Name = "StartDateListBox1";
            this.StartDateListBox1.Size = new System.Drawing.Size(227, 27);
            this.StartDateListBox1.TabIndex = 4;
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(8, 668);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(206, 29);
            this.ExportButton.TabIndex = 14;
            this.ExportButton.Text = "Экспортировать";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 704);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DeleteOrderButton);
            this.Controls.Add(this.EditOrderButton);
            this.Controls.Add(this.AddOrderButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Orders";
            this.Text = "Заявки";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearFilterButton;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.TextBox SummaryTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TreatieNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox OrderNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DeleteOrderButton;
        private System.Windows.Forms.Button EditOrderButton;
        private System.Windows.Forms.Button AddOrderButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn TreatieNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox StartDateCheckBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker StartDateListBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker StartDateListBox1;
        private System.Windows.Forms.Button ExportButton;
    }
}