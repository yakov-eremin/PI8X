using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application;
using PasswordManager.DAL.EFCore;
using PasswordManager.Presentation.WPF.ViewModels;
using PasswordManager.Presentation.WPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Presentation.WPF.Models.Services
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddDbContext<PasswordManagerDbContext>()
            .AddTransient<RockPaperScissorsAuthorizer>()
            .AddTransient<UserDialog<PasswordDbWindow, PasswordDbWindowViewModel>>()
            // Register your services here
        ;
    }
}
