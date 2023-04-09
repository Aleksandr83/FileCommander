using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;
using VirtualFS;

namespace FileCommander.Views.Panels.VirtualFS;

public partial class FileListView : UserControl
{   

    public FileListView()
    {
        InitializeComponent();

        DataContext = _ViewModel;          
    }

    private FileListViewModel _ViewModel = new ();

}