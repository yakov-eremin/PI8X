using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Logistic.Models;

namespace Logistic
{
    public partial class AddCounteragent : Form
    {
        private Customer EditCustomer = null;

        public AddCounteragent( Customer customer = null  )
        {
            InitializeComponent();

            OkpoComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            OkpoComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            List<Okpo> okpos = Program.db.OkpoList.ToList();
            OkpoComboBox.DataSource = okpos;
            OkpoComboBox.AutoCompleteCustomSource.AddRange( okpos.Select(i => i.ID_OKPO.ToString() ).ToArray() ) ;
            OkpoComboBox.SelectedIndex = -1;

            if( customer != null )
            {
                this.Text = "Редактировать клиента";
                this.AddButton.Text = "Изменить";

                OrganizationNameTextBox.Text = customer.Organization_Name;
                OrganizationFormTextBox.Text = customer.Organization_Form;
                FioTextBox.Text = customer.Director_FIO;
                LawAddressTextBox.Text = customer.Law_Address;
                MailAddressTextBox.Text = customer.Mail_Address;
                InnTextBox.Text = customer.INN;
                KppTextBox.Text = customer.KPP;
                CheckingAccountTextBox.Text = customer.Checking_Account;
                CorrAccountTextBox.Text = customer.Korr_Account;
                BikTextBox.Text = customer.BIK;

                Okpo okpo = Program.db.OkpoList.Find( customer.ID_OKPO );
                OkpoComboBox.SelectedItem = okpo;

                //Fias fias = Program.db.FiasList.Find( customer.ID_FIAS );
                //FiasComboBox.SelectedItem = fias;
            }

            this.EditCustomer = customer;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool addOrEditNewCustomer()
        {
            if ( String.IsNullOrWhiteSpace( OrganizationNameTextBox.Text ) ||
                String.IsNullOrWhiteSpace( OrganizationFormTextBox.Text ) ||
                String.IsNullOrWhiteSpace( FioTextBox.Text ) ||
                String.IsNullOrWhiteSpace( LawAddressTextBox.Text ) ||
                String.IsNullOrWhiteSpace( MailAddressTextBox.Text ) ||
                String.IsNullOrWhiteSpace( InnTextBox.Text ) ||
                String.IsNullOrWhiteSpace( KppTextBox.Text ) ||
                String.IsNullOrWhiteSpace( CheckingAccountTextBox.Text ) ||
                String.IsNullOrWhiteSpace( CorrAccountTextBox.Text ) ||
                String.IsNullOrWhiteSpace( BikTextBox.Text ) ||
                OkpoComboBox.SelectedItem == null || OkpoComboBox.SelectedIndex == -1 // ||
                //FiasComboBox.SelectedItem == null || FiasComboBox.SelectedIndex == -1)
                )
            {
                MessageBox.Show("Чтобы добавить запись заполните все поля!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            bool EditMode = this.EditCustomer != null;

            if (!EditMode)
                this.EditCustomer = new Customer();


            this.EditCustomer.Organization_Name = this.OrganizationNameTextBox.Text;
            this.EditCustomer.Organization_Form = this.OrganizationFormTextBox.Text;
            this.EditCustomer.Director_FIO = this.FioTextBox.Text;
            this.EditCustomer.Law_Address = this.LawAddressTextBox.Text;
            this.EditCustomer.Mail_Address = this.MailAddressTextBox.Text;
            this.EditCustomer.KPP = this.KppTextBox.Text;
            this.EditCustomer.INN = this.InnTextBox.Text;
            this.EditCustomer.Checking_Account = this.CheckingAccountTextBox.Text;
            this.EditCustomer.Korr_Account = this.CorrAccountTextBox.Text;
            this.EditCustomer.BIK = this.BikTextBox.Text;
            this.EditCustomer.ID_OKPO = ( ( Okpo )this.OkpoComboBox.SelectedItem ).ID_OKPO;
            this.EditCustomer.ID_FIAS = 1; // ( ( Fias )this.FiasComboBox.SelectedItem ).ID_FIAS;


            if( EditMode )
            {
                Program.db.CustomersList.Update( this.EditCustomer );
                MessageBox.Show( "Успешно изменено!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            else
            { 
                Program.db.CustomersList.Add( this.EditCustomer );
                MessageBox.Show( "Успешно добавлено!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information );
                
                this.EditCustomer = null;
            }

            Program.db.SaveChanges();
            return true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            addOrEditNewCustomer();
        }
    }
}
