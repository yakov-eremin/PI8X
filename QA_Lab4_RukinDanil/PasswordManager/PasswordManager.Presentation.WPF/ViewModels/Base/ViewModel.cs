﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Markup;

namespace PasswordManager.Presentation.WPF.ViewModels.Base
{
    public class ViewModel : MarkupExtension, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public override object ProvideValue(IServiceProvider serviceProvider) => this;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
