using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Entities
{
    /// <summary>
    /// Представляет шифровщик для шифрования паролей
    /// </summary>
    public interface IEncryptor
    {
        object Encrypt(object data);
        object Decrypt(object data);
    }
}
