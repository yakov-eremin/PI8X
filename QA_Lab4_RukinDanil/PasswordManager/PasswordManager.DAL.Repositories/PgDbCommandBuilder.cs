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
    /// Генератор команд для баз данных Postgres
    /// </summary>
    /// <inheritdoc/>
    public class PgDbCommandBuilder : IDbCommandBuilder
    {
        protected StringBuilder _builder;

        public PgDbCommandBuilder()
        {
            _builder = new StringBuilder();
        }
        public IDbCommandBuilder Delete(bool shouldReset = false)
        {
            if (shouldReset) ResetBuilder();
            _builder.Append("delete ");
            return this;
        }

        public IDbCommandBuilder From(string tableName, bool shouldReset = false)
        {
            if (shouldReset) ResetBuilder();
            _builder.Append($"{tableName} ");
            return this;
        }

        public string GetCommand() => _builder.Append(";").ToString();

        public IDbCommandBuilder Insert(bool shouldReset = false)
        {
            if (shouldReset) ResetBuilder();
            _builder.Append("insert ");
            return this;
        }

        public IDbCommandBuilder Into(string tableName, IEnumerable<string> parameters, bool shouldReset = false)
        {
            if (shouldReset) ResetBuilder();
            _builder.Append($"into {tableName} ({parameters.GetString()}) ");
            return this;
        }

        public void ResetBuilder() => _builder = _builder.Clear();

        public IDbCommandBuilder Select(IEnumerable<string> parameters, bool shouldReset = false)
        {
            if (shouldReset) ResetBuilder();
            if (parameters == null || parameters.Count() == 0)
                _builder.Append("select * ");
            else
                _builder.Append($"select {parameters.GetString()} ");
            return this;
        }

        public IDbCommandBuilder Set(IDictionary<string, object> propertiesAndValues, bool shouldReset = false)
        {
            if (shouldReset) ResetBuilder();
            _builder.Append($"set {propertiesAndValues.GetString()} ");
            return this;
        }

        public IDbCommandBuilder Update(string tableName, bool shouldReset = false)
        {
            if (shouldReset) ResetBuilder();
            _builder.Append($"update {tableName} ");
            return this;
        }

        public IDbCommandBuilder Values(IEnumerable<object> values, bool shouldReset = false)
        {
            if (shouldReset) ResetBuilder();
            _builder.Append($"values ({values.GetString()}) ");
            return this;
        }

        public IDbCommandBuilder Where(string condition, bool shouldReset = false)
        {
            if (shouldReset) ResetBuilder();
            _builder.Append($"where {condition} ");
            return this;
        }
    }
    
    internal static class ColletionsExtensions
    {
        internal static string GetString(this IEnumerable<string> collection)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in collection)
            {
                stringBuilder.Append($"{item}, ");
            }
            string result = stringBuilder.ToString();
            return result.Substring(0, result.Length - 2);
        }

        internal static string GetString(this IDictionary<string, object> dictionary)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in dictionary)
            {
                if (item.Value.GetType() == typeof(string))
                    stringBuilder.Append($"{item.Key} = '{item.Value}', ");
                else if (item.Value.GetType() == typeof(DateTime))
                    stringBuilder.Append($"{item.Key} = make_date({((DateTime)item.Value).Year}, {((DateTime)item.Value).Month}, {((DateTime)item.Value).Day}), ");
                else
                    stringBuilder.Append($"{item.Key} = {item.Value}, ");
            }
            string result = stringBuilder.ToString();
            return result.Substring(0, result.Length - 2);
        }

        internal static string GetString(this IEnumerable<object> values)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in values)
            {
                if (item.GetType() == typeof(string))
                    stringBuilder.Append($"'{item}', ");
                else if (item.GetType() == typeof(DateTime))
                    stringBuilder.Append($"make_date({((DateTime)item).Year}, {((DateTime)item).Month}, {((DateTime)item).Day}), ");
                else
                    stringBuilder.Append($"{item}, ");
            }
            string result = stringBuilder.ToString();
            return result.Substring(0, result.Length - 2);
        }
    }
}
