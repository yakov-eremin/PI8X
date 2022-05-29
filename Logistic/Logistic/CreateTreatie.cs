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
    public partial class CreateTreatie : Form
    {
        public CreateTreatie()
        {
            InitializeComponent();

            CounterAgentsComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CounterAgentsComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            List<Customer> customers = Program.db.CustomersList.ToList();
            CounterAgentsComboBox.DataSource = customers;
            CounterAgentsComboBox.AutoCompleteCustomSource.AddRange(customers.Select(i => i.ToString()).ToArray());

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CounterAgentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( this.CounterAgentsComboBox.SelectedItem != null && this.CounterAgentsComboBox.SelectedIndex > -1 )
            {
                this.OrganizationNameLabel.Text = ((Customer)this.CounterAgentsComboBox.SelectedItem).Organization_Name;
                this.OrganizationDirectorLabel.Text = ((Customer)this.CounterAgentsComboBox.SelectedItem).Director_FIO;
                this.OrganizationINNLabel.Text = ((Customer)this.CounterAgentsComboBox.SelectedItem).INN;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if ( String.IsNullOrWhiteSpace( TreatieNumberBox.Text ) ||
                String.IsNullOrWhiteSpace( ClaimsDaysTextBox.Text ) ||
                String.IsNullOrWhiteSpace( SwapDaysTextBox.Text ) ||
                String.IsNullOrWhiteSpace( SupplyDaysTextBox.Text ) ||
                String.IsNullOrWhiteSpace( FinetextBox.Text ) ||

                CounterAgentsComboBox.SelectedItem == null || CounterAgentsComboBox.SelectedIndex == -1
                )
            {
                MessageBox.Show("Чтобы изменить запись заполните все поля!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal summary = 0;
            decimal fine = -1;
            int claims = -1;
            int supply = -1;
            int swap = -1;
            try
            {
                fine = Decimal.Parse(FinetextBox.Text);
                claims = Int32.Parse(ClaimsDaysTextBox.Text);
                supply = Int32.Parse(SupplyDaysTextBox.Text);
                swap = Int32.Parse(SwapDaysTextBox.Text);

                if ( fine < 0 || summary < 0 || claims < 0 || supply < 0 || swap < 0 )
                    throw new Exception();

            }
            catch (Exception /*exception*/ )
            {
                MessageBox.Show("Числовые поля заполнены неверно!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Treatie newTreatie = new Treatie();

            newTreatie.Number_Of_Treatie = this.TreatieNumberBox.Text;
            newTreatie.Start_Date = this.ForceEntryDatePicker.Value.Date;
            newTreatie.End_Date = this.UntilDatePicker.Value.Date;
            newTreatie.Summary = summary;
            newTreatie.Status = "Активен";
            newTreatie.Claims_Days = claims;
            newTreatie.Swap_Days = swap;
            newTreatie.Supply_Delay = supply;
            newTreatie.Fine = fine;
            newTreatie.ID_Customer = ( ( Customer )this.CounterAgentsComboBox.SelectedItem ).ID_Customer;

            Program.db.TreatiesList.Add( newTreatie );
            MessageBox.Show( "Успешно Добавлено!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information );
            Program.db.SaveChanges();
        }
    }
}
