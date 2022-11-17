using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels;

namespace FileCommander.Views
{
    public partial class BootRecordView : UserControl
    {
        BootRecordViewMode _ViewModel = new BootRecordViewMode();

        public BootRecordView()
        {
            InitializeComponent();

            DataContext = _ViewModel;
        }
    }
}