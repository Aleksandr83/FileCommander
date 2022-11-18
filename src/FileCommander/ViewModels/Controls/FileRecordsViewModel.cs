using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using alg.Helpers;
using Avalonia.Threading;
using FileCommander.Services;
using VirtualFS;

namespace FileCommander.ViewModels
{
    public class FileRecordsViewModel : ViewModelBase
    {
        const string __UPDATE_FILEREC_EVENT = EventNames.__UPDATE_FILEREC_EVENT;
                
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

        ObservableCollection<FileRecordItemViewModel>? _Items = new ObservableCollection<FileRecordItemViewModel>();

        public ObservableCollection<FileRecordItemViewModel>? Items
        {
            get { return _Items; }
            private set
            {
                _Items = value;
                OnPropertyChanged("Items");
            }
        }

        public FileRecordsViewModel()
        {          
            EventManager?.Registred(__UPDATE_FILEREC_EVENT, OnUpdateFileRecordsTable);
        }

        void OnUpdateFileRecordsTable(object sender, EventArgs e)
        {                
            //Dispatcher.UIThread.Post(() => UpdateItems(), DispatcherPriority.Background); 
            Dispatcher.UIThread.InvokeAsync(() => UpdateItems(), DispatcherPriority.Background); 
        }

        async Task UpdateItems()
        {
            Clear();
            await Task.Delay(1);

            var items = StorageService?.GetFileTable().GetFileRecords();
            
            if (items == null || items.Count == 0) return;

            foreach (var item in items)
            {
                _Items?.Add(new FileRecordItemViewModel(item));
            }            
        }

        void Clear()
        {
            if (_Items?.Count > 0) _Items?.Clear();
        }

    }
}