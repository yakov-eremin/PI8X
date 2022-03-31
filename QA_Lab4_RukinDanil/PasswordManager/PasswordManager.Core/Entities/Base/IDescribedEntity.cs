using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Entities.Base
{
    /// <summary>
    /// Описываемая сущность
    /// </summary>
    public interface IDescribedEntity
    {
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
    }
}
