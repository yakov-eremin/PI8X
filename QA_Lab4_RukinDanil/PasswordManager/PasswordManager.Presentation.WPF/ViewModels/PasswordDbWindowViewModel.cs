using PasswordManager.DAL.EFCore;
using PasswordManager.DAL.EFCore.Entities;
using PasswordManager.Presentation.WPF.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.Presentation.WPF.ViewModels
{
    public class PasswordDbWindowViewModel : ClosableWindowViewModel
    {
        private PasswordManagerDbContext _dbContext;

        public PasswordDbWindowViewModel(PasswordManagerDbContext dbContext) : base()
        {
            _dbContext = dbContext;
            AcceptCommand = new LambdaCommand(OnAcceptCommandExecuted, CanAcceptCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted, CanCancelCommandExecute);
        }

        #region Properties

        private string _userName = "";
        public string UserName { get => _userName; set => Set(ref _userName, value); }

        private string _passwordFromDb = "";
        public string PasswordFromDb { get => _passwordFromDb; set => Set(ref _passwordFromDb, value); }

        private string _databaseName = "";
        public string DatabaseName { get => _databaseName; set => Set(ref _databaseName, value); }

        private string _databaseDescription = "";
        public string DatabaseDescription { get => _databaseDescription; set => Set(ref _databaseDescription, value); }

        private string _pathToImage = "";
        public string PathToImage { get => _pathToImage; set => Set(ref _pathToImage, value); }

        private string _status = "Status";
        public string Status { get => _status; set => Set(ref _status, value); }

        public IEnumerable<DbAccessWay> DbAccessWays => Enum.GetValues(typeof(DbAccessWay)).Cast<DbAccessWay>();
        public ObservableCollection<string> EncryptAlgorithmsNames { get; set; } = new ObservableCollection<string>();

        private DbAccessWay _selectedAccessWay = DbAccessWay.Game;
        public DbAccessWay SelectedAccessWay { get => _selectedAccessWay; set => Set(ref _selectedAccessWay, value); }

        #endregion

        #region Commands

        #region AcceptCommand
        public ICommand AcceptCommand { get; }
        private void OnAcceptCommandExecuted(object p)
        {
            try
            {
                DbAccessWay dbAccessWay = SelectedAccessWay;
                var database = _dbContext.PasswordDb.Where(pdb => pdb.Name == DatabaseName).FirstOrDefault();
                if (database == default(PasswordDb))
                {
                    Status = $"База с именем {DatabaseName} уже существует";
                }
                else
                {
                    _dbContext.PasswordDb.Add(new PasswordDb());
                }
                OnCloseWindow(new CloseWindowEventArgs(true));
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }            
        }
        private bool CanAcceptCommandExecute(object p)
        {
            return true;
        }
        #endregion

        #region CancelCommand
        public ICommand CancelCommand { get; }
        private void OnCancelCommandExecuted(object p) => OnCloseWindow(new CloseWindowEventArgs(false));
        private bool CanCancelCommandExecute(object p) => true;
        #endregion

        #endregion
    }
}
