using Npgsql;
using System;
using System.Windows.Forms;

namespace OtdelZasel
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (Surname.Text.Length < 2)
                    throw new Exception("Фамилия слишком короткая");
                if (NameTextBox.Text.Length < 2)
                    throw new Exception("Имя слишком короткое");
                if (login.Text.Length < 2)
                    throw new Exception("Логин должен содержать не менее 2 символов");
                if (password.Text.Length < 1)
                    throw new Exception("Пароль не может быть пустым");

                Connection.getInstance().connection.Open();
                var sql = @"select * from createcitizen(:surname, :firstname, :lastname, :login, :password)";
                var cmd = new NpgsqlCommand(sql, Connection.getInstance().connection);
                cmd.Parameters.AddWithValue("surname", Surname.Text);
                cmd.Parameters.AddWithValue("firstname", NameTextBox.Text);
                cmd.Parameters.AddWithValue("lastname", FatherName.Text);
                cmd.Parameters.AddWithValue("login", login.Text);
                cmd.Parameters.AddWithValue("password", password.Text);
                var answer = cmd.ExecuteScalar();
                long idCitizen = (long)answer;
                Connection.getInstance().connection.Close();
                Form citizenWindow = new CitizenWindow(idCitizen);
                this.Hide();
                citizenWindow.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                Connection.getInstance().connection.Close();
                MessageBox.Show("Не удалось зарегистрироваться. Ошибка: " + ex.Message);
            }
        }

    }
}