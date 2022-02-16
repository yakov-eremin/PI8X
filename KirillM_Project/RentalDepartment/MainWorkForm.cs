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
    
    public partial class MainWorkForm : Form
    {
        enum Tabs
        {
            administratorTab,
            clientTab,
            objectTab,
            contractTab
        }

        private string sqlquery;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private Tabs tabs;
        private int idObject = -1;

        public MainWorkForm()
        {
            InitializeComponent();
        }

        private void SelectTableFromDB()
        {
            cmd = new NpgsqlCommand(sqlquery, Program.connection);
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }
        private void SelectAdministrators_Click(object sender, EventArgs e)
        {
            sqlquery = $"SELECT * FROM \"Administrator\";";
            SelectTableFromDB();
            dataGridView1.Columns["idAdministrator"].Visible = false;
            dataGridView1.Columns["FIO"].HeaderCell.Value = "ФИО админимтратора";

            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = false;
            AdminsGB.Visible = true;
            tabs = Tabs.administratorTab;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SelectClients_Click(object sender, EventArgs e)
        {
            sqlquery = $"SELECT * FROM \"Client\";";
            SelectTableFromDB();
            dataGridView1.Columns["idClient"].Visible = false;
            dataGridView1.Columns["FIO"].HeaderCell.Value = "ФИО";
            dataGridView1.Columns["PhoneNumber"].HeaderCell.Value = "номер телефона";
            dataGridView1.Columns["PassportData"].HeaderCell.Value = "Паспортные данные";

            groupBox1.Visible = false;
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            AdminsGB.Visible = false;
            tabs = Tabs.clientTab;
        }

        private void SelectRentalObjects_Click(object sender, EventArgs e)
        {
            sqlquery = $"SELECT * FROM \"RentalObject\";";
            SelectTableFromDB();
            
            radioButton1.Checked = true;
            dataGridView1.Columns["idRentalObject"].Visible = false;
            dataGridView1.Columns["Type"].HeaderCell.Value = "тип";
            dataGridView1.Columns["Name"].HeaderCell.Value = "название";
            dataGridView1.Columns["Status"].HeaderCell.Value = "статус";
            dataGridView1.Columns["Price"].HeaderCell.Value = "цена за день использования (в руб.)";

            AdminsGB.Visible = false;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox4.Visible = true;
            tabs = Tabs.objectTab;
        }

        private void SelectContracts_Click(object sender, EventArgs e)
        {
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
                
            SelectTableFromDB();
            dataGridView1.Columns["idRentContract"].Visible = false;
            dataGridView1.Columns["DateOfRentStart"].HeaderCell.Value = "дата начала аренды";
            dataGridView1.Columns["DateOfRentFinish"].HeaderCell.Value = "дата окончания аренды";
            dataGridView1.Columns["RentPrice"].HeaderCell.Value = "стоимость";
            AdminsGB.Visible = false;
            groupBox4.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Visible = true;
            tabs = Tabs.contractTab;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddAdministratorForm addAdministratorForm = new AddAdministratorForm();
            addAdministratorForm.ShowDialog();
        }

        private void AddClientBtn_Click(object sender, EventArgs e)
        {
            AddClientForm addClientForm = new AddClientForm();
            addClientForm.ShowDialog();
        }

        private void AddObjectBtn_Click(object sender, EventArgs e)
        {
            AddObjectForm addObjectForm = new AddObjectForm();
            addObjectForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddContractForm addContractForm = new AddContractForm();
            addContractForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RentContinueForm rentContinueForm = new RentContinueForm();
            rentContinueForm.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sqlquery = $"SELECT * FROM \"RentalObject\";";
            SelectTableFromDB();
            dataGridView1.Columns["idRentalObject"].Visible = false;
            dataGridView1.Columns["Type"].HeaderCell.Value = "тип";
            dataGridView1.Columns["Name"].HeaderCell.Value = "название";
            dataGridView1.Columns["Status"].HeaderCell.Value = "статус";
            dataGridView1.Columns["Price"].HeaderCell.Value = "цена за день использования (в руб.)";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sqlquery = $"select * from actual_rent_objects;";
            SelectTableFromDB();
            dataGridView1.Columns["idRentalObject"].Visible = false;
            dataGridView1.Columns["Type"].HeaderCell.Value = "тип";
            dataGridView1.Columns["Name"].HeaderCell.Value = "название";
            dataGridView1.Columns["Status"].HeaderCell.Value = "статус";
            dataGridView1.Columns["Price"].HeaderCell.Value = "цена за день использования (в руб.)";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            sqlquery = $"select * from \"RentalObject\" where \"Status\" = 'в пользовании';";
            SelectTableFromDB();
            dataGridView1.Columns["idRentalObject"].Visible = false;
            dataGridView1.Columns["Type"].HeaderCell.Value = "тип";
            dataGridView1.Columns["Name"].HeaderCell.Value = "название";
            dataGridView1.Columns["Status"].HeaderCell.Value = "статус";
            dataGridView1.Columns["Price"].HeaderCell.Value = "цена за день использования (в руб.)";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            sqlquery = $"select * from \"RentalObject\" where \"Status\" = 'в ремонте';";
            SelectTableFromDB();
            dataGridView1.Columns["idRentalObject"].Visible = false;
            dataGridView1.Columns["Type"].HeaderCell.Value = "тип";
            dataGridView1.Columns["Name"].HeaderCell.Value = "название";
            dataGridView1.Columns["Status"].HeaderCell.Value = "статус";
            dataGridView1.Columns["Price"].HeaderCell.Value = "цена за день использования (в руб.)";
        }

        private void button4_Click(object sender, EventArgs e) // отдать в ремонт
        {
            sqlquery = $"SELECT public.give_object_for_repair({idObject})";
            using (cmd = new NpgsqlCommand(sqlquery, Program.connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            sqlquery = $"SELECT public.set_object_active({idObject})";
            using (cmd = new NpgsqlCommand(sqlquery, Program.connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tabs == Tabs.objectTab)
            {
                idObject = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idRentalObject"].Value);
            }
            else if (tabs != Tabs.objectTab)
                idObject = -1;

        }
    }
}
