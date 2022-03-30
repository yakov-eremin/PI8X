using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities.Attributes
{
    /// <summary>
    /// Атрибут предназначен для того, чтобы отобразить имя помеченного им свойства в имя атрибута таблицы в базе данных
    /// </summary>
    public class DbAttributeNameAttribute : Attribute
    {
        /// <summary>
        /// Имя атрибута в базе данных
        /// </summary>
        public string AttributeName { get; set; }
        /// <summary>
        /// Создает <see cref="DbAttributeNameAttribute"/> с именем атрибута в базе данных
        /// </summary>
        /// <param name="attributeName">имя атрибута в таблице базы данных</param>
        public DbAttributeNameAttribute(string attributeName) => AttributeName = attributeName;
    }
}
