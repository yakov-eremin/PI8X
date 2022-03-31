using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Entities.Base
{
    /// <summary>
    /// Именованная сущность
    /// </summary>
    public interface INamedEntity
    {
        /// <summary>
        /// Имя сущности
        /// </summary>
        string Name { get; set; }
    }
}
