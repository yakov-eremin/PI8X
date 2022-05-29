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
    public partial class TreatieRegistry : Form
    {
        public TreatieRegistry()
        {
            InitializeComponent();

            CounteragentListBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CounteragentListBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dataGridView1.Columns[0].DataPropertyName = "ID_Treatie";
            dataGridView1.Columns[1].DataPropertyName = "Number_Of_Treatie";
            dataGridView1.Columns[2].DataPropertyName = "Start_Date";
            dataGridView1.Columns[3].DataPropertyName = "End_Date";
            dataGridView1.Columns[4].DataPropertyName = "Customer";
            dataGridView1.Columns[5].DataPropertyName = "Summary";
            dataGridView1.Columns[6].DataPropertyName = "Status";
        }

        private void updateTable()
        {
            List<Treatie> treaties = Program.db.TreatiesList.ToList();
            dataGridView1.DataSource = treaties;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int ID_Treatie = -1;
            try
            {
                ID_Treatie = Convert.ToInt32( dataGridView1.SelectedRows[0].Cells[0].Value );
            }
            catch ( Exception exception )
            {
                MessageBox.Show("Выберите запись, которую нужно изменить", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Treatie treatie = Program.db.TreatiesList.Find( ID_Treatie );

            if( treatie != null )
                new TreatieEdit( treatie ).ShowDialog();
        }

        private void StartDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (StartDateCheckBox.Checked == false)
            {
                StartDateListBox1.Enabled = false;
                StartDateListBox2.Enabled = false;
            }
            else 
            {
                StartDateListBox1.Enabled = true;
                StartDateListBox2.Enabled = true;
            }
        }

        private void EndDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EndDateCheckBox.Checked == false)
            {
                EndDateListBox1.Enabled = false;
                EndDateListBox2.Enabled = false;
            }
            else
            {
                EndDateListBox1.Enabled = true;
                EndDateListBox2.Enabled = true;
            }
        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            TreatieNumberTextBox.Text = "";
            CounteragentListBox.Text = "";
            CounteragentListBox.SelectedIndex = -1;
            SummaryTextBox.Text = "";
            StatusListBox.SelectedItem = "Не выбрано";
            StartDateCheckBox.Checked = false;
            EndDateCheckBox.Checked = false;

            FindButton.PerformClick();
        }

        private void ExportTreatieButton_Click(object sender, EventArgs e)
        {
            int ID_Treatie = -1;
            try
            {
                ID_Treatie = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Выберите запись, к которой нужно перейти", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Treatie treatie = Program.db.TreatiesList.Find(ID_Treatie);

            if (treatie != null)
                new TreatieExport(treatie).ShowDialog();
        }

        private void TreatieRegistry_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ReadOnly = true;
        }

        private void TreatieRegistry_Activated(object sender, EventArgs e)
        {
            Customer selectedCustomer = ( ( Customer )CounteragentListBox.SelectedItem );
            List<Customer> customers = Program.db.CustomersList.ToList();
            CounteragentListBox.DataSource = customers;

            if( selectedCustomer != null && customers.Contains( selectedCustomer ) )
                CounteragentListBox.SelectedItem = selectedCustomer;
            else
                CounteragentListBox.SelectedItem = null;

            FindButton.PerformClick();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            if( String.IsNullOrWhiteSpace( CounteragentListBox.Text ) )
            {
                CounteragentListBox.SelectedItem = null;
                CounteragentListBox.SelectedIndex = -1;
            }

            if( String.IsNullOrWhiteSpace( StatusListBox.Text ) || StatusListBox.SelectedItem == null || StatusListBox.SelectedIndex == -1 )
            {
                StatusListBox.SelectedIndex = 0;
            }

            if( String.IsNullOrWhiteSpace( TreatieNumberTextBox.Text ) ) TreatieNumberTextBox.Text = "";
            if( String.IsNullOrWhiteSpace( SummaryTextBox.Text ) ) SummaryTextBox.Text = "";

            Decimal summary = -1;
            try
            {
                summary = Decimal.Parse( SummaryTextBox.Text );

                if (summary < 0)
                    throw new Exception();
            }
            catch( Exception /*exception */ )
            {
                SummaryTextBox.Text = "";
                summary = -1;
            }


            List<Treatie> allData = Program.db.TreatiesList.ToList();
            List<Treatie> searchResult = new List<Treatie>();

            int ID_Customer = -1;
            if (this.CounteragentListBox.SelectedItem != null)
                ID_Customer = ( (Customer)this.CounteragentListBox.SelectedItem ).ID_Customer;

            bool checkStartDate = this.StartDateCheckBox.Checked;
            bool checkEndDate = this.EndDateCheckBox.Checked;

                      
            foreach (Treatie item in allData )
            {
                if (StatusListBox.SelectedIndex > 0 && item.Status != StatusListBox.Text)
                    continue;

                if( checkStartDate && ( item.Start_Date < StartDateListBox1.Value.Date || item.Start_Date > StartDateListBox2.Value.Date ) )
                    continue;

                if( checkEndDate && ( item.End_Date < EndDateListBox1.Value.Date || item.End_Date > EndDateListBox2.Value.Date ) )
                    continue;

                if (ID_Customer != -1 && item.ID_Customer != ID_Customer)
                    continue;
                
                if( !item.Number_Of_Treatie.ToLower().Contains( TreatieNumberTextBox.Text.ToLower() ) )
                    continue;

                if( summary >= 0 && item.Summary != summary )
                    continue;


                searchResult.Add(item);
            }


            dataGridView1.DataSource = searchResult;
            dataGridView1.ClearSelection();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Treatie> TreatiesForRemove = new List<Treatie>();

            int ID_Treatie = -1;
            try
            {
                foreach ( DataGridViewRow row in dataGridView1.SelectedRows )
                {
                    ID_Treatie = Convert.ToInt32( row.Cells[0].Value );
                    Treatie curTreatie = Program.db.TreatiesList.Find( ID_Treatie );

                    if ( curTreatie != null )
                        TreatiesForRemove.Add( curTreatie );
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show( exception.Message );
                return;
            }

            if (MessageBox.Show("Вы действительно хотите удалить выбранные договоры? Данное действие невозможно отменить!", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            // deleting
            foreach ( var item in TreatiesForRemove )
                Program.db.Remove( item );

            Program.db.SaveChanges();
            FindButton.PerformClick();
        }
    }
}
