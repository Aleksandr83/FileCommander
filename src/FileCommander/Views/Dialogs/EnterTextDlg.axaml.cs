using System;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using FileCommander.ViewModels;

namespace FileCommander.Views.Dialogs;

public partial class EnterTextDlg : Window
{               
             
    public EnterTextDlg()
    {          
        InitializeComponent();            
       
        DataContext = _ViewModel;
    }

    public void Wait()
    {
        _ResetEvent.WaitOne();
        _ResetEvent.Close();
    }

    private void TextInputElement_KeyPressUp(object sender, KeyEventArgs e) 
    {
        if (e.Key == Key.Enter)
        {
            DialogResult = _ViewModel.Text;               
            Close();
        }
        else if (e.Key == Key.Escape)
        {
            DialogResult = "";           
            Close();
        }
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
                  
        _ResetEvent.Set();
    }

    #region Properties

    public string DialogResult { get; protected set; } = "";

    public new String Title
    {
        get => GetValue(TitleProperty);
        set
        {
            SetValue(TitleProperty, value);
            _ViewModel.Title = value;
        }
    }
    public string Watermark
    {
        get => _ViewModel.Watermark; 
        set => _ViewModel.Watermark = value; 
    }

    #endregion Properties

    private ManualResetEvent      _ResetEvent = new (false);
    private EnterTextDlgViewModel _ViewModel  = new ();

}