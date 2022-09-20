using System;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels;

namespace FileCommander.Views.Dialogs
{
    public partial class EnterTextDlg : Window
    {
        EnterTextDlgViewModel _ViewModel = new EnterTextDlgViewModel();

        public string DialogResult { get; set; } = "";
        public string Watermark    
        { 
            get { return _ViewModel.Watermark;  }
            set { _ViewModel.Watermark = value; }
        }
       
        ManualResetEvent _ResetEvent = new ManualResetEvent(false);
        
        public EnterTextDlg()
        {          
            InitializeComponent(); 
            
            DataContext = _ViewModel;
        }

        public void Wait()
        {
            _ResetEvent.WaitOne();
            _ResetEvent.Close();
        }

        private void TextInputElement_KeyPressUp(object sender, KeyEventArgs e) 
        {
            if (e.Key == Key.Enter)
            {
                DialogResult = _ViewModel.Text;               
                Close();
            }
            else if (e.Key == Key.Escape)
            {
                DialogResult = "";           
                Close();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
                      
            _ResetEvent.Set();
        }
    }
}