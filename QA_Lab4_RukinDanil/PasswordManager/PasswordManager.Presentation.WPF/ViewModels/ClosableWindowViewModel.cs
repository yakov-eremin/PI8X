using PasswordManager.Presentation.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Presentation.WPF.ViewModels
{
    public class ClosableWindowViewModel : ViewModel
    {
        public event EventHandler CloseWindow;
        protected virtual void OnCloseWindow() => CloseWindow?.Invoke(this, EventArgs.Empty);
    }
}
