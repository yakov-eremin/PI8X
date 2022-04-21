using PasswordManager.DAL.EFCore;
using PasswordManager.DAL.EFCore.Entities;
using PasswordManager.Presentation.WPF.Infrastructure.Commands;
using PasswordManager.Presentation.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.Presentation.WPF.ViewModels
{
    public class CreateGroupWindowViewModel : ClosableWindowViewModel
    {
        private PasswordManagerDbContext _dbContext;
        private ApplicationContext _applicationContext;

        public CreateGroupWindowViewModel(PasswordManagerDbContext dbContext, ApplicationContext applicationContext)
        {
            _dbContext = dbContext;
            _applicationContext = applicationContext;
            CloseCommand = new LambdaCommand(OnCloseCommandExecuted, CanCloseCommandExecute);
            AcceptCommand = new LambdaCommand(OnAcceptCommandExecuted, CanAcceptCommandExecute);
        }

        #region Properties
        private string _status = "Status";
        public string Status { get => _status; set => Set(ref _status, value); }

        private string _goupName = "";
        public string GoupName { get => _goupName; set => Set(ref _goupName, value); }

        private string _pathToImage = "";
        public string PathToImage { get => _pathToImage; set => Set(ref _pathToImage, value); }

        private string _description = "";
        public string Description { get => _description; set => Set(ref _description, value); }
        #endregion

        #region Commands
        #region CloseCommand
        public ICommand CloseCommand { get; }
        private void OnCloseCommandExecuted(object p)
        {
            OnCloseWindow(new CloseWindowEventArgs(false));
        }
        private bool CanCloseCommandExecute(object p) => true;
        #endregion

        #region AcceptCommand
        public ICommand AcceptCommand { get; }
        private void OnAcceptCommandExecuted(object p)
        {
            Status = "";
            try
            {
                var passwordDb = _dbContext.PasswordDb
                    .FirstOrDefault(pdb => pdb.Name == _applicationContext.CurrentPasswordDbName);
                if (passwordDb == null)
                {
                    Status = $"Базы с именем '{_applicationContext.CurrentPasswordDbName}' не существует";
                    return;
                }
                var group = passwordDb.Groups.FirstOrDefault(g => g.Name == GoupName);
                if (group != null)
                {
                    Status = $"Группа с именем '{GoupName}' уже существует";
                }
                group = new Group()
                {
                    Name = GoupName,
                    PasswordDb = passwordDb,
                    PathToIcon = PathToImage,
                    Description = Description
                };
                _dbContext.Groups.Add(group);
                _dbContext.SaveChanges();
                OnCloseWindow(new CloseWindowEventArgs(true));
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }
        private bool CanAcceptCommandExecute(object p)
        {
            return !string.IsNullOrWhiteSpace(GoupName)
                && !string.IsNullOrWhiteSpace(Description);
        } 
        #endregion
        #endregion
    }
}
