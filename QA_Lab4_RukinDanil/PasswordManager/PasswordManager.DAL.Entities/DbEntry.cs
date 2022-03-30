using PasswordManager.DAL.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities
{
    [DbTableName("entry")]
    public class DbEntry : IEntity
    {
        protected int _id = 0;

        [DbAttributeName("id_entry")]
        public int Id { get => _id; set => _id = value; }

        [DbAttributeName("name")]
        public string Name { get; set; } = nameof(Name);

        [DbAttributeName("user_login")]
        public string UserLogin { get; set; } = nameof(UserLogin);

        [DbAttributeName("user_password")]
        public string UserPassword { get; set; } = nameof(UserPassword);

        [DbAttributeName("url")]
        public string Url { get; set; } = "";

        [DbAttributeName("id_group")]
        public int GroupId { get; set; } = 0;

        [DbAttributeName("creation_date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [DbAttributeName("last_access_date")]
        public DateTime LastAccessDate { get; set; } = DateTime.Now;

        [DbAttributeName("last_change_date")]
        public DateTime LastChangeDate { get; set; } = DateTime.Now;
    }
}
