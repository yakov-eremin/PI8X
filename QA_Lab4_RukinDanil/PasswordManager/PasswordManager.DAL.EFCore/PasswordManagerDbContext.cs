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

        public DbSet<EncryptionAlgorithm> Algorithms { get; set; }

        public PasswordManagerDbContext() : base()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.1.133;Port=5432;Database=password_manager;" +
                "Username=postgres;Password=qwerty123@");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PasswordDb>()
                .Property(p => p.DbAccessWay)
                .HasConversion<string>();

            modelBuilder.Entity<EncryptionAlgorithm>()
                .HasData(new List<EncryptionAlgorithm>()
                {
                    new EncryptionAlgorithm() { Id = 1, CodeName = "RSA", Name = "RSA", Description = "Super duper mega algorithm"},
                    new EncryptionAlgorithm() { Id = 2, CodeName = "MD5", Name = "MD5", Description = "Not so super duper mega algorithm"},
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
