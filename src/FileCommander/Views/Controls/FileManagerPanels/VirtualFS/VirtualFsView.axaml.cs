using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;

namespace FileCommander.Views;

public partial class VirtualFsView : UserControl
{
    public VirtualFsView()
    {
        InitializeComponent();
        
        DataContext = _ViewModel;
    }

    private VirtualFsViewModel _ViewModel = new ();

}