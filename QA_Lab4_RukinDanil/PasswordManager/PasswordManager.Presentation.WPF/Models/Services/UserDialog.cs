using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Presentation.WPF.Models.Services.Interfaces;
using PasswordManager.Presentation.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManager.Presentation.WPF.Models.Services
{
    public class UserDialog<TWindow, TWindowViewModel> : IUserDialog 
        where TWindowViewModel : ClosableWindowViewModel
        where TWindow : Window, new()
    {
        public bool Show()
        {
            TWindow window = new TWindow();
            TWindowViewModel model = App.Services.GetRequiredService<TWindowViewModel>();
            window.DataContext = model;
            window.Owner = App.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            model.CloseWindow += (_, e) => {
                
                window.DialogResult = e.DialogResult;
                window.Close();
            };
            return window.ShowDialog() ?? false;
        }
    }
}
