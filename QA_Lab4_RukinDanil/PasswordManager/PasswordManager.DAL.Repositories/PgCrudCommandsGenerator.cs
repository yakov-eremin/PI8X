using PasswordManager.DAL.Entities;
using PasswordManager.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Repositories
{
    public class PgCrudCommandsGenerator
    {
        public string CreateEntity(IEntity entity)
        {
            IDbCommandBuilder builder = new PgDbCommandBuilder();
            DbAttributesPropertiesProvider provider = new DbAttributesPropertiesProvider();
            IDictionary<string, object> keyValuePairs = provider.GetPropertiesValues(entity);
            List<object> values = new List<object>();
            foreach (var keyValue in keyValuePairs)
            {
                values.Add(keyValue.Value);
            }
            string result;
            result = builder.Insert().Into("entry", provider.GetProperties(entity)).Values(values).GetCommand();
            return result;
        }
    }
}
