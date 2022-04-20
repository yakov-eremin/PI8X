using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application;
using PasswordManager.Application.Interfaces;
using PasswordManager.DAL.EFCore;
using PasswordManager.DAL.EFCore.Entities;
using PasswordManager.Presentation.WPF.Infrastructure.Commands;
using PasswordManager.Presentation.WPF.Models.Services;
using PasswordManager.Presentation.WPF.Models.Services.Interfaces;
using PasswordManager.Presentation.WPF.ViewModels.Base;
using PasswordManager.Presentation.WPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.Presentation.WPF.ViewModels
{
    public class AuthorizationWindowViewModel : ClosableWindowViewModel
    {
        private PasswordManagerDbContext _dbContext;
        public AuthorizationWindowViewModel(PasswordManagerDbContext dbContext) : base()
        {
            _dbContext = dbContext;
        }
        public AuthorizationWindowViewModel()
        {
            CallMiniGameCommand = new LambdaCommand(OnCallMiniGameCommandExecuted, CanCallMiniGameCommandExecute);
            NextWindowCommand = new LambdaCommand(OnNextWindowCommandExecuted, CanNextWindowCommandExecute);
            CreatePasswordDbCommand = new LambdaCommand(OnCreatePasswordDbCommandExecuted,
                CanCreatePasswordDbCommandExecute);
        }

        #region Properties
        public string UserName => Environment.UserName;
        private string _masterPassword = "";
        public string MasterPassword { get => _masterPassword; set => Set(ref _masterPassword, value); }

        public ObservableCollection<string> PasswordDbsNames { get; } = new ObservableCollection<string>();
        
        private int _selectedPasswordDbIndex = 0;
        public int SelectedPasswordDbIndex
        {
            get => _selectedPasswordDbIndex;
            set => Set(ref _selectedPasswordDbIndex, value);
        }
        private string _selectedPasswordDbName = "";
        public string SelectedPasswordDbName { get => _selectedPasswordDbName; 
            set => Set(ref _selectedPasswordDbName, value); }

        private string _status = "";
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion


        #region Commands

        #region CallMiniGameCommand
        public ICommand CallMiniGameCommand { get; }
        private void OnCallMiniGameCommandExecuted(object p)
        {
            try
            {
                PasswordDb passwordDb = _dbContext.PasswordDb
                    .Where(pdb => pdb.Name == SelectedPasswordDbName)
                    .FirstOrDefault();
                if (passwordDb == default(PasswordDb))
                {
                    Status = $"Базы с имененем {SelectedPasswordDbName} не существует";
                    return;
                }
                IAuthorizer authorizer = App.Services.GetRequiredService<RockPaperScissorsAuthorizer>();
                Guid accessToken = authorizer.Authorize();
                if(accessToken == Guid.Empty)
                {
                    Status = "Вы не прошли авторизацию";
                    return;
                }
                OnCloseWindow(new CloseWindowEventArgs(true));
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }

        private bool CanCallMiniGameCommandExecute(object p) => !string.IsNullOrWhiteSpace(SelectedPasswordDbName);
        #endregion

        #region NextWindowCommand
        public ICommand NextWindowCommand { get; }
        private void OnNextWindowCommandExecuted(object p)
        {
            try
            {
                PasswordDb passwordDb = _dbContext.PasswordDb
                .Where(pdb => pdb.Name == SelectedPasswordDbName)
                .FirstOrDefault();
                if (passwordDb == default(PasswordDb))
                {
                    Status = $"Базы с имененем {SelectedPasswordDbName} не существует";
                    return;
                }
                if (passwordDb.MasterPassword == null || passwordDb.MasterPassword != MasterPassword)
                {
                    Status = $"Неверный пароль";
                    return;
                }
                OnCloseWindow(new CloseWindowEventArgs(true));
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }            
        }
        private bool CanNextWindowCommandExecute(object p)
        {
            if (string.IsNullOrWhiteSpace(SelectedPasswordDbName))
                return false;
            if (string.IsNullOrWhiteSpace(MasterPassword))
                return false;
            return true;
        }
        #endregion

        #region CreatePasswordDbCommand
        public ICommand CreatePasswordDbCommand { get; }
        private void OnCreatePasswordDbCommandExecuted(object p)
        {
            IUserDialog userDialog = App.Services.GetRequiredService<UserDialog<PasswordDbWindow, PasswordDbWindowViewModel>>();

        }
        private bool CanCreatePasswordDbCommandExecute(object p) => true;
        #endregion

        #endregion


    }
}
