using Microsoft.Extensions.DependencyInjection;
using PasswordManager.Application;
using PasswordManager.DAL.EFCore;
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
            // Register your services here
        ;
    }
}
