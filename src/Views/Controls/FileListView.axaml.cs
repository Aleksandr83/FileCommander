using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels;

namespace FileCommander.Views
{
    public partial class FileListView : UserControl
    {
         FileListViewModel _ViewModel = new FileListViewModel();

        public FileListView()
        {
            InitializeComponent();

            DataContext = _ViewModel;
        }
    }
}