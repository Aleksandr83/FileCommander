using VirtualFS;
using System.Collections.ObjectModel;
using FileCommander.Services;
using alg.Types;
using alg.Helpers;
using System;
using FileCommander.Views.Dialogs;
using System.Threading.Tasks;

namespace FileCommander.ViewModels
{

public class DeviceFsViewModel : ViewModelBase
{   

    const string __UPDATE_STORAGE_PATH_EVENT = EventNames.__UPDATE_STORAGE_PATH_EVENT;

    string?                        _Path; 
    ObservableCollection<IFsItem> _Items = new ObservableCollection<IFsItem>();
      
    #region EventManager
    IEventManagerService?       _EventManager;
    IEventManagerService EventManager
    {
        get
        {
            if (_EventManager == null)
                _EventManager   = BasicServices.GetEventManagerService(); 
            return _EventManager; 
        }
    }
    #endregion EventManager
    #region StorageService
    IVirtualStorageService? _StorageService;        
    IVirtualStorageService  StorageService
    {
        get
        {
            if (_StorageService == null)
                _StorageService = FileCommanderServices.GetStorageService(); 
            return _StorageService;
        }
    }
    #endregion StorageService
    

    
    public string Path
    {
        get { return _Path ?? String.Empty; }
        set
        {
            _Path = value;
            OnPropertyChanged("Path");
        }
    }


    public ObservableCollection<IFsItem> Items => _Items;

    public DeviceFsViewModel()
    {       
        EventManager?.Registred(__UPDATE_STORAGE_PATH_EVENT, OnUpdatePath);      
    }    

    public void NewStorage()
    {        
        BasicServices.GetCommandManagerService()
            .ExecuteCommandById(CommandsId.__CREATE_VIRTUAL_STORAGE);
    }

    public void LoadStorage()
    {       
        BasicServices.GetCommandManagerService()
            .ExecuteCommandById(CommandsId.__LOAD_VIRTUAL_STORAGE);
    }

    public void SaveStorage()
    {        
        BasicServices.GetCommandManagerService()
            .ExecuteCommandById(CommandsId.__SAVE_VIRTUAL_STORAGE);
    }

    public void NewFile()
    {
        BasicServices.GetCommandManagerService()
            .ExecuteCommandById(CommandsId.__CREATE_VIRTUAL_FILE);
    }

    public void NewFolder()
    {        
        BasicServices.GetCommandManagerService()
            .ExecuteCommandById(CommandsId.__CREATE_VIRTUAL_FOLDER);
    }         
   
    void OnUpdatePath(object sender, EventArgs e)
    {        
        Path = StorageService.GetCurrentPath().ToString();
    }

}


}