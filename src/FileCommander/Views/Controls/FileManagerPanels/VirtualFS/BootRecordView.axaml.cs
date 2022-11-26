using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;

namespace FileCommander.Views.Panels.VirtualFS;

public partial class BootRecordView : UserControl
{
   
    public BootRecordView()
    {
        InitializeComponent();

        DataContext = _ViewModel;
    }

    private BootRecordViewMode _ViewModel = new ();

}