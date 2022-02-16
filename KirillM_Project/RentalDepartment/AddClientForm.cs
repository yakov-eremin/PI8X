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
    public partial class AddClientForm : Form
    {
        private string sqlquery;
        private NpgsqlCommand cmd;
        public AddClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newClientFIO = Convert.ToString(textBox1.Text);
            string newClientNumber = Convert.ToString(textBox2.Text);
            string newClientPasport = Convert.ToString(textBox3.Text);
            sqlquery = $"SELECT create_client('{newClientFIO}', {newClientNumber}, {newClientPasport});";
            cmd = new NpgsqlCommand(sqlquery, Program.connection);
            cmd.ExecuteNonQuery();
        }
    }
}
