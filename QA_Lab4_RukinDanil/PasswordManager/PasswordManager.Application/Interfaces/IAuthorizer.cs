using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Application.Interfaces
{
    /// <summary>
    /// Сервис авторизации, предоставляет ключ доступа к базе паролей
    /// </summary>
    public interface IAuthorizer
    {
        /// <summary>
        /// Предоставляет ключ доступа к базе паролей. Пользователь должен использовать этот ключ для доступа к базе.
        /// </summary>
        /// <returns></returns>
        Guid GetAccessToken();
    }
}
