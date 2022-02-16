using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalDepartment
{
    internal static class Program
    {
        private static string _dbServerAddress = ""; // Адрес к базе данных
        private static string _dbPort = ""; // порт для подключения к базе данных
        private static string _dbUserId = ""; // имя пользователя, работающего с базой данных
        private static string _dbPassword = ""; // пароль для доступа к базе данных на сервере
        private static string _dbName = ""; // название база данных на сервере

        private static string connectionString = String.Format(
            "Server={0};Port={1};User Id={2};Password={3};Database={4};",
            _dbServerAddress, _dbPort, _dbUserId, _dbPassword, _dbName);

        public static NpgsqlConnection connection;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthorizationForm());
        }


    }
}
