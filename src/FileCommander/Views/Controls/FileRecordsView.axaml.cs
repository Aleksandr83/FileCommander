using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels;

namespace FileCommander.Views
{
    public partial class FileRecordsView : UserControl
    {
        FileRecordsViewModel _ViewModel = new FileRecordsViewModel();
        
        public FileRecordsView()
        {
            InitializeComponent();

            DataContext = _ViewModel;
        }
    }
}