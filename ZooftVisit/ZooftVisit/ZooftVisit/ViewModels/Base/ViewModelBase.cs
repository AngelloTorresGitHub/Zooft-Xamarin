﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ZooftVisit.ViewModels.Base
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}