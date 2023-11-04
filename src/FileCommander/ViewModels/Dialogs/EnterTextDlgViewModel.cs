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
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Text
        {
            get => _Text; 
            set
            {
                _Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        
        public string Watermark
        {
            get => _Watermark; 
            set
            {
                _Watermark = value;
                OnPropertyChanged(nameof(Watermark));
            }
        }

        public double Height
        {
            get => _Height;
            set
            {
                _Height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        #endregion Properties
        

        private string _Text;
        private string _Watermark;      
        private string _Title;
        
        private double _Height;
    }
}