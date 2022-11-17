using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels;

namespace FileCommander.Views
{
    public partial class FileTableView : UserControl
    {
        //FileRecordsViewModel _ViewModel = new FileRecordsViewModel();
        
        public FileTableView()
        {
            InitializeComponent();

            //DataContext = _ViewModel;
        }
    }
}