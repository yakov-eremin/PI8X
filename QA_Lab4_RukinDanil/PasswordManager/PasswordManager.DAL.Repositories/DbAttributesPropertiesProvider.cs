using PasswordManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using PasswordManager.DAL.Entities.Attributes;

namespace PasswordManager.DAL.Repositories
{
    /// <summary>
    /// Поставщик данных о свойствах сущностей <see cref="IEntity"/>
    /// </summary>
    public class DbAttributesPropertiesProvider
    {
        /// <summary>
        /// Получает коллекцию всех свойств сущности <see cref="IEntity"/>, помеченных атрибутом <see cref="DbAttributeNameAttribute"/>.
        /// Сама сущность должна быть помечена атрибутом <see cref="DbTableNameAttribute"/>.
        /// </summary>
        /// <param name="entity">Сущность типа <see cref="IEntity"/></param>
        /// <returns>Коллекция имен свойств, помеченных атрибутом <see cref="DbAttributeNameAttribute"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public ICollection<string> GetProperties(IEntity entity)
        {
            List<string> result = new List<string>();
            if (CheckDbTableNameAttribute(entity))
            {
                Type type = entity.GetType();
                var properties = type.GetProperties();
                object[] attributes;
                foreach (var item in properties)
                {
                    attributes = item.GetCustomAttributes(false);
                    foreach (Attribute attribute in attributes)
                    {
                        if (attribute is DbAttributeNameAttribute nameAttribute)
                        {
                            result.Add(nameAttribute.AttributeName);
                        }
                    }
                }
            }
            else
                throw new ArgumentException($"{nameof(entity)} does not contains {nameof(DbTableNameAttribute)}.");
            return result;
        }
        /// <summary>
        /// Проверяет, что сущность помечена атрибутом <see cref="DbTableNameAttribute"/>.
        /// </summary>
        /// <param name="entity">Сущность для проверки</param>
        /// <returns>Вернет <see langword="true"/>, если сущность помечена, иначе <see langword="false"/></returns>
        public bool CheckDbTableNameAttribute(IEntity entity)
        {
            Type type = entity.GetType();
            var typeAttributes = type.GetCustomAttributes();
            bool contains = false;
            foreach (var attribute in typeAttributes)
            {
                if (attribute is DbTableNameAttribute)
                {
                    contains = true;
                    break;
                }
            }
            return contains;
        }

        /// <summary>
        /// Получает пары 'имя свойства-значение' сущности <see cref="IEntity"/>. 
        /// Обрабатывает только свойства, помеченные <see cref="DbAttributeNameAttribute"/>.
        /// </summary>
        /// <param name="entity">Сущность для получения свойств</param>
        /// <returns>Словарь пар 'имя свойства-значение'</returns>
        /// <exception cref="ArgumentException"></exception>
        public IDictionary<string, object> GetPropertiesValues(IEntity entity)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            if (CheckDbTableNameAttribute(entity))
            {
                Type type = entity.GetType();
                var properties = type.GetProperties();
                object[] attributes;
                foreach (var item in properties)
                {
                    attributes = item.GetCustomAttributes(false);
                    foreach (Attribute attribute in attributes)
                    {
                        if (attribute is DbAttributeNameAttribute nameAttribute)
                        {
                            result.Add(nameAttribute.AttributeName, item.GetValue(entity));
                        }
                    }
                }
                return result;
            }
            else
                throw new ArgumentException($"{nameof(entity)} does not contains {nameof(DbTableNameAttribute)}.");
        }
        /// <summary>
        /// Устанавливает значения свойств сущности <see cref="IEntity"/> из словаря <see cref="IDictionary{TKey, TValue}"/>
        /// </summary>
        /// <param name="entity">Сущность для обработки</param>
        /// <param name="propertiesAndValues">Словарь пар 'имя свойства-значение'</param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void SetPropertiesValues(IEntity entity, IDictionary<string, object> propertiesAndValues)
        {
            if (CheckDbTableNameAttribute(entity))
            {
                Type type = entity.GetType();
                var properties = type.GetProperties();
                object[] attributes;
                foreach (var item in properties)
                {
                    attributes = item.GetCustomAttributes(false);
                    foreach (Attribute attribute in attributes)
                    {
                        if (attribute is DbAttributeNameAttribute nameAttribute)
                        {
                            if (propertiesAndValues.TryGetValue(nameAttribute.AttributeName, out object value))
                                item.SetValue(entity, value);
                            else throw new KeyNotFoundException(nameAttribute.AttributeName);
                        }
                    }
                }
            }
            else
                throw new ArgumentException($"{nameof(entity)} does not contains {nameof(DbTableNameAttribute)}.");
        }
    }
}
