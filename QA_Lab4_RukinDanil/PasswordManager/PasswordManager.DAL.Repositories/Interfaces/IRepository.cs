using PasswordManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Репозиторий сущностей. Выступает аналогом таблицы БД.
    /// </summary>
    /// <typeparam name="T">Тип сущности <see cref="IEntity"/>, с которым работает репозиторий</typeparam>
    public interface IRepository<T> where T : IEntity, new()
    {
        /// <summary>
        /// Получает все сущности, содержащиеся в базе
        /// </summary>
        /// <returns>Перечисление <see cref="IEnumerable{T}"/> сущностей таблицы. Если таблица пуста, то перечисление будет пустым</returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Асинхронная версия метода <see cref="GetAll"/>
        /// </summary>
        /// <param name="cancellationToken">Токен завершения задачи</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Получает сущность <see cref="IEntity"/> из базы данных по ее <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns>Сущность тип <typeparamref name="T"/></returns>
        T Get(int id);

        /// <summary>
        /// Асинхронная версия метода <see cref="Get(int)"/>
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <param name="cancellationToken">Токен завершения задачи</param>
        /// <returns></returns>
        Task<T> GetAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Целиком обновляет сущность <paramref name="entity"/>. Обновляются все параметры.
        /// </summary>
        /// <param name="entity">Сущность, которую необходимо обновить</param>
        /// <returns>Число обновленных строк базы. Если операция успешна, то вернет 1, иначе 0</returns>
        int Update(T entity);

        /// <summary>
        /// Асинхронная версия метода <see cref="Update(T)"/>
        /// </summary>
        /// <param name="entity">Сущность, которую следует обновить</param>
        /// <param name="cancellationToken">Токен завершения задачи</param>
        /// <returns>Число заторонуты строк базы</returns>
        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Удаляет указанную сущность из базы.
        /// </summary>
        /// <param name="entity">Сущность, которую следует удалить.</param>
        /// <returns>Число затронутых строк в базе данных</returns>
        int Delete(T entity);

        /// <summary>
        /// Асинхронная версия метода <see cref="Delete(T)"/>
        /// </summary>
        /// <param name="entity">Сущность, которую следует удалить</param>
        /// <param name="cancellationToken">Токен завершения задачи</param>
        /// <returns>Число затронутых строк базы</returns>
        Task<int> DeleteAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создает сущность типа <typeparamref name="T"/>. id сущности не учитывается, т.е. всегда создается новая
        /// </summary>
        /// <param name="entity">Сущность, которую необходимо создать в базе.</param>
        void Create(T entity);
        /// <summary>
        /// Асинхронная версия метода <see cref="Create(T)"/>
        /// </summary>
        /// <param name="entity">Сущность, которую следует создать</param>
        /// <param name="cancellationToken">Токен завершения задачи</param>
        /// <returns>Задача, которую можно ожидать</returns>
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    }
}
