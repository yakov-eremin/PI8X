using PasswordManager.Application.Interfaces;
using PasswordManager.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Presentation.WPF.Models.Services
{
    public class RockPaperScissorsAuthorizer : RockPaperScissors, IAuthorizer
    {
        public override Guid Authorize()
        {
            throw new NotImplementedException();
        }
    }
}
