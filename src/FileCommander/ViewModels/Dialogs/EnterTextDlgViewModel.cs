using Avalonia;

namespace FileCommander.ViewModels
{
    public class EnterTextDlgViewModel  : ViewModelBase
    {
        string _Text = "";
        string _Watermark = "";      
        string _Title = "";

        public string Title
        {
            get {return _Title; }
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                OnPropertyChanged("Text");
            }
        }
        
        public string Watermark
        {
            get { return _Watermark; }
            set
            {
                _Watermark = value;
                OnPropertyChanged("Watermark");
            }
        }

        public EnterTextDlgViewModel()
        {
        }       

    }
}