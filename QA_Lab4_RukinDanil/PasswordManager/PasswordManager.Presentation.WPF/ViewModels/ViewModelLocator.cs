using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Presentation.WPF.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
        public AuthorizationWindowViewModel AuthorizationWindowViewModel =>
            App.Services.GetRequiredService<AuthorizationWindowViewModel>();
    }
}
