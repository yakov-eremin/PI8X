using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities
{
    /// <summary>
    /// Сущность базы данных, имеющая <see cref="Id"/>
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Идентификатор сущности в таблице базы данных
        /// </summary>
        int Id { get; set; }
    }
}
