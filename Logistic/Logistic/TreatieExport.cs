using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using Logistic.Models;
using Logistic.Additions;

namespace Logistic
{
    public partial class TreatieExport : Form
    {

        private Treatie treatie = null;
        private Customer customer = null;

        OfficeExport.ExportData exportData;
        OfficeExport officeExport;

        public TreatieExport(Treatie _treatie = null)
        {
            InitializeComponent();

            textBox1.BackColor = ClaimsDaysTextBox.BackColor = SwapDaysTextBox.BackColor = SupplyDaysTextBox.BackColor = FinetextBox.BackColor = CustomerTextBox.BackColor = CustomerTextBox.BackColor = Color.White;
            textBox1.ForeColor = ClaimsDaysTextBox.ForeColor = SwapDaysTextBox.ForeColor = SupplyDaysTextBox.ForeColor = FinetextBox.ForeColor = CustomerTextBox.ForeColor = CustomerTextBox.ForeColor = Color.White;

            ForceEntryDatePicker.BackColor = UntilDatePicker.BackColor  = Color.White;
            ForceEntryDatePicker.ForeColor = UntilDatePicker.ForeColor = Color.Black;

            treatie = _treatie;
        }

		public static string DateToString(DateTime date, string yearSpec = null)
		{
			// yearSpec = "г."
			// yearSpec = "года"

			string res = "";

			res += "«" + date.Day + "» ";
			//DateTimeFormat.MonthGenitiveNames
			res += CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames[date.Month - 1].ToLower();

			res += " " + date.Year;

			if (yearSpec != null) res += " " + yearSpec;

			return res;
		}

		private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TreatieExport_Load(object sender, EventArgs e)
        {
            if( treatie == null ) return;


            TreatieNumberBox.Text = treatie.Number_Of_Treatie;
            ClaimsDaysTextBox.Text = treatie.Claims_Days.ToString();
            SwapDaysTextBox.Text = treatie.Swap_Days.ToString();
            SupplyDaysTextBox.Text = treatie.Supply_Delay.ToString();
            FinetextBox.Text = treatie.Fine.ToString();
            ForceEntryDatePicker.Value = treatie.Start_Date.Date;
            UntilDatePicker.Value = treatie.End_Date.Date;
			CustomerTextBox.Text = treatie.customer.Organization_Name;
			OrganizationDirectorLabel.Text = treatie.customer.Director_FIO;
			OrganizationINNLabel.Text = treatie.customer.INN;
			OrganizationNameLabel.Text = treatie.customer.Organization_Name;

        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (treatie == null)
            {
                MessageBox.Show("Что-то пошло не так! Не найден договор для экспорта...");
                return;
            }


            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Документ Word (*.doc)|*.doc",
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                buttonExport.Enabled = false;

                ExportDoc( saveFileDialog.FileName );

                officeExport = new OfficeExport( exportData );
                officeExport.ReplaceText();
				officeExport.Close();
				buttonExport.Enabled = true;
			}
        }

       
		private void ExportDoc(string nameFileExport) {

			exportData = new OfficeExport.ExportData();

			exportData.nameFileTemplate = Application.StartupPath + "..\\..\\..\\templates\\treatie_template.doc";
			exportData.nameFileExport = nameFileExport;         
			exportData.textToReplace = new List<string>() {
				"[<номер_договора>]",						
				"[<шапка_город>]",							
				"[<шапка_дата>]",							
				"[<шапка_наименование_организации>]",		
				"[<шапка_фио_директора>]",

				"[<2.1_дата_окончания_договора>]",

				"[<3_дней_на_замену>]",

				"[<6_задержка_поставки>]",
				"[<6_пеня_1>]", 		
				"[<6_пеня_2>]",

				"[<8_дней_на_претензию>]",

				"[<9_дней_на_претензию>]",

				"[<10_дата_окончания_договора>]",

				"[<12_наименование_организации>]",
				"[<12_инн>]",
				"[<12_кпп>]",
				"[<12_юр_адрес>]",
				"[<12_почт_адрес>]",
				"[<12_рас_счёт>]",
				"[<12_кор_счёт>]",
				"[<12_бик>]",
				"[<12_окпо>]",
				"[<12_фио_директора>]"
			};


			exportData.textReplaceWith = new List<string>() {
				treatie.Number_Of_Treatie,
				"г. Барнаул",
				DateToString( treatie.Start_Date, "г." ),
				treatie.customer.Organization_Form + " " + treatie.customer.Organization_Name,
				treatie.customer.Director_FIO,

				DateToString( treatie.End_Date, "г." ),
				
				treatie.Swap_Days.ToString(),

				treatie.Supply_Delay.ToString(),
				treatie.Fine.ToString(),
				treatie.Fine.ToString(),

				treatie.Claims_Days.ToString(),

				treatie.Claims_Days.ToString(),

				DateToString( treatie.End_Date, "г." ),

				treatie.customer.Organization_Form + " " + treatie.customer.Organization_Name,
				treatie.customer.INN,
				treatie.customer.KPP,
				treatie.customer.Law_Address,
				treatie.customer.Mail_Address,
				treatie.customer.Checking_Account,
				treatie.customer.Korr_Account,
				treatie.customer.BIK,
				treatie.customer.okpo.OKPO,
				treatie.customer.Director_FIO
			};

			// если надо открыть файл после экспорта автоматически
			exportData.openFileExport = true;
		}
    }
}
