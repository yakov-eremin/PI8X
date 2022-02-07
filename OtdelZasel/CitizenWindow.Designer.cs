
namespace OtdelZasel
{
    partial class CitizenWindow
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label_write_petition = new System.Windows.Forms.Label();
            this.richTextBox_Petition = new System.Windows.Forms.RichTextBox();
            this.button_sendCheckInPetiton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label_reason = new System.Windows.Forms.Label();
            this.comboBox_LeavingReason = new System.Windows.Forms.ComboBox();
            this.button_send_PetitonOut = new System.Windows.Forms.Button();
            this.label_write_PetitionOut = new System.Windows.Forms.Label();
            this.richTextBox_PetitonOut = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label_ОплатаЗаПроживание = new System.Windows.Forms.Label();
            this.label_Balance2 = new System.Windows.Forms.Label();
            this.label_Balance = new System.Windows.Forms.Label();
            this.button_pay = new System.Windows.Forms.Button();
            this.numericUpDown_Sum = new System.Windows.Forms.NumericUpDown();
            this.label_Sum = new System.Windows.Forms.Label();
            this.textBox_CVV = new System.Windows.Forms.TextBox();
            this.textBox_BankCard = new System.Windows.Forms.TextBox();
            this.label_CVV = new System.Windows.Forms.Label();
            this.Label_BankCard = new System.Windows.Forms.Label();
            this.tabPage_information = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Cipher = new System.Windows.Forms.Label();
            this.label_ActiveKey = new System.Windows.Forms.Label();
            this.dataGridView_livingInfo = new System.Windows.Forms.DataGridView();
            this.tabPage_PetitionsRMassages = new System.Windows.Forms.TabPage();
            this.label_answerOfPetitions = new System.Windows.Forms.Label();
            this.dataGridView_PetitionRMessages = new System.Windows.Forms.DataGridView();
            this.label_write_reason = new System.Windows.Forms.Label();
            this.label_CitizenName = new System.Windows.Forms.Label();
            this.label_CitizenFIO = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sum)).BeginInit();
            this.tabPage_information.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_livingInfo)).BeginInit();
            this.tabPage_PetitionsRMassages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PetitionRMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage_information);
            this.tabControl1.Controls.Add(this.tabPage_PetitionsRMassages);
            this.tabControl1.Location = new System.Drawing.Point(12, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(945, 607);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label_write_petition);
            this.tabPage1.Controls.Add(this.richTextBox_Petition);
            this.tabPage1.Controls.Add(this.button_sendCheckInPetiton);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(937, 579);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Заявление на заселение";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label_write_petition
            // 
            this.label_write_petition.AutoSize = true;
            this.label_write_petition.Location = new System.Drawing.Point(17, 15);
            this.label_write_petition.Name = "label_write_petition";
            this.label_write_petition.Size = new System.Drawing.Size(215, 15);
            this.label_write_petition.TabIndex = 3;
            this.label_write_petition.Text = "Введите текст заявления на заселение";
            // 
            // richTextBox_Petition
            // 
            this.richTextBox_Petition.Location = new System.Drawing.Point(17, 33);
            this.richTextBox_Petition.Name = "richTextBox_Petition";
            this.richTextBox_Petition.Size = new System.Drawing.Size(450, 450);
            this.richTextBox_Petition.TabIndex = 1;
            this.richTextBox_Petition.Text = "";
            // 
            // button_sendCheckInPetiton
            // 
            this.button_sendCheckInPetiton.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_sendCheckInPetiton.Location = new System.Drawing.Point(615, 437);
            this.button_sendCheckInPetiton.Name = "button_sendCheckInPetiton";
            this.button_sendCheckInPetiton.Size = new System.Drawing.Size(211, 46);
            this.button_sendCheckInPetiton.TabIndex = 2;
            this.button_sendCheckInPetiton.Text = "Подать заявление";
            this.button_sendCheckInPetiton.UseVisualStyleBackColor = true;
            this.button_sendCheckInPetiton.Click += new System.EventHandler(this.button_send_petiton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label_reason);
            this.tabPage3.Controls.Add(this.comboBox_LeavingReason);
            this.tabPage3.Controls.Add(this.button_send_PetitonOut);
            this.tabPage3.Controls.Add(this.label_write_PetitionOut);
            this.tabPage3.Controls.Add(this.richTextBox_PetitonOut);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(937, 579);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Заявление на выселение";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label_reason
            // 
            this.label_reason.AutoSize = true;
            this.label_reason.Location = new System.Drawing.Point(510, 15);
            this.label_reason.Name = "label_reason";
            this.label_reason.Size = new System.Drawing.Size(175, 15);
            this.label_reason.TabIndex = 5;
            this.label_reason.Text = "Выберите причину выселения";
            // 
            // comboBox_LeavingReason
            // 
            this.comboBox_LeavingReason.FormattingEnabled = true;
            this.comboBox_LeavingReason.Location = new System.Drawing.Point(514, 33);
            this.comboBox_LeavingReason.Name = "comboBox_LeavingReason";
            this.comboBox_LeavingReason.Size = new System.Drawing.Size(311, 23);
            this.comboBox_LeavingReason.TabIndex = 4;
            // 
            // button_send_PetitonOut
            // 
            this.button_send_PetitonOut.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_send_PetitonOut.Location = new System.Drawing.Point(614, 437);
            this.button_send_PetitonOut.Name = "button_send_PetitonOut";
            this.button_send_PetitonOut.Size = new System.Drawing.Size(211, 46);
            this.button_send_PetitonOut.TabIndex = 5;
            this.button_send_PetitonOut.Text = "Подать заявление";
            this.button_send_PetitonOut.UseVisualStyleBackColor = true;
            this.button_send_PetitonOut.Click += new System.EventHandler(this.button_send_PetitonOut_Click);
            // 
            // label_write_PetitionOut
            // 
            this.label_write_PetitionOut.AutoSize = true;
            this.label_write_PetitionOut.Location = new System.Drawing.Point(15, 15);
            this.label_write_PetitionOut.Name = "label_write_PetitionOut";
            this.label_write_PetitionOut.Size = new System.Drawing.Size(219, 15);
            this.label_write_PetitionOut.TabIndex = 1;
            this.label_write_PetitionOut.Text = "Введите текст заявления на выселение";
            // 
            // richTextBox_PetitonOut
            // 
            this.richTextBox_PetitonOut.Location = new System.Drawing.Point(15, 33);
            this.richTextBox_PetitonOut.Name = "richTextBox_PetitonOut";
            this.richTextBox_PetitonOut.Size = new System.Drawing.Size(450, 450);
            this.richTextBox_PetitonOut.TabIndex = 0;
            this.richTextBox_PetitonOut.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label_ОплатаЗаПроживание);
            this.tabPage2.Controls.Add(this.label_Balance2);
            this.tabPage2.Controls.Add(this.label_Balance);
            this.tabPage2.Controls.Add(this.button_pay);
            this.tabPage2.Controls.Add(this.numericUpDown_Sum);
            this.tabPage2.Controls.Add(this.label_Sum);
            this.tabPage2.Controls.Add(this.textBox_CVV);
            this.tabPage2.Controls.Add(this.textBox_BankCard);
            this.tabPage2.Controls.Add(this.label_CVV);
            this.tabPage2.Controls.Add(this.Label_BankCard);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(937, 579);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Оплата проживания";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // label_ОплатаЗаПроживание
            // 
            this.label_ОплатаЗаПроживание.AutoSize = true;
            this.label_ОплатаЗаПроживание.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_ОплатаЗаПроживание.Location = new System.Drawing.Point(39, 31);
            this.label_ОплатаЗаПроживание.Name = "label_ОплатаЗаПроживание";
            this.label_ОплатаЗаПроживание.Size = new System.Drawing.Size(191, 20);
            this.label_ОплатаЗаПроживание.TabIndex = 11;
            this.label_ОплатаЗаПроживание.Text = "Заплатить за проживание";
            // 
            // label_Balance2
            // 
            this.label_Balance2.AutoSize = true;
            this.label_Balance2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.label_Balance2.Location = new System.Drawing.Point(778, 31);
            this.label_Balance2.Name = "label_Balance2";
            this.label_Balance2.Size = new System.Drawing.Size(58, 20);
            this.label_Balance2.TabIndex = 10;
            this.label_Balance2.Text = "Баланс";
            // 
            // label_Balance
            // 
            this.label_Balance.AutoSize = true;
            this.label_Balance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Balance.Location = new System.Drawing.Point(593, 31);
            this.label_Balance.Name = "label_Balance";
            this.label_Balance.Size = new System.Drawing.Size(166, 20);
            this.label_Balance.TabIndex = 9;
            this.label_Balance.Text = "Ваш баланс (рублей):";
            // 
            // button_pay
            // 
            this.button_pay.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_pay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_pay.Location = new System.Drawing.Point(197, 197);
            this.button_pay.Name = "button_pay";
            this.button_pay.Size = new System.Drawing.Size(229, 65);
            this.button_pay.TabIndex = 8;
            this.button_pay.Text = "Оплатить";
            this.button_pay.UseVisualStyleBackColor = true;
            this.button_pay.Click += new System.EventHandler(this.button_pay_Click);
            // 
            // numericUpDown_Sum
            // 
            this.numericUpDown_Sum.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_Sum.Location = new System.Drawing.Point(197, 140);
            this.numericUpDown_Sum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Sum.Name = "numericUpDown_Sum";
            this.numericUpDown_Sum.Size = new System.Drawing.Size(229, 23);
            this.numericUpDown_Sum.TabIndex = 7;
            this.numericUpDown_Sum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_Sum
            // 
            this.label_Sum.AutoSize = true;
            this.label_Sum.Location = new System.Drawing.Point(143, 140);
            this.label_Sum.Name = "label_Sum";
            this.label_Sum.Size = new System.Drawing.Size(48, 15);
            this.label_Sum.TabIndex = 5;
            this.label_Sum.Text = "Сумма:";
            // 
            // textBox_CVV
            // 
            this.textBox_CVV.Location = new System.Drawing.Point(197, 108);
            this.textBox_CVV.Name = "textBox_CVV";
            this.textBox_CVV.Size = new System.Drawing.Size(229, 23);
            this.textBox_CVV.TabIndex = 3;
            this.textBox_CVV.UseSystemPasswordChar = true;
            // 
            // textBox_BankCard
            // 
            this.textBox_BankCard.Location = new System.Drawing.Point(197, 79);
            this.textBox_BankCard.Name = "textBox_BankCard";
            this.textBox_BankCard.Size = new System.Drawing.Size(229, 23);
            this.textBox_BankCard.TabIndex = 2;
            // 
            // label_CVV
            // 
            this.label_CVV.AutoSize = true;
            this.label_CVV.Location = new System.Drawing.Point(128, 111);
            this.label_CVV.Name = "label_CVV";
            this.label_CVV.Size = new System.Drawing.Size(63, 15);
            this.label_CVV.TabIndex = 1;
            this.label_CVV.Text = "CVV/CVC :";
            // 
            // Label_BankCard
            // 
            this.Label_BankCard.AutoSize = true;
            this.Label_BankCard.Location = new System.Drawing.Point(39, 82);
            this.Label_BankCard.Name = "Label_BankCard";
            this.Label_BankCard.Size = new System.Drawing.Size(152, 15);
            this.Label_BankCard.TabIndex = 0;
            this.Label_BankCard.Text = "Номер банковской карты:";
            // 
            // tabPage_information
            // 
            this.tabPage_information.Controls.Add(this.label1);
            this.tabPage_information.Controls.Add(this.label_Cipher);
            this.tabPage_information.Controls.Add(this.label_ActiveKey);
            this.tabPage_information.Controls.Add(this.dataGridView_livingInfo);
            this.tabPage_information.Location = new System.Drawing.Point(4, 24);
            this.tabPage_information.Name = "tabPage_information";
            this.tabPage_information.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_information.Size = new System.Drawing.Size(937, 579);
            this.tabPage_information.TabIndex = 3;
            this.tabPage_information.Text = "Сведения о проживании";
            this.tabPage_information.UseVisualStyleBackColor = true;
            this.tabPage_information.Enter += new System.EventHandler(this.tabPage_information_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Список записей о проживании";
            // 
            // label_Cipher
            // 
            this.label_Cipher.AutoSize = true;
            this.label_Cipher.Location = new System.Drawing.Point(568, 27);
            this.label_Cipher.Name = "label_Cipher";
            this.label_Cipher.Size = new System.Drawing.Size(91, 15);
            this.label_Cipher.TabIndex = 2;
            this.label_Cipher.Text = "Ключ не выдан";
            // 
            // label_ActiveKey
            // 
            this.label_ActiveKey.AutoSize = true;
            this.label_ActiveKey.Location = new System.Drawing.Point(395, 27);
            this.label_ActiveKey.Name = "label_ActiveKey";
            this.label_ActiveKey.Size = new System.Drawing.Size(155, 15);
            this.label_ActiveKey.TabIndex = 1;
            this.label_ActiveKey.Text = "Активный ключ для места:";
            // 
            // dataGridView_livingInfo
            // 
            this.dataGridView_livingInfo.AllowUserToAddRows = false;
            this.dataGridView_livingInfo.AllowUserToDeleteRows = false;
            this.dataGridView_livingInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_livingInfo.Location = new System.Drawing.Point(6, 50);
            this.dataGridView_livingInfo.Name = "dataGridView_livingInfo";
            this.dataGridView_livingInfo.ReadOnly = true;
            this.dataGridView_livingInfo.RowTemplate.Height = 25;
            this.dataGridView_livingInfo.Size = new System.Drawing.Size(925, 523);
            this.dataGridView_livingInfo.TabIndex = 0;
            // 
            // tabPage_PetitionsRMassages
            // 
            this.tabPage_PetitionsRMassages.Controls.Add(this.label_answerOfPetitions);
            this.tabPage_PetitionsRMassages.Controls.Add(this.dataGridView_PetitionRMessages);
            this.tabPage_PetitionsRMassages.Location = new System.Drawing.Point(4, 24);
            this.tabPage_PetitionsRMassages.Name = "tabPage_PetitionsRMassages";
            this.tabPage_PetitionsRMassages.Size = new System.Drawing.Size(937, 579);
            this.tabPage_PetitionsRMassages.TabIndex = 4;
            this.tabPage_PetitionsRMassages.Text = "Ответы на заявления";
            this.tabPage_PetitionsRMassages.UseVisualStyleBackColor = true;
            this.tabPage_PetitionsRMassages.Enter += new System.EventHandler(this.tabPage_PetitionsRMassages_Enter);
            // 
            // label_answerOfPetitions
            // 
            this.label_answerOfPetitions.AutoSize = true;
            this.label_answerOfPetitions.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_answerOfPetitions.Location = new System.Drawing.Point(9, 16);
            this.label_answerOfPetitions.Name = "label_answerOfPetitions";
            this.label_answerOfPetitions.Size = new System.Drawing.Size(258, 20);
            this.label_answerOfPetitions.TabIndex = 4;
            this.label_answerOfPetitions.Text = "Список заявлений и ответов на них";
            // 
            // dataGridView_PetitionRMessages
            // 
            this.dataGridView_PetitionRMessages.AllowUserToAddRows = false;
            this.dataGridView_PetitionRMessages.AllowUserToDeleteRows = false;
            this.dataGridView_PetitionRMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PetitionRMessages.Location = new System.Drawing.Point(9, 39);
            this.dataGridView_PetitionRMessages.Name = "dataGridView_PetitionRMessages";
            this.dataGridView_PetitionRMessages.ReadOnly = true;
            this.dataGridView_PetitionRMessages.RowTemplate.Height = 25;
            this.dataGridView_PetitionRMessages.Size = new System.Drawing.Size(925, 537);
            this.dataGridView_PetitionRMessages.TabIndex = 1;
            // 
            // label_write_reason
            // 
            this.label_write_reason.Location = new System.Drawing.Point(0, 0);
            this.label_write_reason.Name = "label_write_reason";
            this.label_write_reason.Size = new System.Drawing.Size(100, 23);
            this.label_write_reason.TabIndex = 0;
            // 
            // label_CitizenName
            // 
            this.label_CitizenName.AutoSize = true;
            this.label_CitizenName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_CitizenName.Location = new System.Drawing.Point(442, 9);
            this.label_CitizenName.Name = "label_CitizenName";
            this.label_CitizenName.Size = new System.Drawing.Size(111, 20);
            this.label_CitizenName.TabIndex = 1;
            this.label_CitizenName.Text = "Пользователь";
            // 
            // label_CitizenFIO
            // 
            this.label_CitizenFIO.AutoSize = true;
            this.label_CitizenFIO.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_CitizenFIO.Location = new System.Drawing.Point(584, 9);
            this.label_CitizenFIO.Name = "label_CitizenFIO";
            this.label_CitizenFIO.Size = new System.Drawing.Size(0, 20);
            this.label_CitizenFIO.TabIndex = 2;
            // 
            // CitizenWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 668);
            this.Controls.Add(this.label_CitizenFIO);
            this.Controls.Add(this.label_CitizenName);
            this.Controls.Add(this.tabControl1);
            this.Name = "CitizenWindow";
            this.Text = "Личный кабинет пользователя                                                      " +
    "                                        Отдел по заселению в муниципальные общеж" +
    "ития";
            this.Load += new System.EventHandler(this.CitizenWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sum)).EndInit();
            this.tabPage_information.ResumeLayout(false);
            this.tabPage_information.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_livingInfo)).EndInit();
            this.tabPage_PetitionsRMassages.ResumeLayout(false);
            this.tabPage_PetitionsRMassages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PetitionRMessages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button_sendCheckInPetiton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label_write_petition;
        private System.Windows.Forms.RichTextBox richTextBox_Petition;
        private System.Windows.Forms.Button button_send_PetitonOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_write_PetitionOut;
        private System.Windows.Forms.RichTextBox richTextBox_PetitonOut;
        private System.Windows.Forms.ComboBox comboBox_LeavingReason;
        private System.Windows.Forms.Label label_write_reason;
        private System.Windows.Forms.Label Label_BankCard;
        private System.Windows.Forms.TextBox textBox_BankCard;
        private System.Windows.Forms.NumericUpDown numericUpDown_Sum;
        private System.Windows.Forms.Label label_Sum;
        private System.Windows.Forms.TextBox textBox_CVV;
        private System.Windows.Forms.Button button_pay;
        private System.Windows.Forms.Label label_Balance2;
        private System.Windows.Forms.Label label_Balance;
        private System.Windows.Forms.Label label_CVV;
        private System.Windows.Forms.Label label_reason;
        private System.Windows.Forms.Label label_CitizenName;
        private System.Windows.Forms.Label label_CitizenFIO;
        private System.Windows.Forms.TabPage tabPage_information;
        private System.Windows.Forms.DataGridView dataGridView_livingInfo;
        private System.Windows.Forms.Label label_Cipher;
        private System.Windows.Forms.Label label_ActiveKey;
        private System.Windows.Forms.TabPage tabPage_PetitionsRMassages;
        private System.Windows.Forms.Label label_answerOfPetitions;
        private System.Windows.Forms.DataGridView dataGridView_PetitionRMessages;
        private System.Windows.Forms.Label label_ОплатаЗаПроживание;
    }
}