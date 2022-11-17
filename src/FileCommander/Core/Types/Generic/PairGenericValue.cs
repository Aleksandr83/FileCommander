using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Types.Generic
{
    public abstract class PairGenericValue<TNewValue,TValue> : GenericValue<TValue> 
    {
        
        #region NewValue
        TNewValue _NewValue;    

        public TNewValue NewValue
        {
            get => _NewValue;
            set 
            {
                this.RaiseAndSetIfChanged(ref _NewValue,value);
                OnPropertyChanged("NewValue");
            }
        }
        #endregion NewValue 
       
        #region IsInit
        bool _IsInit = false;
        public bool IsInit => _IsInit;
        #endregion IsInit

        public PairGenericValue(TValue value, TNewValue newValue): base(value)
        {           
            RegistredNewValueChanged();   

            Init(value, newValue);    

            SetInit();
        }

        protected virtual void Init(TValue value, TNewValue newValue)
        {
            Value    = value;
            NewValue = newValue;
        }

        private  void SetInit() =>_IsInit = true;

        protected virtual void OnChangeNewValue(TNewValue value)
        {

        }       

        private void RegistredNewValueChanged()
        {
            this
                .WhenAnyValue(vm => vm.NewValue)
                .Skip(1)
                .Do(   
                    newvalue =>
                    { 
                        OnChangeNewValue(newvalue);
                    }
                )
                .Subscribe();
        }

       


    }
}