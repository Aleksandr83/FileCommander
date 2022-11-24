using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Agl.Helpers;
using Avalonia.Threading;
using FileCommander.Services;
using VirtualFS;

namespace FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;

public class FileRecordsViewModel : ViewModelBase
{
    const string __UPDATE_FILEREC_EVENT = EventNames.__UPDATE_FILEREC_EVENT;


    public FileRecordsViewModel()
    {
        EventManager?.Registred(__UPDATE_FILEREC_EVENT, OnUpdateFileRecordsTable);
    }

    void Clear()
    {
        if (_Items?.Count > 0) _Items?.Clear();
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


    void OnUpdateFileRecordsTable(object sender, EventArgs e)
    {
        //Dispatcher.UIThread.Post(() => UpdateItems(), DispatcherPriority.Background); 
        Dispatcher.UIThread.InvokeAsync(() => UpdateItems(), DispatcherPriority.Background);
    }


    #region Properties

    public ObservableCollection<FileRecordItemViewModel>? Items
    {
        get => _Items;
        private set
        {
            _Items = value;
            OnPropertyChanged("Items");
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


    private ObservableCollection<FileRecordItemViewModel>? _Items = new();

    private IEventManagerService?   _EventManager;
    private IVirtualStorageService? _StorageService;

}