using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Core.Entities.Base;

namespace PasswordManager.Core.Entities
{
    /// <summary>
    /// Представляет запись в базе паролей
    /// </summary>
    public interface IEntry : INamedEntity, IDateEntity
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        string UserLogin { get; set; }
        /// <summary>
        /// Пароль пользователя
        /// </summary>
        string UserPassword { get; set; }
        /// <summary>
        /// Адрес ресурса
        /// </summary>
        string Url { get; set; }
        /// <summary>
        /// Группа, к которой принадлежить запись
        /// </summary>
        IGroup ParentGroup { get; set; }
        /// <summary>
        /// Иконка записи
        /// </summary>
        IIcon Icon { get; set; }
    }
}
