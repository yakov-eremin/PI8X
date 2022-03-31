using PasswordManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Services
{
    /// <summary>
    /// Предоставляет функциональность поисковика в базе паролей
    /// </summary>
    public interface ISearchEngine
    {
        /// <summary>
        /// Ищет группу
        /// </summary>
        /// <param name="name">имя группы</param>
        /// <returns></returns>
        IGroup FindGroup(string name);
        /// <summary>
        /// Ищет запись
        /// </summary>
        /// <param name="name">Имя записи</param>
        /// <returns></returns>
        IEntry FindEntry(string name);
        /// <summary>
        /// Ищет базу паролей
        /// </summary>
        /// <param name="name">имя базы</param>
        /// <returns></returns>
        IPasswordDb FindPasswordDb(string name);
    }
}
