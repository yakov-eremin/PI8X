using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Presentation.WPF.ViewModels
{
    public static class ViewModelsRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddTransient<PasswordDbWindowViewModel>()
            .AddTransient<AuthorizationWindowViewModel>()
            .AddTransient<PasswordGeneratorViewModel>()
            .AddTransient<CreateEntryWindowViewModel>()
            .AddTransient<CreateGroupWindowViewModel>()
        ;
    }
}
