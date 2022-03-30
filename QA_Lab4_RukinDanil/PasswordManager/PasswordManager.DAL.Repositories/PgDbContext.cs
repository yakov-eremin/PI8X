using PasswordManager.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

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
        public DbConnection Connection => _connection ??= new NpgsqlConnection(_connectionString);
    }
}
