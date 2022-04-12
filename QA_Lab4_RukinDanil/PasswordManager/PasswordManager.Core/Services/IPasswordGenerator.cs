using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Core.Services
{
    /// <summary>
    /// Генератор паролей
    /// </summary>
    public interface IPasswordGenerator
    {
        /// <summary>
        /// Генерирует пароль, если метод <see cref="ConfigureParameter(Parameter, object)"/> не вызывался, то используются
        /// параметры по умолчанию.
        /// </summary>
        /// <returns>сгенерированный пароль</returns>
        string Generate();
        /// <summary>
        /// Конфигурирует параметр пароля
        /// </summary>
        /// <param name="options">параметры пароля</param>
        void ConfigureParameters(GenerationOptions options);
    }

    public class GenerationOptions
    {
        protected int _length = 8;
        public int Length
        {
            get => _length;
            set => _length = value < 1 ? 1 : value;
        }

        public int DigitsCount { get; set; } = 0;
        public int UpperCaseSymbolsCount { get; set; } = 0;
        public int LowerCaseSymbolsCount { get; set; } = 0;
        public List<char> SpecialSymbols { get; set; } = new List<char>();

        public virtual void SetDefaults()
        {
            SpecialSymbols = new List<char>();
            Length = 8;
            UpperCaseSymbolsCount = 0;
            LowerCaseSymbolsCount = 0;
            DigitsCount = 0;
        }
    }
}
