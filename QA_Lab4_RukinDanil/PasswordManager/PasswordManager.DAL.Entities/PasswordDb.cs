using PasswordManager.DAL.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities
{
    /// <summary>
    /// Представляет базу паролей пользователя
    /// </summary>
    /// <inheritdoc/>
    [DbTableName("password_db")]
    public class PasswordDb : IEntity
    {
        protected int _id = 0;

        [DbAttributeName("id_password_db")]
        public int Id { get => _id; set => _id = value; }
        /// <summary>
        /// Описание базы
        /// </summary>
        [DbAttributeName("description")]
        public string Description { get; set; } = nameof(Description);
        /// <summary>
        /// Название базы
        /// </summary>
        [DbAttributeName("name")]
        public string Name { get; set; } = nameof(Name);
        /// <summary>
        /// Путь к иконке базы
        /// </summary>
        [DbAttributeName("path_to_icon")]
        public string PathToIcon { get; set; } = "";
        /// <summary>
        /// Мастер-пароль от базы в зашифрованном виде
        /// </summary>
        [DbAttributeName("master_password")]
        public string MasterPassword { get; set; } = "";
        /// <summary>
        /// Дата создания базы
        /// </summary>
        [DbAttributeName("creation_date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Дата последнего доступа к базе
        /// </summary>
        [DbAttributeName("last_access_date")]
        public DateTime LastAccessDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Дата последнего изменения базы
        /// </summary>
        [DbAttributeName("last_change_date")]
        public DateTime LastChangeDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Идентификатор способа доступа к базе
        /// </summary>
        [DbAttributeName("id_db_access_way")]
        public int DbAccessWayId { get; set; } = 0;
        /// <summary>
        /// Идентификатор алгоритма шифрования, который применяется для шифрования паролей
        /// </summary>
        [DbAttributeName("id_encryption_algorithm")]
        public int EncriptionAlgorithmId { get; set; } = 0;
    }
}
