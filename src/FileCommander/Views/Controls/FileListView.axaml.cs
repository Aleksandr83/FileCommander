using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using FileCommander.ViewModels;
using VirtualFS;

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