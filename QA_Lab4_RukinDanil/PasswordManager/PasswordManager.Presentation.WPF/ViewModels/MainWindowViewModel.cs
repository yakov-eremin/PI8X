using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Presentation.WPF.Infrastructure.Commands;
using PasswordManager.Presentation.WPF.Models.Services;
using PasswordManager.Presentation.WPF.Models.Services.Interfaces;
using PasswordManager.Presentation.WPF.ViewModels.Base;
using PasswordManager.Presentation.WPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Markup;

namespace PasswordManager.Presentation.WPF.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            CreatePasswordDbCommand = new LambdaCommand(OnCreatePasswordDbCommandExecuted, 
                CanCreatePasswordDbCommandExecute);
        }

        #region Properties
        private string _title = "Title";
        public string Title { get => _title; set => Set(ref _title, value); }

        private string _status = "Status";
        public string Status { get => _status; set => Set(ref _status, value); }
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

        #endregion
    }
}
