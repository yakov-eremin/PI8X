﻿using PasswordManager.Presentation.WPF.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PasswordManager.Presentation.WPF.Infrastructure.Commands
{
    public class CloseWindowCommand : Command
    {
        protected override bool CanExecute(object parameter) => (parameter as Window ?? App.FocusedWindow ?? App.ActivedWindow) != null;

        protected override void Execute(object parameter) => (parameter as Window ?? App.FocusedWindow ?? App.ActivedWindow)?.Close();
    }
}
