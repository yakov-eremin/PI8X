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
        /// <param name="parameter">параметр пароля</param>
        /// <param name="value">значение параметра</param>
        void ConfigureParameter(Parameter parameter, object value);
    }
    /// <summary>
    /// Параметр для генератора паролей
    /// </summary>
    public enum Parameter
    {
        /// <summary>
        /// Наличие специальных символов
        /// </summary>
        SpecialSymbols,
        /// <summary>
        /// Длина пароля
        /// </summary>
        Length,
        /// <summary>
        /// Количество цифр в пароле
        /// </summary>
        DigitsCount,
        /// <summary>
        /// Количество символов верхнего регистра
        /// </summary>
        UpperCaseSymbolsCount,
        /// <summary>
        /// Наличие символов нижнего регистра
        /// </summary>
        LowerCaseSymbolsCount,
    }
}
