using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application.Interfaces;
using PasswordManager.Presentation.WPF.ViewModels;
using PasswordManager.Presentation.WPF.Views.Windows;
using PasswordManager.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager.Presentation.WPF.Models.Services
{
    public class RockPaperScissorsAuthorizer : RockPaperScissors, IAuthorizer
    {
        public override Guid Authorize()
        {
            Window window = new RockPaperScissorsGameWindow();
            RockPaperScissorsWindowViewModel data = App.Services.GetRequiredService<RockPaperScissorsWindowViewModel>();
            window.DataContext = data;
            window.Owner = App.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            data.CloseWindow += (_, e) =>
            {
                window.DialogResult = e.DialogResult;
                window.Close();
            };
            bool result = window.ShowDialog() ?? false;
            Guid key;
            if (result)
            {
                key = Guid.NewGuid();
            }
            else
            {
                key = Guid.Empty;
            }
            return key;
        }
    }
}
