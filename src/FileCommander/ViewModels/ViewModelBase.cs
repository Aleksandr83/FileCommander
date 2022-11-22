using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace FileCommander.ViewModels;

public class ViewModelBase : ReactiveObject, INotifyPropertyChanged
{
    public ViewModelBase()
    {            
        var platform = Environment.OSVersion.Platform;

        IsWindowsOS = (platform  == PlatformID.Win32NT);          
    }

    #region PropertyChanged
    public new event PropertyChangedEventHandler? PropertyChanged = new PropertyChangedEventHandler((x,y)=>{});

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion PropertyChanged

    public bool IsWindowsOS
    {
        get => _IsWindowsOS;
        set
        {
            _IsWindowsOS = value;
            OnPropertyChanged("IsWindowsOS");
        }
    }

    private bool _IsWindowsOS = false; 
}


