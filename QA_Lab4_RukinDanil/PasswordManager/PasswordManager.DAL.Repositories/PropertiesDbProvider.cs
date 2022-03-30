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
        public IEnumerable<string> GetProperties(IEntity entity)
        {
            List<string> result = new List<string>();
            if (CheckDbTableNameAttribute(entity))
            {
                Type type = entity.GetType();
                var properties = type.GetProperties();
                object[] attributes;
                foreach (var item in properties)
                {
                    attributes = item.GetCustomAttributes(false);
                    foreach (Attribute attribute in attributes)
                    {
                        if (attribute is DbAttributeNameAttribute nameAttribute)
                        {
                            result.Add(nameAttribute.AttributeName);
                        }
                    }
                }
            }
            else
                throw new ArgumentException($"{nameof(entity)} does not contains {nameof(DbTableNameAttribute)}.");
            return result;
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
