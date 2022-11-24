using System;
using System.Collections.Specialized;
using Agl.Helpers;
using FileCommander.Services;

namespace VirtualFS;

public class StoragePath : VirtualFS.Path
{
    const string __UPDATE_STORAGE_PATH_EVENT = EventNames.__UPDATE_STORAGE_PATH_EVENT;

    public StoragePath()
    {           
        EventManager?.Registred (__UPDATE_STORAGE_PATH_EVENT);
        EventManager?.RaiseEvent(__UPDATE_STORAGE_PATH_EVENT,this, new EventManagerArgs()); 
    }

    public UInt32 GetCurrentFolderId() => _CurrentFolderId;

    public void Set(UInt32 folderId)
    {
        string folderName;
        var itemsInCurrentDir = StorageService?.GetFileTable()
                                    .GetAllByParentId(_CurrentFolderId);
        if (itemsInCurrentDir == null) return;

        foreach (var item in itemsInCurrentDir)
        {
            if (item.Id == folderId)
            {
                folderName = TextConvertorHelper.AsciiBytesToUtfString(item.Name);
                base.Add(item.Id, item.ParentId, folderName);

                _CurrentFolderId = folderId;
                return;
            }
        }
    }

    protected override void OnPathChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        base.OnPathChanged(sender, e);

        EventManager?.RaiseEvent(__UPDATE_STORAGE_PATH_EVENT,this, new EventManagerArgs());            
    }

    public override void Clear()
    {
        if (StorageService != null)
            _CurrentFolderId = StorageService.GetBootRecord().GetRootDirectoryId();
        base.Clear();
    }

    public bool IsRootDirectory()
    {
        return ((StorageService?.GetBootRecord()?.GetRootDirectoryId()??uint.MaxValue) == _CurrentFolderId);
    }

    public override void RemoveLast()
    {
        base.RemoveLast();
        dynamic? lastItem = Last();

        _CurrentFolderId = lastItem?.Id ?? StorageService?.GetBootRecord()
                                                .GetRootDirectoryId();
    }


    #region Properties
    
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


    private UInt32 _CurrentFolderId = 0;

    private IEventManagerService?   _EventManager;
    private IVirtualStorageService? _StorageService;

}