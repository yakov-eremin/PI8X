using PasswordManager.DAL.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities
{
    /// <summary>
    /// Представляет запись с паролем пользователя в базе данных
    /// </summary>
    /// <inheritdoc/>
    [DbTableName("entry")]
    public class DbEntry : IEntity
    {
        protected int _id = 0;

        [DbAttributeName("id_entry")]
        public int Id { get => _id; set => _id = value; }
        /// <summary>
        /// Имя записи
        /// </summary>
        [DbAttributeName("name")]
        public string Name { get; set; } = nameof(Name);
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [DbAttributeName("user_login")]
        public string UserLogin { get; set; } = nameof(UserLogin);
        /// <summary>
        /// Пароль пользователя в зашифрованном виде
        /// </summary>
        [DbAttributeName("user_password")]
        public string UserPassword { get; set; } = nameof(UserPassword);
        /// <summary>
        /// Адрес ресурса или локального приложения
        /// </summary>
        [DbAttributeName("url")]
        public string Url { get; set; } = "";
        /// <summary>
        /// Идентификатор группы, к которой принадлежит данная запись
        /// </summary>
        [DbAttributeName("id_group")]
        public int GroupId { get; set; } = 0;
        /// <summary>
        /// Дата создания записи
        /// </summary>
        [DbAttributeName("creation_date")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Дата последнего доступа к записи
        /// </summary>
        [DbAttributeName("last_access_date")]
        public DateTime LastAccessDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Дата последнего изменения записи
        /// </summary>
        [DbAttributeName("last_change_date")]
        public DateTime LastChangeDate { get; set; } = DateTime.Now;
    }
}
