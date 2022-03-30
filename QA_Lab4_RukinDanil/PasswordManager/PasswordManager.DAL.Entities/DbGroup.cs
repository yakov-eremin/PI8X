using PasswordManager.DAL.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities
{
    /// <summary>
    /// Представляет группу записей в базе паролей
    /// </summary>
    /// <inheritdoc/>
    [DbTableName("entry_group")]
    public class DbGroup : IEntity
    {
        protected int _id = 0;
        [DbAttributeName("id_group")]
        public int Id { get => _id; set => _id = value; }
        /// <summary>
        /// Описание группы
        /// </summary>
        [DbAttributeName("description")]
        public string Description { get; set; } = nameof(Description);
        /// <summary>
        /// Имя группы
        /// </summary>
        [DbAttributeName("name")]
        public string Name { get; set; } = nameof(Name);
        /// <summary>
        /// Путь к иконке группы
        /// </summary>
        [DbAttributeName("path_to_icon")]
        public string PathToIcon { get; set; } = "";
        /// <summary>
        /// Идентификатор базы паролей, к которой относится группа
        /// </summary>
        [DbAttributeName("id_password_db")]
        public int PasswordDbId { get; set; } = 0;
        /// <summary>
        /// Дата создания группы
        /// </summary>
        [DbAttributeName("creation_date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Дата последнего доступа к группе
        /// </summary>
        [DbAttributeName("last_access_date")]
        public DateTime LastAccessDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Дата последнего изменения группы
        /// </summary>
        [DbAttributeName("last_change_date")]
        public DateTime LastChangeDate { get; set; } = DateTime.Now;
    }
}
