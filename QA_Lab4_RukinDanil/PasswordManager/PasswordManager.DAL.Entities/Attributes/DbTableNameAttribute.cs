using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities.Attributes
{
    public class DbTableNameAttribute : Attribute
    {
        public string TableName { get; set; }
        public DbTableNameAttribute(string tableName) => TableName = tableName;
    }
}
