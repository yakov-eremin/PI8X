using Microsoft.Extensions.DependencyInjection;
using PasswordManager.DAL.EFCore;
using PasswordManager.DAL.EFCore.Entities;
using PasswordManager.Presentation.WPF.Infrastructure.Commands;
using PasswordManager.Presentation.WPF.Models;
using PasswordManager.Presentation.WPF.Models.Services;
using PasswordManager.Presentation.WPF.Models.Services.Interfaces;
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
    public class CreateEntryWindowViewModel : ClosableWindowViewModel
    {
        private PasswordManagerDbContext _dbContext;
        private ApplicationContext _applicationContext;
        public CreateEntryWindowViewModel(PasswordManagerDbContext dbContext, ApplicationContext applicationContext)
        {
            _dbContext = dbContext;
            _applicationContext = applicationContext;
            GroupsNames = GetGroupsNames();

            CloseCommand = new LambdaCommand(OnCloseCommandExecuted, CanCloseCommandExecute);
            CallGeneratePasswordWindowCommand = new LambdaCommand(OnCallGeneratePasswordWindowCommandExecuted,
                CanCallGeneratePasswordWindowCommandExecute);
            AcceptCommand = new LambdaCommand(OnAcceptCommandExecuted, CanAcceptCommandExecute);
        }

        #region Properties
        string _status = "Status";
        public string Status { get => _status; set => Set(ref _status, value); }

        string _entryName = "";
        public string EntryName { get => _entryName; set => Set(ref _entryName, value); }

        string _userName = "";
        public string UserName { get => _userName; set => Set(ref _userName, value); }

        string _password = "";
        public string Password { get => _password; set => Set(ref _password, value); }

        string _confirmPassword = "";
        public string ConfirmPassword { get => _confirmPassword; set => Set(ref _confirmPassword, value); }

        string _url = "";
        public string Url { get => _url; set => Set(ref _url, value); }

        public IEnumerable<string> GroupsNames { get; set; }
        string _selectedGroupName = "";
        public string SelectedGroupName { get => _selectedGroupName; set => Set(ref _selectedGroupName, value); }

        string _pathToImage = "";
        public string PathToImage { get => _pathToImage; set => Set(ref _pathToImage, value); }

        string _description = "";
        public string Description { get => _description; set => Set(ref _description, value); }
        #endregion

        #region Commands

        #region CloseCommand
        public ICommand CloseCommand { get; }
        private void OnCloseCommandExecuted(object p)
        {
            OnCloseWindow(new CloseWindowEventArgs(false));
        }
        private bool CanCloseCommandExecute(object p) => true;
        #endregion

        #region CallGeneratePasswordWindowCommand
        public ICommand CallGeneratePasswordWindowCommand { get; }
        private void OnCallGeneratePasswordWindowCommandExecuted(object p)
        {
            IUserDialog dialog = App.Services.GetRequiredService<UserDialog<PasswordGeneratorWindow, PasswordGeneratorViewModel>>();
            dialog.Show();
        }
        private bool CanCallGeneratePasswordWindowCommandExecute(object p) => true;
        #endregion

        #region AcceptCommand
        public ICommand AcceptCommand { get; }
        private void OnAcceptCommandExecuted(object p)
        {
            try
            {
                Status = "";
                var group = _dbContext.Groups.FirstOrDefault(g => g.Name == SelectedGroupName);
                if (group == null)
                {
                    Status = $"Группы с именем {SelectedGroupName} не существует";
                    return;
                }
                var entry = group.Entries
                    .FirstOrDefault(e => e.Name == EntryName
                    /*&& e.PasswordDb.Name == _applicationContext.CurrentPasswordDbName*/);
                if (entry != null)
                {
                    Status = $"Запись с именем {EntryName} уже существует";
                    return;
                }
                else
                {
                    entry = new Entry()
                    {
                        Name = EntryName,
                        UserPassword = Password,
                        Url = Url,
                        UserLogin = UserName,
                        
                        Group = group,
                    };
                }
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }           
        }
        private bool CanAcceptCommandExecute(object p)
        {
            return !string.IsNullOrWhiteSpace(EntryName)
                && !string.IsNullOrWhiteSpace(Password)
                && !string.IsNullOrWhiteSpace(UserName)
                && !string.IsNullOrWhiteSpace(ConfirmPassword)
                && !string.IsNullOrWhiteSpace(SelectedGroupName)
                && !string.IsNullOrWhiteSpace(Description)
                && !string.IsNullOrWhiteSpace(Url)
                && (Password == ConfirmPassword);
        }
        #endregion

        #endregion

        private IEnumerable<string> GetGroupsNames()
        {
            var groups = _dbContext.Groups
                .Where(g => g.PasswordDb.Name == _applicationContext.CurrentPasswordDbName);
            if (groups == null)
                return new List<string>();
            List<string> names = new List<string>();
            foreach (var group in groups)
            {
                names.Add(group.Name);
            }
            return names;
        }
    }
}
