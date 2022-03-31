using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Application.Interfaces;

namespace PasswordManager.Application
{
    public class MasterPasswordService : IAuthorizer
    {
        public Guid GetAccessToken()
        {
            throw new NotImplementedException();
        }
    }
}
