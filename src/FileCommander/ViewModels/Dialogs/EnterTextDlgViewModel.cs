using Avalonia;

namespace FileCommander.ViewModels
{
    public class EnterTextDlgViewModel  : ViewModelBase
    {           

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
       
        public EnterTextDlgViewModel() : base()
        {            
            Height = (IsWindowsOS)? 22 : 40;  
        }       

        string _Text = "";
        string _Watermark = "";      
        string _Title = "";
        
        double _Height;
    }
}