using VirtualFS;
using System.Collections.ObjectModel;
using FileCommander.Services;
using Agl.Helpers;


namespace FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;


public class DeviceFsViewModel : ViewModelBase
{

    const string __UPDATE_STORAGE_PATH_EVENT = EventNames.__UPDATE_STORAGE_PATH_EVENT;


    public DeviceFsViewModel()
    {
        EventManager?.Registred(__UPDATE_STORAGE_PATH_EVENT, OnUpdatePath);
    }

    public void NewStorage()
    {
        BasicServices.GetCommandManagerService()?
            .ExecuteCommandById(CommandsId.__CREATE_VIRTUAL_STORAGE);
    }

    public void LoadStorage()
    {
        BasicServices.GetCommandManagerService()?
            .ExecuteCommandById(CommandsId.__LOAD_VIRTUAL_STORAGE);
    }

    public void SaveStorage()
    {
        BasicServices.GetCommandManagerService()?
            .ExecuteCommandById(CommandsId.__SAVE_VIRTUAL_STORAGE);
    }

    public void NewFile()
    {
        BasicServices.GetCommandManagerService()?
            .ExecuteCommandById(CommandsId.__CREATE_VIRTUAL_FILE);
    }

    public void NewFolder()
    {
        BasicServices.GetCommandManagerService()?
            .ExecuteCommandById(CommandsId.__CREATE_VIRTUAL_FOLDER);
    }

    void OnUpdatePath(object sender, EventArgs e)
    {
        Path = StorageService?.GetCurrentPath().ToString() ?? string.Empty;
    }

    #region Properties

    public ObservableCollection<IFsItem> Items => _Items;

    public string Path
    {
        get { return _Path ?? string.Empty; }
        set
        {
            _Path = value;
            OnPropertyChanged("Path");
        }
    }


    IEventManagerService? EventManager
    {
        get
        {
            if (_EventManager == null)
                _EventManager = BasicServices.GetEventManagerService();
            return _EventManager;
        }
    }

    IVirtualStorageService? StorageService
    {
        get
        {
            if (_StorageService == null)
                _StorageService = FileCommanderServices.GetStorageService();
            return _StorageService;
        }
    }

    #endregion Properties


    private string? _Path;
    private ObservableCollection<IFsItem> _Items = new();

    private IEventManagerService?   _EventManager;
    private IVirtualStorageService? _StorageService;

}

