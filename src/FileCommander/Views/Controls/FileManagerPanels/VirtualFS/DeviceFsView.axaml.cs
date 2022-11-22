using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;

namespace FileCommander.Views;

public partial class DeviceFsView : UserControl
{
    public DeviceFsView()
    {
        InitializeComponent();
        
        DataContext = _ViewModel;
    }

    private DeviceFsViewModel _ViewModel = new ();

}