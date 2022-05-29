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
    public partial class Counteragents : Form
    {
        public Counteragents()
        {
            InitializeComponent();

            OkpoComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            OkpoComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataGridView1.Columns[0].DataPropertyName = "ID_Customer";
            dataGridView1.Columns[1].DataPropertyName = "Organization_Name";
            dataGridView1.Columns[2].DataPropertyName = "Organization_Form";
            dataGridView1.Columns[3].DataPropertyName = "Director_FIO";
            dataGridView1.Columns[4].DataPropertyName = "Law_Address";
            dataGridView1.Columns[5].DataPropertyName = "Mail_Address";
            dataGridView1.Columns[6].DataPropertyName = "INN";
            dataGridView1.Columns[7].DataPropertyName = "KPP";
            dataGridView1.Columns[8].DataPropertyName = "Checking_Account";
            dataGridView1.Columns[9].DataPropertyName = "Korr_Account";
            dataGridView1.Columns[10].DataPropertyName = "BIK";
            dataGridView1.Columns[11].DataPropertyName = "OKPO";

        }

        private void updateTable()
        {
            List<Customer> customers = Program.db.CustomersList.ToList();
            dataGridView1.DataSource = customers;
        }

        private void AddCounteragentButton_Click(object sender, EventArgs e)
        {
            new AddCounteragent().ShowDialog();
        }

        private void EditCounteragentButton_Click(object sender, EventArgs e)
        {
            int ID_Customer = -1;
            try
            {
                ID_Customer = Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value );
            }
            catch ( Exception exception )
            {
                MessageBox.Show("Выберите запись, которую нужно изменить", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Customer customer = Program.db.CustomersList.Find( ID_Customer );

            if( customer != null )
                new AddCounteragent( customer ).ShowDialog();

        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            OrganizationNameTextBox.Text = "";
            FioTextBox.Text = "";
            LawAddressTextBox.Text = "";
            MailAddressTextBox.Text = "";
            InnTextBox.Text = "";
            KppTextBox.Text = "";
            CheckingAccountTextBox.Text = "";
            CorrAccountTextBox.Text = "";
            BikTextBox.Text = "";
            OkpoComboBox.SelectedIndex = -1;

            dataGridView1.DataSource = Program.db.CustomersList.ToList();
            dataGridView1.ClearSelection();
        }

        private void Counteragents_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
        }

        private void Counteragents_Activated(object sender, EventArgs e)
        {
            Okpo selectedOkpo = ( ( Okpo )OkpoComboBox.SelectedItem );
            List<Okpo> opkos = Program.db.OkpoList.ToList();
            OkpoComboBox.DataSource = opkos;

            if( selectedOkpo != null && opkos.Contains( selectedOkpo ) )
                OkpoComboBox.SelectedItem = selectedOkpo;
            else
                OkpoComboBox.SelectedItem = null;

            FindButton.PerformClick();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            if( String.IsNullOrWhiteSpace( OkpoComboBox.Text ) )
            {
                OkpoComboBox.SelectedItem = null;
                OkpoComboBox.SelectedIndex = -1;
            }

            if( String.IsNullOrWhiteSpace( OrganizationNameTextBox.Text ) ) OrganizationNameTextBox.Text = "";
            if( String.IsNullOrWhiteSpace( FioTextBox.Text ) ) FioTextBox.Text = "";
            if( String.IsNullOrWhiteSpace( LawAddressTextBox.Text ) ) LawAddressTextBox.Text = "";
            if( String.IsNullOrWhiteSpace( InnTextBox.Text ) ) InnTextBox.Text = "";
            if( String.IsNullOrWhiteSpace( KppTextBox.Text ) ) KppTextBox.Text = "";
            if( String.IsNullOrWhiteSpace( CorrAccountTextBox.Text ) ) CorrAccountTextBox.Text = "";
            if( String.IsNullOrWhiteSpace( CheckingAccountTextBox.Text ) ) CheckingAccountTextBox.Text = "";
            if( String.IsNullOrWhiteSpace( BikTextBox.Text ) ) BikTextBox.Text = "";

            List<Customer> allData = Program.db.CustomersList.ToList();
            List<Customer> searchResult = new List<Customer>();

            int ID_OKPO = -1;
            if (this.OkpoComboBox.SelectedItem != null)
                ID_OKPO = ( (Okpo)this.OkpoComboBox.SelectedItem ).ID_OKPO;

            foreach ( Customer customer in allData )
                if( customer.Organization_Name.ToLower().Contains( this.OrganizationNameTextBox.Text.ToLower() ) &&
                    customer.Director_FIO.ToLower().Contains( this.FioTextBox.Text.ToLower() ) &&
                    customer.Law_Address.ToLower().Contains( this.LawAddressTextBox.Text.ToLower() ) &&
                    customer.INN.ToLower().Contains( this.InnTextBox.Text.ToLower() ) &&
                    customer.KPP.ToLower().Contains( this.KppTextBox.Text.ToLower() ) &&
                    customer.Korr_Account.ToLower().Contains( this.CorrAccountTextBox.Text.ToLower() ) &&
                    customer.Checking_Account.ToLower().Contains( this.CheckingAccountTextBox.Text.ToLower() ) &&
                    customer.BIK.ToLower().Contains( this.BikTextBox.Text.ToLower() ) )
                {

                    if( ID_OKPO != -1 )
                    {
                        if( customer.ID_OKPO == ID_OKPO )
                            searchResult.Add( customer );
                    }
                    else
                        searchResult.Add( customer );
                }


            dataGridView1.DataSource = searchResult;
            dataGridView1.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Customer> CustomersForRemove = new List<Customer>();

            int ID_Customer = -1;
            try
            {
                foreach ( DataGridViewRow row in dataGridView1.SelectedRows )
                {
                    ID_Customer = Convert.ToInt32( row.Cells[0].Value );
                    Customer curCustomer = Program.db.CustomersList.Find( ID_Customer );

                    if ( curCustomer != null )
                        CustomersForRemove.Add( curCustomer );
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show( exception.Message );
            }

            if (MessageBox.Show("Вы действительно хотите удалить выбранных клиентов? Данное действие невозможно отменить!", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            // нельзя удалять клиентов, с которыми существует договор!
            // Оставим в списке тех, которых можно удалить
            List<Customer> FilteredListToRemove = new List<Customer>();
            List<int> IdCustomersWithTreties = Program.db.TreatiesList.Select( treatie => treatie.ID_Customer ).ToList();
            bool check = false; // true - если найден клиент (среди удаляемых) с договором
            foreach ( var customer in CustomersForRemove )
            {
                if ( IdCustomersWithTreties.Contains( customer.ID_Customer ) )
                    check = true;
                else
                    FilteredListToRemove.Add( customer );
            }

            if ( FilteredListToRemove.Count() > 0 && check )
            {
                if (MessageBox.Show("Среди выбранных клиентов есть те, с кем заключен договор! Чтобы удалить клиента, сначала удалите соответствующий договор!\n\nУдалить клиентов, которые не вызвали такого конфликта?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No)
                    return;
            }
            else if ( FilteredListToRemove.Count() == 0 && check )
                MessageBox.Show("Невозможно выполнить удаление. Выбранное оборудование приобретено в лизинг!");

            // deleting
            foreach (var item in FilteredListToRemove )
                Program.db.Remove( item );

            Program.db.SaveChanges();
            this.FindButton.PerformClick();
        }
    }
}
