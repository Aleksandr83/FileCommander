using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels;

namespace FileCommander.Views
{
    public partial class FileDataRecordsView : UserControl
    {
        //FileRecordsViewModel _ViewModel = new FileRecordsViewModel();
        
        public FileDataRecordsView()
        {
            InitializeComponent();

            //DataContext = _ViewModel;
        }
    }
}