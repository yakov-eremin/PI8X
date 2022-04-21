using PasswordManager.Core.Services;
using PasswordManager.Presentation.WPF.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.Presentation.WPF.ViewModels
{
    public class PasswordGeneratorViewModel : ClosableWindowViewModel
    {
        IPasswordGenerator _passwordGenerator;
        public PasswordGeneratorViewModel(IPasswordGenerator passwordGenerator)
        {
            _passwordGenerator = passwordGenerator;
            GeneratePasswordCommand = new LambdaCommand(OnGeneratePasswordCommandExecuted, CanGeneratePasswordCommandExecute);
            CloseCommand = new LambdaCommand(OnCloseCommandExecuted, CanCloseCommandExecute);
        }

        #region Properties
        private string _passwordLength = "";
        public string PasswordLength { get => _passwordLength; set => Set(ref _passwordLength, value); }

        private bool _useUpperCase = false;
        public bool UseUpperCase { get => _useUpperCase; set => Set(ref _useUpperCase, value); }

        private string _upperCaseSymbolsCount = "";
        public string UpperCaseSymbolsCount { get => _upperCaseSymbolsCount; set => Set(ref _upperCaseSymbolsCount, value); }

        private bool _useLowerCase = false;
        public bool UseLowerCase { get => _useLowerCase; set => Set(ref _useLowerCase, value); }

        private string _lowerCaseSymbolsCount = "";
        public string LowerCaseSymbolsCount { get => _lowerCaseSymbolsCount; set => Set(ref _lowerCaseSymbolsCount, value); }

        private bool _useDigits = false;
        public bool UseDigits { get => _useDigits; set => Set(ref _useDigits, value); }

        private string _digitsCount = "";
        public string DigitsCount { get => _digitsCount; set => Set(ref _digitsCount, value); }

        private string _specialSymbols = "";
        public string SpecialSymbols { get => _specialSymbols; set => Set(ref _specialSymbols, value); }

        private string _result = "";
        public string Result { get => _result; set => Set(ref _result, value); }

        private string _status = "Status";
        public string Status { get => _status; set => Set(ref _status, value); }

        #endregion

        #region Commands

        #region GeneratePasswordCommand
        public ICommand GeneratePasswordCommand { get; }
        private void OnGeneratePasswordCommandExecuted(object p)
        {
            try
            {
                Status = "";
                GenerationOptions options = new GenerationOptions();
                if (!string.IsNullOrWhiteSpace(PasswordLength))
                {
                    options.Length = Convert.ToInt32(PasswordLength);
                }
                if (UseLowerCase)
                {
                    options.LowerCaseSymbolsCount = Convert.ToInt32(LowerCaseSymbolsCount);
                }
                if (UseUpperCase)
                {
                    options.UpperCaseSymbolsCount = Convert.ToInt32(UpperCaseSymbolsCount);
                }
                if (UseDigits)
                {
                    options.DigitsCount = Convert.ToInt32(DigitsCount);
                }
                if (!string.IsNullOrWhiteSpace(SpecialSymbols))
                {
                    string[] symbols = SpecialSymbols.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    List<char> specialSymbols = new List<char>();
                    for (int i = 0; i < symbols.Length; i++)
                    {
                        specialSymbols.Add(char.Parse(symbols[i]));
                    }
                    options.SpecialSymbols = specialSymbols;
                }
                _passwordGenerator.ConfigureParameters(options);
                Result = _passwordGenerator.Generate();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }           
        }
        private bool CanGeneratePasswordCommandExecute(object p) => true;
        #endregion

        #region CloseCommand
        public ICommand CloseCommand { get; }
        private void OnCloseCommandExecuted(object p)
        {
            OnCloseWindow(new CloseWindowEventArgs(true));
        }
        private bool CanCloseCommandExecute(object p) => true;
        #endregion



        #endregion
    }
}
