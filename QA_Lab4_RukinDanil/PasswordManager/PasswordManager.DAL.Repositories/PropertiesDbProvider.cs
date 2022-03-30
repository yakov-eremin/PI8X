using PasswordManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PasswordManager.DAL.Repositories
{
    /// <summary>
    /// Генератор простейших sql-команд
    /// </summary>
    public class PropertiesDbProvider
    {
        public string GetPropertiesWithoutProperty(IEntity entry, string propertyName)
        {
            Type type = entry.GetType();
            var typeAttributes = type.GetCustomAttributes();

            foreach (var attribute in typeAttributes)
            {

            }

            return null;
        }
    }
}
