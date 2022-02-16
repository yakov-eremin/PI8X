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
    public partial class AddContractForm : Form
    {
        private string sqlquery;
        NpgsqlCommand cmd;
        private int idClient = -1;
        private int idObject = -1;
        private int idRentRegistrationSheet;
        private void ShowDataInDataGridView(DataGridView dgv)
        {
            DataTable dt;
            cmd = new NpgsqlCommand(sqlquery, Program.connection);
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dgv.DataSource = null;
            dgv.DataSource = dt;
        }

        public AddContractForm()
        {
            InitializeComponent();
            sqlquery = $"select * from actual_rent_objects;";
            ShowDataInDataGridView(objectDGV);
            sqlquery = $"select * from \"Client\";";
            ShowDataInDataGridView(clientDGV);
            sqlquery = "select MAX(\"RentRegistrationSheet\".\"idRentRegistrationSheet\") from \"RentRegistrationSheet\"; ";
            cmd = new NpgsqlCommand(sqlquery, Program.connection);
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                idRentRegistrationSheet = Convert.ToInt32(reader["max"]) + 1;
            }
            clientDGV.Columns["idClient"].Visible = false;
            clientDGV.Columns["FIO"].HeaderCell.Value = "ФИО";
            clientDGV.Columns["PhoneNumber"].HeaderCell.Value = "номер телефона";
            clientDGV.Columns["PassportData"].HeaderCell.Value = "паспортные данные";
            objectDGV.Columns["idRentalObject"].Visible = false;
            objectDGV.Columns["Type"].HeaderCell.Value = "тип";
            objectDGV.Columns["Name"].HeaderCell.Value = "название";
            objectDGV.Columns["Status"].HeaderCell.Value = "статус";
            objectDGV.Columns["Price"].HeaderCell.Value = "цена за день использования";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddContractForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateRentStart = dateTimePicker1.Value;
            DateTime dateRentFinish = dateTimePicker2.Value;
            if(idObject > -1 && idClient > -1)
            {
                sqlquery = $"SELECT public.rent_operation({idObject}, " +
                    $"{idClient},  " +
                    $"{User._idUser}, " +
                    $"'{dateRentStart.Year}-{dateRentStart.Month}-{dateRentStart.Day}', " +
                    $"'{dateRentFinish.Year}-{dateRentFinish.Month}-{dateRentFinish.Day}',  " +
                    $"{idRentRegistrationSheet}" +
                    $"); ";
                cmd = new NpgsqlCommand(sqlquery, Program.connection);
                cmd.ExecuteNonQuery();
            } else
                MessageBox.Show("Не выбран объект аренды или клиент");
            


        }

        private void objectDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                idObject = Convert.ToInt32(objectDGV.Rows[e.RowIndex].Cells["idRentalObject"].Value);
                //MessageBox.Show(idObject.ToString());
            }

        }

        private void clientDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idClient = Convert.ToInt32(clientDGV.Rows[e.RowIndex].Cells["idClient"].Value);
                //MessageBox.Show(idClient.ToString());
            }
        }
    }
}
