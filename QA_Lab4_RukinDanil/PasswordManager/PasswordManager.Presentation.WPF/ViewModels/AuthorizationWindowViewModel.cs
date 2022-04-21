using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application;
using PasswordManager.Application.Interfaces;
using PasswordManager.DAL.EFCore;
using PasswordManager.DAL.EFCore.Entities;
using PasswordManager.Presentation.WPF.Infrastructure.Commands;
using PasswordManager.Presentation.WPF.Models;
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
        private ApplicationContext _applicationContext;
        public AuthorizationWindowViewModel(PasswordManagerDbContext dbContext, ApplicationContext context)
        {
            _dbContext = dbContext;
            _applicationContext = context;
            UpdatePasswordDbs();
            CallMiniGameCommand = new LambdaCommand(OnCallMiniGameCommandExecuted, CanCallMiniGameCommandExecute);
            NextWindowCommand = new LambdaCommand(OnNextWindowCommandExecuted, CanNextWindowCommandExecute);
            CreatePasswordDbCommand = new LambdaCommand(OnCreatePasswordDbCommandExecuted,
                CanCreatePasswordDbCommandExecute);
        }

        #region Properties
        public string UserName => Environment.UserName;
        private string _masterPassword = "";
        public string MasterPassword { get => _masterPassword; set => Set(ref _masterPassword, value); }

        public ObservableCollection<PasswordDb> PasswordDbsNames { get; } = new ObservableCollection<PasswordDb>();
        
        private PasswordDb _selectedPasswordDb;
        public PasswordDb SelectedPasswordDb
        {
            get => _selectedPasswordDb;
            set
            {
                Set(ref _selectedPasswordDb, value);
                _hasAccess = false;
            }
        }

        private string _status = "";
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }

        private bool _hasAccess = false;
        #endregion


        #region Commands

        #region CallMiniGameCommand
        public ICommand CallMiniGameCommand { get; }
        private void OnCallMiniGameCommandExecuted(object p)
        {
            try
            {
                Status = "";
                PasswordDb passwordDb = _dbContext.PasswordDb
                    .Where(pdb => pdb.Name == SelectedPasswordDb.Name)
                    .FirstOrDefault();
                if (passwordDb == default(PasswordDb))
                {
                    Status = $"Базы с имененем {SelectedPasswordDb.Name} не существует";
                    return;
                }
                IAuthorizer authorizer = App.Services.GetRequiredService<RockPaperScissorsAuthorizer>();
                Guid accessToken = authorizer.Authorize();
                if(accessToken == Guid.Empty)
                {
                    Status = "Вы не прошли авторизацию";
                    return;
                }
                _applicationContext.CurrentPasswordDbName = passwordDb.Name;
                _hasAccess = true;
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }

        private bool CanCallMiniGameCommandExecute(object p) => !string.IsNullOrWhiteSpace(SelectedPasswordDb.Name);
        #endregion

        #region NextWindowCommand
        public ICommand NextWindowCommand { get; }
        private void OnNextWindowCommandExecuted(object p)
        {
            try
            {
                Status = "";
                PasswordDb passwordDb = _dbContext.PasswordDb
                .Where(pdb => pdb.Name == SelectedPasswordDb.Name)
                .FirstOrDefault();
                if (passwordDb == default(PasswordDb))
                {
                    Status = $"Базы с имененем {SelectedPasswordDb.Name} не существует";
                    return;
                }
                if (passwordDb.MasterPassword == null || passwordDb.MasterPassword != MasterPassword)
                {
                    Status = $"Неверный пароль";
                    return;
                }
                _applicationContext.CurrentPasswordDbName = passwordDb.Name;
                App.Current.MainWindow = new MainWindow();
                OnCloseWindow(new CloseWindowEventArgs(true));
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }            
        }
        private bool CanNextWindowCommandExecute(object p) => _hasAccess;
        #endregion

        #region CreatePasswordDbCommand
        public ICommand CreatePasswordDbCommand { get; }
        private void OnCreatePasswordDbCommandExecuted(object p)
        {
            try
            {
                Status = "";
                IUserDialog userDialog = App.Services.GetRequiredService<UserDialog<PasswordDbWindow, PasswordDbWindowViewModel>>();
                if (userDialog.Show())
                {
                    UpdatePasswordDbs();
                }
            }
            catch (Exception e)
            {
                Status = e.Message;
            }            
        }
        private bool CanCreatePasswordDbCommandExecute(object p) => true;
        #endregion

        #endregion

        private void UpdatePasswordDbs()
        {
            PasswordDbsNames.Clear();
            IEnumerable<PasswordDb> dbs = _dbContext.PasswordDb;
            if (dbs == null)
                return;
            foreach (var item in dbs)
            {
                PasswordDbsNames.Add(item);
            }
            SelectedPasswordDb = PasswordDbsNames.FirstOrDefault();
            return;
        }
    }
}
