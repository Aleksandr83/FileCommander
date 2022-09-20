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
        StorageService.CreateNewStorage();
    }

    public void LoadStorage()
    {
        StorageService.LoadDefaultStorage();
    }

    public void SaveStorage()
    {
        StorageService.SaveDefaultStorage();
    }

    public async Task NewFile()
    {
        dynamic? app = Avalonia.Application.Current?.ApplicationLifetime;
        
        var dlg = new EnterTextDlg() {Title = "CreateFile", Watermark="FileName" };

        dlg.ShowDialog(app?.MainWindow);

        await Task.Run(() => dlg.Wait()); 

        string fileName = dlg.DialogResult;
        if (String.IsNullOrEmpty(fileName)) return;
    }

    public async Task NewFolder()
    {        
        dynamic? app = Avalonia.Application.Current?.ApplicationLifetime;
        
        var dlg = new EnterTextDlg() {Title = "CreateFolder", Watermark="FolderName" };

        dlg.ShowDialog(app?.MainWindow);
             
        await Task.Run(() => dlg.Wait());

        string folderName = dlg.DialogResult;
        if (String.IsNullOrEmpty(folderName)) return;

        StorageService.CreateFolder(folderName);
    }         
   
    void OnUpdatePath(object sender, EventArgs e)
    {
        Path = StorageService.GetCurrentPath().ToString();
    }

}


}