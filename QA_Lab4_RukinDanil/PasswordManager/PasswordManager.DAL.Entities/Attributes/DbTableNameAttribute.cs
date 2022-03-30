using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities.Attributes
{
    /// <summary>
    /// Класс помеченный данным атрибутом отображается в таблицу базы данных с именем <see cref="TableName"/>
    /// </summary>
    public class DbTableNameAttribute : Attribute
    {
        /// <summary>
        /// Имя таблицы в базе данных, в которую следует отобразить сущность
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Создает атрибут <see cref="DbTableNameAttribute"/>, который отображает помеченную сущность в таблицу базы данных 
        /// с именем <paramref name="tableName"/>
        /// </summary>
        /// <param name="tableName">Имя таблицы в базе данных</param>
        public DbTableNameAttribute(string tableName) => TableName = tableName;
    }
}
