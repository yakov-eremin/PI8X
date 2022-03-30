using PasswordManager.DAL.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities
{
    [DbTableName("db_access_way")]
    public class DbAccessWay : IEntity
    {
        protected int _id = 0;
        [DbAttributeName("id_db_access_way")]
        public int Id { get => _id; set => _id = value; }

        [DbAttributeName("name")]
        public string Name { get; set; } = nameof(Name);
    }
}
