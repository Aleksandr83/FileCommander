namespace FileCommander.ViewModels
{
    public class EnterTextDlgViewModel  : ViewModelBase
    {
        string _Text = "";
        string _Watermark = "";

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