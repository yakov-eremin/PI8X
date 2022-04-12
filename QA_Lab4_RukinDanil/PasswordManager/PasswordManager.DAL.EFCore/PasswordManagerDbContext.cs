using Microsoft.EntityFrameworkCore;
using PasswordManager.DAL.EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.EFCore
{
    public class PasswordManagerDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<PasswordDb> PasswordDb { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb;" +
                "Username=postgres;Password=здесь_указывается_пароль_от_postgres");
        }
    }
}
