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
            "rds-postgresql-otdel-zasel.cguxtch14lq2.eu-west-2.rds.amazonaws.com",
            5432,
            "Nikolai",
            "kkjBB334HE3#4bh",
            "Check_In_Department");

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
