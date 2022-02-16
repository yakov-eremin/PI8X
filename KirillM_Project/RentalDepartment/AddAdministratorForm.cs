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
    public partial class AddAdministratorForm : Form
    {
        private string sqlquery;
        private NpgsqlCommand cmd;

        public AddAdministratorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newAdministratorFIO = Convert.ToString(textBox1.Text);
            sqlquery = $"SELECT create_administrator('{newAdministratorFIO}');";
            cmd = new NpgsqlCommand(sqlquery, Program.connection);
            cmd.ExecuteNonQuery();
        }
    }
}
