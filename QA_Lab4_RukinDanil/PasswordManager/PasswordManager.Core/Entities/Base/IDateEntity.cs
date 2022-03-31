using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Entities.Base
{
    /// <summary>
    /// Сущность, к которой осуществляется доступ
    /// </summary>
    public interface IDateEntity
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime CreationDate { get; set; }
        /// <summary>
        /// Дата последнего доступа
        /// </summary>
        DateTime LastAccessDate { get; set; }
        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        DateTime LastChangeDate { get; set; }
    }
}
