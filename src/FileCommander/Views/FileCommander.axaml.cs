using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FileCommander.Views
{
    public partial class FileCommanderView : UserControl
    {        

        public FileCommanderView()
        {
            InitializeComponent();

            DataContext = this;
        }

        
    }
}