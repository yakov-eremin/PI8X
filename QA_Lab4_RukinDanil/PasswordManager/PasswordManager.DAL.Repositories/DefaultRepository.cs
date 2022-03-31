using PasswordManager.DAL.Entities;
using PasswordManager.DAL.Entities.Attributes;
using PasswordManager.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        protected IDbContext _dbContext;

        public void Create(T entity)
        {
            DbConnection dbConnection = (DbConnection)_dbContext.Connection;
            DbCommand command = dbConnection.CreateCommand();
            command.CommandText = _dbContext.CommandGenerator.CreateEntity(entity);
            dbConnection.Open();
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            DbConnection dbConnection = (DbConnection)_dbContext.Connection;
            DbCommand command = dbConnection.CreateCommand();
            command.CommandText = _dbContext.CommandGenerator.CreateEntity(entity);
            await dbConnection.OpenAsync(cancellationToken);
            await command.ExecuteNonQueryAsync(cancellationToken);
            await dbConnection.CloseAsync();
        }

        public int Delete(T entity)
        {
            IDbConnection dbConnection = _dbContext.Connection;
            IDbCommand command = dbConnection.CreateCommand();
            command.CommandText = _dbContext.CommandGenerator.DeleteEntity(entity.Id, entity);
            dbConnection.Open();
            int result = command.ExecuteNonQuery();
            dbConnection.Close();
            return result;
        }

        public async Task<int> DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            DbConnection dbConnection = (DbConnection)_dbContext.Connection;
            DbCommand command = dbConnection.CreateCommand();
            command.CommandText = _dbContext.CommandGenerator.DeleteEntity(entity.Id, entity);
            await dbConnection.OpenAsync(cancellationToken);
            int result = await command.ExecuteNonQueryAsync(cancellationToken);
            await dbConnection.CloseAsync();
            return result;
        }

        public T Get(int id)
        {
            T entity = new T();
            entity.Id = id;
            DbConnection connection = (DbConnection)_dbContext.Connection;
            DbCommand command = connection.CreateCommand();
            command.CommandText = _dbContext.CommandGenerator.GetEntity(id, entity);
            connection.Open();
            DbDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
                return default(T);
            reader.Read();
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            IEnumerable<string> properties = _dbContext.Provider.GetProperties(entity);
            foreach (string property in properties)
            {
                keyValues.Add(property, reader.GetValue(property));
            }           
            _dbContext.Provider.SetPropertiesValues(entity, keyValues);
            reader.Close();
            connection.Close();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            T entity = new T();
            DbConnection connection = (DbConnection)_dbContext.Connection;
            DbCommand command = connection.CreateCommand();
            command.CommandText = _dbContext.CommandGenerator.GetAllEntities(entity);
            connection.Open();
            DbDataReader reader = command.ExecuteReader();
            List<T> entities = new List<T>();
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            IEnumerable<string> properties;
            while (reader.Read())
            {
                entity = new T();
                keyValues.Clear();
                properties = _dbContext.Provider.GetProperties(entity);
                foreach (string property in properties)
                {
                    keyValues.Add(property, reader.GetValue(property));
                }
                _dbContext.Provider.SetPropertiesValues(entity, keyValues);
                entities.Add(entity);
            }
            reader.Close();
            connection.Close();
            return entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            T entity = new T();
            DbConnection connection = (DbConnection)_dbContext.Connection;
            DbCommand command = connection.CreateCommand();
            command.CommandText = _dbContext.CommandGenerator.GetAllEntities(entity);
            await connection.OpenAsync(cancellationToken);
            DbDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
            List<T> entities = new List<T>();
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            IEnumerable<string> properties;
            while (reader.Read())
            {
                entity = new T();
                keyValues.Clear();
                properties = _dbContext.Provider.GetProperties(entity);
                foreach (string property in properties)
                {
                    keyValues.Add(property, reader.GetValue(property));
                }
                _dbContext.Provider.SetPropertiesValues(entity, keyValues);
                entities.Add(entity);
            }
            await reader.CloseAsync();
            await connection.CloseAsync();
            return entities;
        }

        public async Task<T> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            T entity = new T();
            entity.Id = id;
            DbConnection connection = (DbConnection)_dbContext.Connection;
            DbCommand command = connection.CreateCommand();
            command.CommandText = _dbContext.CommandGenerator.GetEntity(id, entity);
            await connection.OpenAsync(cancellationToken);
            DbDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
            if (!reader.HasRows)
                return default(T);
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            IEnumerable<string> properties = _dbContext.Provider.GetProperties(entity);
            await reader.ReadAsync(cancellationToken);
            foreach (string property in properties)
            {
                keyValues.Add(property, reader.GetValue(property));
            }
            
            _dbContext.Provider.SetPropertiesValues(entity, keyValues);
            await reader.CloseAsync();
            await connection.CloseAsync();
            return entity;
        }

        public int Update(T entity)
        {
            IDbConnection dbConnection = _dbContext.Connection;
            IDbCommand command = dbConnection.CreateCommand();
            command.CommandText = _dbContext.CommandGenerator.UpdateEntity(entity);
            dbConnection.Open();
            int result = command.ExecuteNonQuery();
            dbConnection.Close();
            return result;
        }

        public async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            DbConnection dbConnection = (DbConnection)_dbContext.Connection;
            DbCommand command = dbConnection.CreateCommand();
            command.CommandText = _dbContext.CommandGenerator.UpdateEntity(entity);
            await dbConnection.OpenAsync(cancellationToken);
            int result = await command.ExecuteNonQueryAsync(cancellationToken);
            await dbConnection.CloseAsync();
            return result;
        }
    }
}
