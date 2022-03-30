using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities.Attributes
{
    public class DbAttributeNameAttribute : Attribute
    {
        public string AttributeName { get; set; }

        public DbAttributeNameAttribute(string attributeName) => AttributeName = attributeName;
    }
}
