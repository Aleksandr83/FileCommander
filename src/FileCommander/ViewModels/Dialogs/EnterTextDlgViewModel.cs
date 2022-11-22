using Avalonia;

namespace FileCommander.ViewModels
{
    public class EnterTextDlgViewModel  : ViewModelBase
    {

        public EnterTextDlgViewModel() : base()
        {
            Height = (IsWindowsOS) ? 22 : 40;
        }


        #region Properties

        public string Title
        {
            get => _Title; 
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Text
        {
            get => _Text; 
            set
            {
                _Text = value;
                OnPropertyChanged("Text");
            }
        }
        
        public string Watermark
        {
            get => _Watermark; 
            set
            {
                _Watermark = value;
                OnPropertyChanged("Watermark");
            }
        }

        public double Height
        {
            get => _Height;
            set
            {
                _Height = value;
                OnPropertyChanged("Height");
            }
        }

        #endregion Properties
        

        private string _Text = "";
        private string _Watermark = "";      
        private string _Title = "";
        
        private double _Height;
    }
}