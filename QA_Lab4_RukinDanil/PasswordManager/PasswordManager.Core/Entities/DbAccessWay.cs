using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Entities
{
    /// <summary>
    /// Способ доступа к базе паролей
    /// </summary>
    public enum DbAccessWay
    {
        /// <summary>
        /// Игра
        /// </summary>
        Game,
        /// <summary>
        /// Мастер-пароль
        /// </summary>
        MastrePassword
    }
}
