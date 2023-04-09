using Avalonia.Controls;
using FileCommander.ViewModels.Controls.FileManagerPanels.FS;

namespace FileCommander.Views;

public partial class FsView : UserControl
{
    public FsView()
    {
        InitializeComponent();

        DataContext = _ViewModel;
    }

    private FsViewModel _ViewModel = new();
}
