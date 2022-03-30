using PasswordManager.DAL.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Entities
{
    /// <summary>
    /// Представляет алгоритм шифрования, который применяется для шифрования паролей
    /// </summary>
    /// <inheritdoc/>
    [DbTableName("encryption_algorithm")]
    public class EncryptionAlgorithm : IEntity
    {
        protected int _id = 0;

        [DbAttributeName("id_encryption_algorithm")]
        public int Id { get => _id; set => _id = value; }
        /// <summary>
        /// Кодовое название алгоритма
        /// </summary>
        [DbAttributeName("code_name")]
        public string CodeName { get; set; } = nameof(CodeName);
        /// <summary>
        /// Описание алгоритма
        /// </summary>
        [DbAttributeName("description")]
        public string Description { get; set; } = nameof(Description);
        /// <summary>
        /// Полное имя алгоритма
        /// </summary>
        [DbAttributeName("name")]
        public string Name { get; set; } = nameof(Name);
    }
}
