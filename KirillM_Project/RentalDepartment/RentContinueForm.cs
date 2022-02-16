using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalDepartment
{
    public partial class RentContinueForm : Form
    {
        private string sqlquery;
        NpgsqlCommand cmd;
        private int idContract = -1;

        private void ShowDataInDataGridView(DataGridView dgv)
        {
            DataTable dt;
            using (cmd = new NpgsqlCommand(sqlquery, Program.connection))
            {
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgv.DataSource = null;
                dgv.DataSource = dt;
            }
        }

        public RentContinueForm()
        {
            InitializeComponent();
            sqlquery = "select " +
                "\"RentContract\".\"idRentContract\", " +
                "\"RentContract\".\"DateOfRentStart\", " +
                "\"RentContract\".\"DateOfRentFinish\", " +
                "\"Client\".\"FIO\" as \"клиент\", " +
                "\"Administrator\".\"FIO\" as \"администратор\", " +
                "\"RentalObject\".\"Name\" as \"объект\", " +
                "\"RentContract\".\"RentPrice\"" +
                "from \"RentContract\" inner join \"Administrator\" ON \"Administrator\".\"idAdministrator\" = \"RentContract\".\"idAdministrator\"" +
                "inner join \"Client\" ON \"Client\".\"idClient\" = \"RentContract\".\"idClient\"" +
                "inner join \"RentalObject\" ON \"RentalObject\".\"idRentalObject\" = \"RentContract\".\"idRentalObject\"; ";
            ShowDataInDataGridView(dataGridView1);
            dataGridView1.Columns["idRentContract"].Visible = false;
            dataGridView1.Columns["DateOfRentStart"].HeaderCell.Value = "дата начала";
            dataGridView1.Columns["DateOfRentFinish"].HeaderCell.Value = "дата конца";
            dataGridView1.Columns["RentPrice"].HeaderCell.Value = "сумма";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idContract = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idRentContract"].Value);
                //MessageBox.Show(idObject.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (idContract > -1)
            {
                DateTime rentContinueDate = dateTimePicker1.Value;
                sqlquery = $"SELECT public.contract_continue_operation(" +
                    $"{idContract}," +
                    $"'{rentContinueDate.Year}-{rentContinueDate.Month}-{rentContinueDate.Day}'" +
                    $"); ";
                using (cmd = new NpgsqlCommand(sqlquery, Program.connection))
                    cmd.ExecuteNonQuery();
                sqlquery = "select " +
                "\"RentContract\".\"idRentContract\", " +
                "\"RentContract\".\"DateOfRentStart\", " +
                "\"RentContract\".\"DateOfRentFinish\", " +
                "\"Client\".\"FIO\" as \"клиент\", " +
                "\"Administrator\".\"FIO\" as \"администратор\", " +
                "\"RentalObject\".\"Name\" as \"объект\", " +
                "\"RentContract\".\"RentPrice\"" +
                "from \"RentContract\" inner join \"Administrator\" ON \"Administrator\".\"idAdministrator\" = \"RentContract\".\"idAdministrator\"" +
                "inner join \"Client\" ON \"Client\".\"idClient\" = \"RentContract\".\"idClient\"" +
                "inner join \"RentalObject\" ON \"RentalObject\".\"idRentalObject\" = \"RentContract\".\"idRentalObject\"; ";
                ShowDataInDataGridView(dataGridView1);
            } else
                MessageBox.Show("Выберете контракт для продления");

        }
    }
}
