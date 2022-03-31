using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Core.Entities.Base;

namespace PasswordManager.Core.Entities
{
    /// <summary>
    /// Предаставляет базу паролей
    /// </summary>
    public interface IPasswordDb : INamedEntity, IDescribedEntity, IDateEntity
    {
        /// <summary>
        /// Возвращает коллекцию групп записей в базе
        /// </summary>
        /// <returns>коллекция групп записей в базе</returns>
        IEnumerable<IGroup> GetGroups();
        /// <summary>
        /// Возвращает коллекцию записей в базе, у которых нет групп
        /// </summary>
        /// <returns>коллекция записей в базе, у которых нет групп</returns>
        IEnumerable<IEntry> GetEntriesWithoutGroups();
        /// <summary>
        /// Добавляет группу
        /// </summary>
        /// <param name="group">группа для добавления</param>
        /// <returns><see langword="true"/>, если группа успешншо добавлена, иначе <see langword="false"/></returns>
        bool AddGroup(IGroup group);
        /// <summary>
        /// Удаляет группу
        /// </summary>
        /// <param name="group">группа для удаления</param>
        /// <param name="deleteGroupEntries">указывает на необходимость удаления записей группы</param>
        /// <remarks>
        /// Если <paramref name="deleteGroupEntries"/> = <see langword="true"/>, то записи в удаляемой группе будут также удалены,
        /// иначе все записи будут вынесены из группы в базу паролей.
        /// </remarks>
        /// <returns><see langword="true"/>, если группа успешншо удалена, иначе <see langword="false"/></returns>
        bool RemoveGroup(IGroup group, bool deleteGroupEntries = true);
        /// <summary>
        /// Добавляе запись
        /// </summary>
        /// <param name="entry">запись для добавления</param>
        /// <returns><see langword="true"/>, если запись успешншо добавлена, иначе <see langword="false"/></returns>
        bool AddEntry(IEntry entry);
        /// <summary>
        /// Удаляет запись
        /// </summary>
        /// <param name="entry">запись для удаления</param>
        /// <returns><see langword = "true" />, если запись успешншо удалена, иначе<see langword="false"/></returns>
        bool RemoveEntry(IEntry entry);
        /// <summary>
        /// Способ доступа к базе
        /// </summary>
        DbAccessWay DbAccessWay { get; set; }
        /// <summary>
        /// Шифровщик для шифрования паролей
        /// </summary>
        IEncryptor Encryptor { get; set; }
        /// <summary>
        /// Иконка базы паролей
        /// </summary>
        IIcon Icon { get; set; }
    }
}
