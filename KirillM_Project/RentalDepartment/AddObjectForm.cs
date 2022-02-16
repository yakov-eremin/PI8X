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
    public partial class AddObjectForm : Form
    {
        private string sqlquery;
        private NpgsqlCommand cmd;
        public AddObjectForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newObjectName = Convert.ToString(textBox1.Text);
            string newObjectType = Convert.ToString(textBox2.Text);
            string newObjectPrice = Convert.ToString(textBox3.Text);
            sqlquery = $"SELECT create_rental_object('{newObjectType}', '{newObjectName}', {newObjectPrice});";
            cmd = new NpgsqlCommand(sqlquery, Program.connection);
            cmd.ExecuteNonQuery();
        }
    }
}
