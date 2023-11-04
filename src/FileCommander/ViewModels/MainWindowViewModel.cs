namespace FileCommander.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private const int __MIN_COPYRIGHT_YEAR = 2023;
    public string Greeting => "Welcome to Avalonia!";
    public string CopyrightYear => (DateTime.Now.Year > __MIN_COPYRIGHT_YEAR) ?DateTime.Now.Year.ToString(): __MIN_COPYRIGHT_YEAR.ToString();
}
