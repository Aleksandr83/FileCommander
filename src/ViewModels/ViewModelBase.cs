using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace FileCommander.ViewModels
{
    public class ViewModelBase : ReactiveObject, INotifyPropertyChanged
    {
        #region PropertyChanged
        public new event PropertyChangedEventHandler? PropertyChanged = new PropertyChangedEventHandler((x,y)=>{});

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion PropertyChanged

    }

    
}
