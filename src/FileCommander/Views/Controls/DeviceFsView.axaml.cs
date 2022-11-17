using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels;

namespace FileCommander.Views
{
    public partial class DeviceFsView : UserControl
    {
        DeviceFsViewModel _ViewModel = new DeviceFsViewModel();

        public DeviceFsView()
        {
            InitializeComponent();
            
            DataContext = _ViewModel;
        }
    }
}