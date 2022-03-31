using PasswordManager.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace PasswordManager.DAL.Repositories
{
    /// <summary>
    /// Контекст базы данных Postgres
    /// </summary>
    /// <inheritdoc/>
    public class PgDbContext : IDbContext
    {
        protected string _connectionString;
        /// <summary>
        /// Создает контекст базы данных <see cref="PgDbContext"/> для СУБД Postgres
        /// </summary>
        /// <param name="connectionString"></param>
        public PgDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected NpgsqlConnection _connection;
        public IDbConnection Connection => _connection ??= new NpgsqlConnection(_connectionString);

        public IDbCommandBuilder CommandGenerator => throw new NotImplementedException();
    }
}
