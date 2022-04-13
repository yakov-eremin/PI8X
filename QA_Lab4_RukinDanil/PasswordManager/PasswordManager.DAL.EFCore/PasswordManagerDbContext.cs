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
            optionsBuilder.UseNpgsql("Host=192.168.1.133;Port=5432;Database=password_manager;" +
                "Username=postgres;Password=qwerty123@");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PasswordDb>()
                .Property(p => p.DbAccessWay)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
