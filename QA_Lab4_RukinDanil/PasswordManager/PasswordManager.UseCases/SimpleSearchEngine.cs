using PasswordManager.Core.Entities;
using PasswordManager.Core.Services;
using PasswordManager.DAL.Entities;
using PasswordManager.DAL.Repositories;
using PasswordManager.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.UseCases
{
    public class SimpleSearchEngine : ISearchEngine
    {
        private IDbCommandBuilder _commandBuilder;
        private IDbContext _dbContext;
        private DefaultRepository<DbEntry> _entryRepository;
        public IEntry FindEntry(string name)
        {
            throw new NotImplementedException();
        }

        public IGroup FindGroup(string name)
        {
            throw new NotImplementedException();
        }

        public IPasswordDb FindPasswordDb(string name)
        {
            throw new NotImplementedException();
        }
    }
}
