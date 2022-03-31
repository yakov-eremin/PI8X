using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Entities
{
    /// <summary>
    /// Представляет иконку
    /// </summary>
    public interface IIcon
    {
        /// <summary>
        /// Путь до иконки
        /// </summary>
        string Path { get; set; }
        /// <summary>
        /// Картинка
        /// </summary>
        object Icon { get; set; }
    }
}
