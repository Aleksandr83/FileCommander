// Copyright (c) 2021 Lukin Aleksandr
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types
{
    public class DataBindBroker<T> : INotifyPropertyChanged
    {

        #region Value
        private T _value;
        public T Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        #endregion Value

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion PropertyChanged

    }
}
