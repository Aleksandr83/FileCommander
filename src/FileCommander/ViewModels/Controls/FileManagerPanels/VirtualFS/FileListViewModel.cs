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
using Avalonia.Input;

namespace FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;


public class FileListViewModel : ViewModelBase
{
    const string __DBL_CLICK_FILE_LST_EVENT = EventNames.__DBL_CLICK_FILE_LST_EVENT;
    const string __UPDATE_STORAGE_PATH_EVENT = EventNames.__UPDATE_STORAGE_PATH_EVENT;
    const string __UPDATE_FILEREC_EVENT = EventNames.__UPDATE_FILEREC_EVENT;
    const string __SET_FOCUS_FILELIST_EVENT = EventNames.__SET_FOCUS_FILELIST_EVENT;


    public FileListViewModel()
    {
        EventManager?.Registred(__SET_FOCUS_FILELIST_EVENT);
        EventManager?.Registred(__DBL_CLICK_FILE_LST_EVENT, OnDoubleClick);
        EventManager?.Registred(__UPDATE_FILEREC_EVENT, OnUpdateFileRecordsTable);
        EventManager?.Registred(__UPDATE_STORAGE_PATH_EVENT, OnUpdateFileRecordsTable);
    }

    void Clear()
    {
        if (_Items?.Count > 0) _Items?.Clear();
    }

    async Task UpdateItems()
    {
        Clear();

        await Task.Delay(1);

        if (StorageService == null)
        {
            OnAfterApdateItems();
            return;
        }

        var currentForlderId = StorageService.GetCurrentPath().GetCurrentFolderId();
        var items = (IList<FileRecord>)StorageService.GetFileTable().GetAllByParentId(currentForlderId);

        if (!StorageService.GetCurrentPath().IsRootDirectory())
            _Items?.Add(new FolderLevelUpView());

        if (items == null || items?.Count == 0)
        {
            EventManager?.RaiseEvent(__SET_FOCUS_FILELIST_EVENT, this, new EventManagerArgs());
            return;
        }

        if (items != null)
        {
            foreach (var item in items)
            {
                if (item.IsDeleted != 0) continue;
                if (item.IsDirectory != 0)
                    _Items?.Add(new FolderView(item));
            }

            foreach (var item in items)
            {
                if (item.IsDeleted != 0) continue;
                if (item.IsDirectory == 0)
                    _Items?.Add(new FileView(item));
            }
        }

        OnAfterApdateItems();
    }

    void OnUpdateFileRecordsTable(object sender, EventArgs e)
    {
        //Dispatcher.UIThread.Post(() => UpdateItems(), DispatcherPriority.Background); 
        Dispatcher.UIThread.InvokeAsync(() => UpdateItems(), DispatcherPriority.Background);
    }

    void OnAfterApdateItems()
    {
        EventManager?.RaiseEvent(__SET_FOCUS_FILELIST_EVENT, this, new EventManagerArgs());
    }

    void OnDoubleClick(object sender, EventArgs e)
    {
        if (sender.GetType() == GetType()) return;
        SelectCommand();
    }


    internal void SelectCommand()
    {
        if (_SelectedPlace == null) return;

        if (_SelectedPlace is FolderLevelUpView)
            StorageService?.GetCurrentPath().RemoveLast();

        var selectedItem = _SelectedPlace.GetValue();
        var selectedId = selectedItem.Id;
        if (selectedItem.IsDirectory != 0)
            StorageService?.GetCurrentPath().Set(selectedId);
    }

    internal void CreateFolderCommand()
    {
        BasicServices.GetCommandManagerService()?
            .ExecuteCommandById(CommandsId.__CREATE_VIRTUAL_FOLDER);
    }

    internal void CreateFileCommand()
    {
        BasicServices.GetCommandManagerService()?
            .ExecuteCommandById(CommandsId.__CREATE_VIRTUAL_FILE);
    }


    #region Properties

    public ObservableCollection<IFsItem> Items => _Items;

    public IFsItem? SelectedPlace
    {
        get => _SelectedPlace;
        set
        {
            _SelectedPlace = value;
            OnPropertyChanged("SelectedPlace");
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


    private IFsItem? _SelectedPlace = null;
    private ObservableCollection<IFsItem> _Items = new();

    private IEventManagerService?   _EventManager;
    private IVirtualStorageService? _StorageService;

}