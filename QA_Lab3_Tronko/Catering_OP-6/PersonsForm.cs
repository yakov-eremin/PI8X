using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catering_OP_6 {
	public partial class PersonsForm : Form {

		//Form Owner;

		List<PlaceHolderTextBox> placeHolderTextBoxes;


		public PersonsForm(Form form) {
			InitializeComponent();

			//Owner = form;

			placeHolderTextBoxes = new List<PlaceHolderTextBox>() {
				TextBox_Post_FinPerson,
				TextBox_Post_LeadPerson,
				TextBox_Post_LetGoPerson,
				TextBox_Post_TookPerson,
				TextBox_Post_CheckPerson,

				TextBox_FullName_FinPerson,
				TextBox_FullName_LeadPerson,
				TextBox_FullName_AccPerson,
				TextBox_FullName_LetGoPerson,
				TextBox_FullName_TookPerson,
				TextBox_FullName_CheckPerson
			};
		}

		public void ClearForm() {
			// текстбоксы с плейсхолдерами - пустая строка и установить плейсхолдер
			foreach (var item in placeHolderTextBoxes) {
				item.Text = "";
				item.setPlaceholder();
			}
		}

		public List<string> GetPosts() {
			return new List<string>() {
				TextBox_Post_FinPerson.Text,
				TextBox_Post_LeadPerson.Text,
				TextBox_Post_LetGoPerson.Text,
				TextBox_Post_TookPerson.Text,
				TextBox_Post_CheckPerson.Text,
			};
		}

		public List<string> GetFullNames() {
			return new List<string>() {
				TextBox_FullName_FinPerson.Text,
				TextBox_FullName_LeadPerson.Text,
				TextBox_FullName_AccPerson.Text,
				TextBox_FullName_LetGoPerson.Text,
				TextBox_FullName_TookPerson.Text,
				TextBox_FullName_CheckPerson.Text
			};
		}

		private void button_Save_Click(object sender, EventArgs e) {
			this.Hide();
		}
	}
}
