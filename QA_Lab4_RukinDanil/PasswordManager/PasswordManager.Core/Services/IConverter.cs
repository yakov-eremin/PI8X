using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Services
{
    /// <summary>
    /// Конвертирует сущности ядра в сущности базы данных и наоборот
    /// </summary>
    /// <typeparam name="TCoreEntity">сущность ядра</typeparam>
    /// <typeparam name="TDatabaseEntity">сущность базы данных</typeparam>
    public interface IConverter<TCoreEntity, TDatabaseEntity>
    {
        /// <summary>
        /// Конвертирует сущность базы данных в сущнось ядра
        /// </summary>
        /// <param name="databaseEntity">сущность базы данных</param>
        /// <returns></returns>
        TCoreEntity Convert(TDatabaseEntity databaseEntity);
        /// <summary>
        /// Конвертирует сущность ядра в сущность базы данных
        /// </summary>
        /// <param name="coreEntity">сущность ядра</param>
        /// <returns></returns>
        TDatabaseEntity ConvertBack(TCoreEntity coreEntity);
    }
}
