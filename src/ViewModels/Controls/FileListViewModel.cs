using VirtualFS;
using alg.Types;
using FileCommander.Services;
using System.Collections.ObjectModel;
using alg.Helpers;
using Avalonia.Threading;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FileCommander.ViewModels
{

public class FileListViewModel  : ViewModelBase
{
    const string __UPDATE_STORAGE_PATH_EVENT    = EventNames.__UPDATE_STORAGE_PATH_EVENT;
    const string __UPDATE_FILEREC_EVENT         = EventNames.__UPDATE_FILEREC_EVENT;
    const string __SET_FOCUS_FILELIST_EVENT     = EventNames.__SET_FOCUS_FILELIST_EVENT;

    ObservableCollection<IFsItem> _Items = new ObservableCollection<IFsItem>();

    
    #region SelectedPlace
    IFsItem _SelectedPlace = null;
    public IFsItem SelectedPlace
    {
        get { return _SelectedPlace; }
        set
        {
            _SelectedPlace = value;
            OnPropertyChanged("SelectedPlace");
        }
    }
    #endregion SelectedPlace
    
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
    IVirtualStorageService?           _StorageService;        
    IVirtualStorageService StorageService
    {
        get
        {
            if (_StorageService == null)
                _StorageService = FileCommanderServices.GetStorageService(); 
            return _StorageService;
        }
    }
    #endregion StorageService

   
    public ObservableCollection<IFsItem> Items => _Items;


    public FileListViewModel()
    {
        EventManager?.Registred(__SET_FOCUS_FILELIST_EVENT); 
        EventManager?.Registred(__UPDATE_FILEREC_EVENT, OnUpdateFileRecordsTable);
        EventManager?.Registred(__UPDATE_STORAGE_PATH_EVENT , OnUpdateFileRecordsTable);
    }   

    void OnUpdateFileRecordsTable(object sender, EventArgs e)
    {                
        Dispatcher.UIThread.Post(() => UpdateItems(), DispatcherPriority.Background); 
    }

    async Task UpdateItems()
    {        
        Clear();

        await Task.Delay(1);
       
        var currentForlderId = StorageService.GetCurrentPath().GetCurrentFolderId();
        var items = (IList<FileRecord>)StorageService.GetFileTable().GetAllByParentId(currentForlderId);    
       
        if (!StorageService.GetCurrentPath().IsRootDirectory())
            _Items?.Add(new FolderLevelUpView());
        
        if (items == null || items?.Count == 0) 
        {
            EventManager?.RaiseEvent(__SET_FOCUS_FILELIST_EVENT,this, new EventManagerArgs());
            return;
        }

        foreach (var item in items)
        {            
            if (item.IsDeleted != 0) continue;
            if (item.IsDirectory != 0)
                _Items?.Add(new FolderView(item));
        }            

        EventManager?.RaiseEvent(__SET_FOCUS_FILELIST_EVENT,this, new EventManagerArgs());
    }

    void Clear()
    {
        if (_Items?.Count > 0) _Items?.Clear();
    }

    void SelectCommand(object e)
    {
        if (_SelectedPlace == null) return;

        if (_SelectedPlace is FolderLevelUpView)
            StorageService.GetCurrentPath().RemoveLast();

        var selectedItem = _SelectedPlace.GetValue();
        var selectedId   = selectedItem.Id;
        if (selectedItem.IsDirectory != 0)
            StorageService.GetCurrentPath().Set(selectedId);       
    }   

    void CreateFolderCommand(object e)
    {

    }

}


}