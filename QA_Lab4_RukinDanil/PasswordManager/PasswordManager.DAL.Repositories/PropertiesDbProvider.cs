using PasswordManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PasswordManager.DAL.Entities.Attributes;

namespace PasswordManager.DAL.Repositories
{
    /// <summary>
    /// Генератор простейших sql-команд
    /// </summary>
    public class PropertiesDbProvider
    {
        public string GetPropertiesWithoutProperty(IEntity entity, string propertyName)
        {
            if (CheckDbTableNameAttribute(entity))
            {

            }
            else
                throw new ArgumentException($"{nameof(entity)} does not contains {nameof(DbTableNameAttribute)}.");

            return null;
        }

        public bool CheckDbTableNameAttribute(IEntity entity)
        {
            Type type = entity.GetType();
            var typeAttributes = type.GetCustomAttributes();
            bool contains = false;
            foreach (var attribute in typeAttributes)
            {
                if (attribute is DbTableNameAttribute)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }
    }
}
