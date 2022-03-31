using PasswordManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Строитель sql-команд
    /// </summary>
    public interface IDbCommandBuilder
    {
        /// <summary>
        /// Команда вставки
        /// </summary>
        /// <param name="shouldReset">флаг сброса цепочки</param>
        /// <returns></returns>
        IDbCommandBuilder Insert(bool shouldReset = false);
        /// <summary>
        /// Указывает, в какую таблицу вставить значения
        /// </summary>
        /// <param name="tableName">имя таблицы</param>
        /// <param name="parameters">атрибуты таблицы</param>
        /// <param name="shouldReset">флаг сброса цепочки</param>
        /// <returns></returns>
        IDbCommandBuilder Into(string tableName, IEnumerable<string> parameters, bool shouldReset = false);
        /// <summary>
        /// Указывает значения, которые необходимо вставить в таблицу
        /// </summary>
        /// <param name="values">значения</param>
        /// <param name="shouldReset">флаг сброса цепочки</param>
        /// <returns></returns>
        IDbCommandBuilder Values(IEnumerable<object> values, bool shouldReset = false);
        /// <summary>
        /// Указывает условие
        /// </summary>
        /// <param name="condition">Условие</param>
        /// <param name="shouldReset">флаг сброса цепочки</param>
        /// <returns></returns>
        IDbCommandBuilder Where(string condition, bool shouldReset = false);
        /// <summary>
        /// Обновляет данные в таблице
        /// </summary>
        /// <param name="tableName">имя таблицы</param>
        /// <param name="shouldReset">флаг сброса цепочки</param>
        /// <returns></returns>
        IDbCommandBuilder Update(string tableName, bool shouldReset = false);
        /// <summary>
        /// Устанавливает пары атрибут-значение при обновлении таблицы
        /// </summary>
        /// <param name="propertiesAndValues">пары атрибут-значение</param>
        /// <param name="shouldReset"></param>
        /// <returns></returns>
        IDbCommandBuilder Set(IDictionary<string, object> propertiesAndValues, bool shouldReset = false);
        /// <summary>
        /// Удаляет данные из таблицы
        /// </summary>
        /// <param name="shouldReset"></param>
        /// <returns></returns>
        IDbCommandBuilder Delete(bool shouldReset = false);
        /// <summary>
        /// Из какой таблицы производить выборку или удалять данные
        /// </summary>
        /// <param name="tableName">имя таблицы</param>
        /// <param name="shouldReset">флаг сброса цепочки</param>
        /// <returns></returns>
        IDbCommandBuilder From(string tableName, bool shouldReset = false);
        /// <summary>
        /// Команда выборки
        /// </summary>
        /// <param name="parameters">что выбирать</param>
        /// <param name="shouldReset">флаг сброса цепочки</param>
        /// <returns></returns>
        IDbCommandBuilder Select(IEnumerable<string> parameters, bool shouldReset = false);
        /// <summary>
        /// Сбрасывает <see cref="IDbCommandBuilder"/>
        /// </summary>
        void ResetBuilder();
        /// <summary>
        /// Получает sql-команду в виде строки.
        /// </summary>
        /// <returns></returns>
        string GetCommand();
    }
}
