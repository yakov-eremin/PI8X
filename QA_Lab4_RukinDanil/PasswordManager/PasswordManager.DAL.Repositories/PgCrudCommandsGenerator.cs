using PasswordManager.DAL.Entities;
using PasswordManager.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Repositories
{
    /// <summary>
    /// Простой генератор CRUD команд для баз Postgres
    /// </summary>
    /// <inheritdoc/>
    public class PgCrudCommandsGenerator : ICrudCommandsGenerator
    {
        protected IDbCommandBuilder _commandBuilder;
        protected DbAttributesPropertiesProvider _propertiesProvider;
        /// <summary>
        /// Создает <see cref="PgCrudCommandsGenerator"/>
        /// </summary>
        /// <param name="commandBuilder">строитель запросов</param>
        /// <param name="propertiesProvider">провайдер данных для сущностей <see cref="IEntity"/></param>
        public PgCrudCommandsGenerator(IDbCommandBuilder commandBuilder, DbAttributesPropertiesProvider propertiesProvider)
        {
            _commandBuilder = commandBuilder;
            _propertiesProvider = propertiesProvider;
        }

        public string CreateEntity(IEntity entity)
        {
            _commandBuilder.ResetBuilder();
            IDictionary<string, object> keyValuePairs = _propertiesProvider.GetPropertiesValues(entity);
            List<object> values = new List<object>();
            foreach (var keyValue in keyValuePairs)
            {
                values.Add(keyValue.Value);
            }
            string result;
            result = _commandBuilder.Insert()
                .Into(_propertiesProvider.GetTableName(entity), _propertiesProvider.GetProperties(entity))
                .Values(values)
                .GetCommand();
            return result;
        }

        public string UpdateEntity(IEntity entity)
        {
            _commandBuilder.ResetBuilder();
            string result = _commandBuilder.Update(_propertiesProvider.GetTableName(entity))
                .Set(_propertiesProvider.GetPropertiesValues(entity))
                .Where($"{_propertiesProvider.GetPropertyNameInDatabase(entity, nameof(entity.Id))} = {entity.Id}")
                .GetCommand();
            return result;
        }

        public string DeleteEntity(int id, IEntity entity)
        {
            _commandBuilder.ResetBuilder();
            string result = _commandBuilder.Delete()
                .From(_propertiesProvider.GetTableName(entity))
                .Where($"{_propertiesProvider.GetPropertyNameInDatabase(entity, nameof(entity.Id))} = {id}")
                .GetCommand();
            return result;
        }

        public string GetEntity(int id, IEntity emptyEntity)
        {
            _commandBuilder.ResetBuilder();
            string result = _commandBuilder.Select(_propertiesProvider.GetProperties(emptyEntity))
                .From(_propertiesProvider.GetTableName(emptyEntity))
                .Where($"{_propertiesProvider.GetPropertyNameInDatabase(emptyEntity, nameof(emptyEntity.Id))} = {id}")
                .GetCommand();
            return result;
        }

        public string GetAllEntities(IEntity entity)
        {
            _commandBuilder.ResetBuilder();
            string result = _commandBuilder.Select(null)
                .From(_propertiesProvider.GetTableName(entity))
                .GetCommand();
            return result;
        }
    }
}
