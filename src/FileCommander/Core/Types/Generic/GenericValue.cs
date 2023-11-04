using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace Agl.Types.Generic;

public abstract class GenericValue<TValue> : ReactiveObject, INotifyPropertyChanged
{
      
    public GenericValue(TValue value)
    {
        _Value = value;
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
    public new event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion PropertyChanged

    public TValue Value
    {
        get => _Value;
        set
        {
            this.RaiseAndSetIfChanged(ref _Value, value);
            OnPropertyChanged(nameof(Value));
        }
    }

    private TValue _Value;

}