using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Предоставляет подключение к базе данных
        /// </summary>
        DbConnection Connection { get; }
    }
}
