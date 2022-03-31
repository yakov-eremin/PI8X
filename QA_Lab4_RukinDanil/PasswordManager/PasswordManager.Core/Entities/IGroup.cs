using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Core.Entities.Base;

namespace PasswordManager.Core.Entities
{
    /// <summary>
    /// Группа записей в базе паролей
    /// </summary>
    public interface IGroup : INamedEntity, IDescribedEntity, IDateEntity
    {
        /// <summary>
        /// Возвращает коллекцию записей в группе
        /// </summary>
        /// <returns>коллекция записей в группе</returns>
        IEnumerable<IEntry> GetEntries();
        /// <summary>
        /// Добавляет запись в группу
        /// </summary>
        /// <param name="entry">добавляемая запись</param>
        /// <returns><see langword="true"/>, если запись успешншо добавлена, иначе <see langword="false"/></returns>
        bool AddEntry(IEntry entry);
        /// <summary>
        /// Удаляет запись из группы
        /// </summary>
        /// <param name="entry">Запись, которую необходимо удалить</param>
        /// <returns><see langword="true"/>, если запись успешншо удалена, иначе <see langword="false"/></returns>
        bool RemoveEntry(IEntry entry);
        /// <summary>
        /// Иконка группы
        /// </summary>
        IIcon Icon { get; set; }
    }
}
