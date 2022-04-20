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
        public event EventHandler<CloseWindowEventArgs> CloseWindow;
        protected virtual void OnCloseWindow(CloseWindowEventArgs eventArgs) => CloseWindow?.Invoke(this, eventArgs);
    }

    public class CloseWindowEventArgs : EventArgs
    {
        public CloseWindowEventArgs(bool dialogResult)
        {
            DialogResult = dialogResult;
        }
        public bool DialogResult { get; set; }
    }
}
