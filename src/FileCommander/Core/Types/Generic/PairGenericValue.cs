using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Agl.Types.Generic;

public abstract class PairGenericValue<TNewValue,TValue> : GenericValue<TValue> 
{
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

    protected virtual void OnChangeNewValue(TNewValue? value)
    {

    }      


    public bool IsInit => _IsInit;
    public TNewValue? NewValue
    {
        get => _NewValue;
        set
        {
            this.RaiseAndSetIfChanged(ref _NewValue, value);
            OnPropertyChanged("NewValue");
        }
    }



    private TNewValue? _NewValue = default(TNewValue);
    private bool       _IsInit   = false;
}