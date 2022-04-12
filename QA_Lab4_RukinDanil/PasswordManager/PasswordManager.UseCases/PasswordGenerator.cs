using PasswordManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.UseCases
{
    /// <summary>
    /// Простой генератор паролей
    /// </summary>
    /// <inheritdoc/>
    public class PasswordGenerator : IPasswordGenerator
    {
        private GenerationOptions _options = new GenerationOptions();
        private List<PasswordSymbols> _passwordSymbols = new List<PasswordSymbols>();

        public void ConfigureParameters(GenerationOptions options)
        {
            CheckOptions(options);
            _options = options;
            MixOptions();
        }

        public string Generate()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            List<char> specialSymbols = CloneList(_options.SpecialSymbols);
            foreach (var item in _passwordSymbols)
            {
                if (item == PasswordSymbols.UpperCaseSymbol)
                    builder.Append(char.ToUpper((char)random.Next('a', 'z' + 1)));
                else if (item == PasswordSymbols.LowerCaseSymbol)
                    builder.Append((char)random.Next('a', 'z' + 1));
                else if (item == PasswordSymbols.SpecialSymbol)
                {
                    int index = random.Next(0, specialSymbols.Count);
                    builder.Append(specialSymbols[index]);
                    specialSymbols.RemoveAt(index);
                }                   
                else
                    builder.Append((char)random.Next('0', '9' + 1));
            }
            return builder.ToString();
        }

        private List<T> CloneList<T>(List<T> specialSymbols)
        {
            List<T> newSpecialSymbols = new List<T>();
            foreach (T item in specialSymbols)
                newSpecialSymbols.Add(item);
            return newSpecialSymbols;
        }

        private void MixOptions()
        {
            _passwordSymbols.Clear();
            List<PasswordSymbols> tmp = new List<PasswordSymbols>();
            for (int i = 0; i < _options.UpperCaseSymbolsCount; i++)
            {
                tmp.Add(PasswordSymbols.UpperCaseSymbol);
            }
            for (int i = 0; i < _options.LowerCaseSymbolsCount; i++)
            {
                tmp.Add(PasswordSymbols.LowerCaseSymbol);
            }
            for (int i = 0; i < _options.DigitsCount; i++)
            {
                tmp.Add(PasswordSymbols.Digit);
            }
            for (int i = 0; i < _options.SpecialSymbols.Count; i++)
            {
                tmp.Add(PasswordSymbols.SpecialSymbol);
            }

            int count = _options.DigitsCount + _options.LowerCaseSymbolsCount + _options.UpperCaseSymbolsCount
                + _options.SpecialSymbols.Count;
            if (_options.Length > count)
            {
                int difference = _options.Length - count;
                for (int i = 0; i < difference; i++)
                    tmp.Add(PasswordSymbols.LowerCaseSymbol);
            }    

            Random random = new Random();
            int index = 0;
            while (tmp.Count > 0)
            {
                index = random.Next(0, tmp.Count);
                _passwordSymbols.Add(tmp[index]);
                tmp.RemoveAt(index);
            }
        }

        private void CheckOptions(GenerationOptions options)
        {
            if (options.Length < 1)
                throw new ArgumentException("Длина пароля не может быть меньше 1", nameof(options.Length));
            int count = options.DigitsCount + options.LowerCaseSymbolsCount + options.UpperCaseSymbolsCount
                + options.SpecialSymbols.Count;
            if (options.Length < count)
                throw new InvalidOperationException($"Длина пароля '{options.Length}' меньше," +
                    $" чем минимальная длина при текущих настройках '{count}'");
        }
    }

    internal enum PasswordSymbols
    {
        UpperCaseSymbol,
        LowerCaseSymbol,
        Digit,
        SpecialSymbol,
    }
}
