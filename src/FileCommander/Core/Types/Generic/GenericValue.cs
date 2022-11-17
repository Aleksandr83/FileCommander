using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace Types.Generic
{
    public abstract class GenericValue<TValue> : ReactiveObject, INotifyPropertyChanged
    {
        #region Value
        TValue    _Value;

        public TValue Value
        {
            get => _Value;
            set 
            {
                this.RaiseAndSetIfChanged(ref _Value,value);
                OnPropertyChanged("Value");
            }
        }
        #endregion Value
       
        public GenericValue(TValue value)
        {
            RegistredValueChanged();           
        }

        protected virtual void OnChangeValue(TValue value)
        {

        }
        
        private void RegistredValueChanged()
        {
            this
                .WhenAnyValue(vm => vm.Value)
                .Skip(1)
                .Do(   
                    value=>
                    { 
                        OnChangeValue(value);
                    }
                )
                .Subscribe();
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

         #endregion PropertyChanged

    }

}