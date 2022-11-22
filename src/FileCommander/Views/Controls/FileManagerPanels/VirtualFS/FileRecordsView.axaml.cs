using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;

namespace FileCommander.Views;

public partial class FileRecordsView : UserControl
{    
    
    public FileRecordsView()
    {
        InitializeComponent();

        DataContext = _ViewModel;
    }

    private FileRecordsViewModel _ViewModel = new ();

}