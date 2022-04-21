using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Input;
using System.Windows.Markup;

namespace PasswordManager.Presentation.WPF.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : ViewModel
    {
        private PasswordManagerDbContext _dbContext;
        private ApplicationContext _applicationContext;
        public MainWindowViewModel(PasswordManagerDbContext dbContext, ApplicationContext applicationContext)
        {
            _dbContext = dbContext;
            _applicationContext = applicationContext;
            AddDefaultDatabase(); // обманка
            CreatePasswordDbCommand = new LambdaCommand(OnCreatePasswordDbCommandExecuted, 
                CanCreatePasswordDbCommandExecute);
            CallGeneratePasswordWindowCommand = new LambdaCommand(OnCallGeneratePasswordWindowCommandExecuted,
                CanCallGeneratePasswordWindowCommandExecute);
            CreateEntryCommand = new LambdaCommand(OnCreateEntryCommandExecuted, CanCreateEntryCommandExecute);
            CreateGroupCommand = new LambdaCommand(OnCreateGroupCommandExecuted, CanCreateGroupCommandExecute);
        }

        #region Properties
        private string _title = "Title";
        public string Title { get => _title; set => Set(ref _title, value); }

        private string _status = "Status";
        public string Status { get => _status; set => Set(ref _status, value); }

        public ObservableCollection<Group> Groups { get; set; }
        public Group SelectedGroup { get; set; }

        public ObservableCollection<Entry> Entries { get; set; }
        public Entry SelectedEntry { get; set; }
        #endregion

        #region Commands

        #region CreatePasswordDbCommand
        public ICommand CreatePasswordDbCommand { get; }
        private void OnCreatePasswordDbCommandExecuted(object p)
        {
            try
            {
                IUserDialog dialog = App.Services.GetRequiredService<UserDialog<PasswordDbWindow, PasswordDbWindowViewModel>>();
                bool result = dialog.Show();
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }           
        }
        private bool CanCreatePasswordDbCommandExecute(object p) => true;
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

        #region CreateEntryCommand
        public ICommand CreateEntryCommand { get; }
        private void OnCreateEntryCommandExecuted(object p)
        {
            IUserDialog dialog = App.Services.GetRequiredService<UserDialog<EntryWindow, CreateEntryWindowViewModel>>();
            dialog.Show();
        }
        private bool CanCreateEntryCommandExecute(object p) => true;
        #endregion

        #region CreateGroupCommand
        public ICommand CreateGroupCommand { get; }
        private void OnCreateGroupCommandExecuted(object p)
        {
            IUserDialog dialog = App.Services.GetRequiredService<UserDialog<GroupWindow, CreateGroupWindowViewModel>>();
            dialog.Show();
        }
        private bool CanCreateGroupCommandExecute(object p) => true; 
        #endregion

        #endregion

        private void AddDefaultDatabase()
        {
            if (string.IsNullOrWhiteSpace(_applicationContext.CurrentPasswordDbName))
            {
                var db = _dbContext.PasswordDb
                    .FirstOrDefault(b => b.Name == _applicationContext.CurrentPasswordDbName);
                if (db == null)
                {
                    db = new DAL.EFCore.Entities.PasswordDb()
                    {
                        Name = "Default",
                        Description = "Default database description",
                        EncryptionAlgorithm = _dbContext.Algorithms.First()
                    };
                    _dbContext.PasswordDb.Add(db);
                    _dbContext.SaveChanges();
                }
                _applicationContext.CurrentPasswordDbName = db.Name;
            }
        }
    }
}
