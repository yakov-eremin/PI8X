using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application;
using PasswordManager.Core.Services;
using PasswordManager.DAL.EFCore;
using PasswordManager.Presentation.WPF.ViewModels;
using PasswordManager.Presentation.WPF.Views.Windows;
using PasswordManager.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Presentation.WPF.Models.Services
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddDbContext<PasswordManagerDbContext>()
            .AddSingleton<IPasswordGenerator, PasswordGenerator>()
            .AddTransient<RockPaperScissorsAuthorizer>()
            .AddTransient<RockPaperScissors, RockPaperScissorsAuthorizer>()            
            .AddTransient<UserDialog<PasswordDbWindow, PasswordDbWindowViewModel>>()
            .AddTransient<UserDialog<PasswordGeneratorWindow, PasswordGeneratorViewModel>>()
            .AddTransient<UserDialog<EntryWindow, CreateEntryWindowViewModel>>()
            .AddTransient<UserDialog<GroupWindow, CreateGroupWindowViewModel>>()
            // Register your services here
        ;
    }
}
