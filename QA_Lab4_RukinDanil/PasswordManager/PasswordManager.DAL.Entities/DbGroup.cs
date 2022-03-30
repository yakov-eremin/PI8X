﻿using PasswordManager.DAL.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities
{
    [DbTableName("entry_group")]
    public class DbGroup : IEntity
    {
        protected int _id = 0;
        [DbAttributeName("id_group")]
        public int Id { get => _id; set => _id = value; }

        [DbAttributeName("description")]
        public string Description { get; set; } = nameof(Description);

        [DbAttributeName("name")]
        public string Name { get; set; } = nameof(Name);

        [DbAttributeName("path_to_icon")]
        public string PathToIcon { get; set; } = "";

        [DbAttributeName("id_password_db")]
        public int PasswordDbId { get; set; } = 0;

        [DbAttributeName("creation_date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [DbAttributeName("last_access_date")]
        public DateTime LastAccessDate { get; set; } = DateTime.Now;

        [DbAttributeName("last_change_date")]
        public DateTime LastChangeDate { get; set; } = DateTime.Now;
    }
}
