using Microsoft.EntityFrameworkCore;
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

            UpdateGroupsAndEntries();

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

        public ObservableCollection<Group> Groups { get; set; } = new ObservableCollection<Group>();
        private Group _selectedGroup;
        public Group SelectedGroup 
        { 
            get => _selectedGroup;
            set
            {
                Set(ref _selectedGroup, value);
                UpdateEntries();
            }
        }

        public ObservableCollection<Entry> Entries { get; set; } = new ObservableCollection<Entry>();
        private Entry _selectedEntry;
        public Entry SelectedEntry { get => _selectedEntry; set => Set(ref _selectedEntry, value); }
        #endregion

        #region Commands

        #region CreatePasswordDbCommand
        public ICommand CreatePasswordDbCommand { get; }
        private void OnCreatePasswordDbCommandExecuted(object p)
        {
            try
            {
                Status = "";
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
            try
            {
                Status = "";
                IUserDialog dialog = App.Services.GetRequiredService<UserDialog<PasswordGeneratorWindow, PasswordGeneratorViewModel>>();
                dialog.Show();
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
        }
        private bool CanCallGeneratePasswordWindowCommandExecute(object p) => true;
        #endregion

        #region CreateEntryCommand
        public ICommand CreateEntryCommand { get; }
        private void OnCreateEntryCommandExecuted(object p)
        {
            try
            {
                Status = "";
                IUserDialog dialog = App.Services.GetRequiredService<UserDialog<EntryWindow, CreateEntryWindowViewModel>>();
                if (dialog.Show())
                {
                    UpdateGroupsAndEntries();
                }
            }
            catch (Exception e)
            {
                Status = e.Message;
            }
        }
        private bool CanCreateEntryCommandExecute(object p) => true;
        #endregion

        #region CreateGroupCommand
        public ICommand CreateGroupCommand { get; }
        private void OnCreateGroupCommandExecuted(object p)
        {
            try
            {
                Status = "";
                IUserDialog dialog = App.Services.GetRequiredService<UserDialog<GroupWindow, CreateGroupWindowViewModel>>();
                if (dialog.Show())
                {
                    UpdateGroupsAndEntries();
                }
            }
            catch (Exception e)
            {
                Status = e.Message;
            }           
        }
        private bool CanCreateGroupCommandExecute(object p) => true; 
        #endregion

        #endregion

        private void AddDefaultDatabase()
        {
            if (string.IsNullOrWhiteSpace(_applicationContext.CurrentPasswordDbName))
            {
                var db = _dbContext.PasswordDb
                    .FirstOrDefault(b => b.Name == "Default");
                if (db == null)
                {
                    db = new PasswordDb()
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

        private void UpdateGroups()
        {
            Groups.Clear();
            PasswordDb passwordDb = _dbContext.PasswordDb.Include(db => db.Groups)
                .FirstOrDefault(p => p.Name == _applicationContext.CurrentPasswordDbName);
            if (passwordDb == null)
                return;
            var groups = passwordDb.Groups;
            foreach (var item in groups)
            {
                Groups.Add(item);
            }
            return;
        }

        private void UpdateEntries()
        {
            Entries.Clear();
            if (SelectedGroup == null)
                return;
            var group = _dbContext.Groups.Include(g => g.Entries)
                .FirstOrDefault(g => g.Name == SelectedGroup.Name && g.PasswordDb.Name == _applicationContext.CurrentPasswordDbName);
            if (group == null)
                return;
            var entries = group.Entries;
            foreach (var entry in entries)
            {
                Entries.Add(entry);
            }
            return;
        }

        private void UpdateGroupsAndEntries()
        {
            UpdateGroups();
            SelectedGroup = Groups.FirstOrDefault();
            UpdateEntries();
            SelectedEntry = Entries.FirstOrDefault();
        }
    }
}
