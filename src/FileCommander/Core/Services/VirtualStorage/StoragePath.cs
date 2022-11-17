using System;
using System.Collections.Specialized;
using alg.Helpers;
using FileCommander.Services;

namespace VirtualFS
{
    public class StoragePath : VirtualFS.Path
    {
        const string __UPDATE_STORAGE_PATH_EVENT = EventNames.__UPDATE_STORAGE_PATH_EVENT;
 
        UInt32 _CurrentFolderId = 0;

        #region EventManager
        IEventManagerService?       _EventManager;
        IEventManagerService? EventManager
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
        IVirtualStorageService? StorageService
        {
            get
            {
                if (_StorageService == null)
                    _StorageService = FileCommanderServices.GetStorageService(); 
                return _StorageService;
            }
        }
        #endregion StorageService
        
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

        protected override void OnPathChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            base.OnPathChanged(sender, e);

            EventManager?.RaiseEvent(__UPDATE_STORAGE_PATH_EVENT,this, new EventManagerArgs());            
        }

        public virtual void Clear()
        {
            _CurrentFolderId = StorageService.GetBootRecord().GetRootDirectoryId();
            base.Clear();
        }

        public bool IsRootDirectory()
        {
            return (StorageService.GetBootRecord().GetRootDirectoryId() == _CurrentFolderId);
        }

        public void RemoveLast()
        {
            base.RemoveLast();
            dynamic? lastItem = Last();

            _CurrentFolderId = lastItem?.Id ?? StorageService?.GetBootRecord()
                                                    .GetRootDirectoryId();
        }

    }
}