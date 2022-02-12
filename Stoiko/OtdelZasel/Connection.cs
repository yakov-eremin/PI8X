using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace OtdelZasel
{
    class Connection
    {
        private static Connection Instance;

        private string connectstr = String.Format(
            "Server={0};" +
            "Port={1};" +
            "User Id={2};" +
            "Password={3};" +
            "Database={4};",
            "192.168.100.228",
            5432,
            "postgres",
            "123",
            "boop");

        public NpgsqlConnection connection;

        public Connection()
        {
            connection = new NpgsqlConnection(connectstr);
        }
        public static Connection getInstance()
        {
            if (Instance == null)
                Instance = new Connection();
            return Instance;
        }

    }
}
