using PasswordManager.DAL.Entities;
using PasswordManager.DAL.Entities.Attributes;
using PasswordManager.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Repositories
{
    /// <summary>
    /// Реализация <see cref="IRepository{T}"/> по умолчанию. Для вытягивания данных используется рефлексия.
    /// В базу данных попадут только свойства, помеченные атрибутом <see cref="DbAttributeNameAttribute"/>.
    /// Сами сущности <see cref="IEntity"/> должны быть помечены атрибутом <see cref="DbTableNameAttribute"/>.
    /// </summary>
    /// <typeparam name="T">Сущность базы данных</typeparam>
    /// <remarks>
    /// Данный репозиторий может применяться для всех сущностей <see cref="IEntity"/>, однако, можно определить и собственную реализацию.
    /// Преимущество данной реализации в том, что можно наштамповать классов-наследников <see cref="IEntity"/> со свойствами,
    /// помеченными необходимыми атрибутами и все.
    /// </remarks>
    /// <inheritdoc/>
    public class DefaultRepository<T> : IRepository<T> where T : IEntity, new()
    {
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
