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
    public partial class AuthorizationForm : Form
    {
        private string sqlquery;
        private NpgsqlCommand cmd;
        private DataTable dt;

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userLogin = Convert.ToString(textBox1.Text);
            string userPassword = Convert.ToString(textBox2.Text);
            sqlquery = "SELECT * FROM (SELECT \"idUser\", login, password, \"User\".\"idAdministrator\", \"Administrator\".\"FIO\"" +
                " FROM public.\"User\" " +
                " inner join \"Administrator\" on \"User\".\"idAdministrator\" = \"Administrator\".\"idAdministrator\") as users" +
                $" where users.login = '{userLogin}' and users.password = '{userPassword}';";

            cmd = new NpgsqlCommand(sqlquery, Program.connection);
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                User.SetUser(Convert.ToInt32(dt.Rows[0]["idAdministrator"]), dt.Rows[0]["FIO"].ToString());
                MessageBox.Show($"Здравствуйте, {User._userName}");
                MainWorkForm mainForm = new MainWorkForm();
                mainForm.ShowDialog();
                //this.Visible = false;
            }
            else
                MessageBox.Show("Неверно введён логин или пароль\nПопробуйте авторизироваться снова");


        }
    }
}
