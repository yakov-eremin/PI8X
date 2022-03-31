using PasswordManager.DAL.Entities;

namespace PasswordManager.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Определяет объект простейшего генератора sql, для CRUD операций
    /// </summary>
    public interface ICrudCommandsGenerator
    {
        /// <summary>
        /// Генерирует команду для создания сущности
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        string CreateEntity(IEntity entity);
        /// <summary>
        /// Генерирует команду для удаления сущности по ее <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        string DeleteEntity(int id, IEntity entity);
        /// <summary>
        /// Генерирует команду для полчения всех сущностей из таблицы
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        string GetAllEntities(IEntity entity);
        /// <summary>
        /// Генерирует команду для получения сущности из таблицы по ее <paramref name="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="emptyEntity"></param>
        /// <returns></returns>
        string GetEntity(int id, IEntity emptyEntity);
        /// <summary>
        /// Генерирует команду для обновления сущности
        /// /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        string UpdateEntity(IEntity entity);
    }
}