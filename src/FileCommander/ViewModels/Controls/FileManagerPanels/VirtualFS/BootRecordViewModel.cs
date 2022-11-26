using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Agl.Helpers;
using Avalonia.Threading;
using FileCommander.Models.FileManagerPanels.VirtualFS;
using FileCommander.Services;

namespace FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;


public class BootRecordViewMode : ViewModelBase
{
    const string __UPDATE_BOOTREC_EVENT = EventNames.__UPDATE_BOOTREC_EVENT;

    
    public BootRecordViewMode()
    {
        EventManager?.Registred(__UPDATE_BOOTREC_EVENT, OnUpdateBootRecord);
    }    

    async Task Update()
    {
        dynamic? bootRecord = StorageService?.GetBootRecord()?.GetValue();

        LogService?.LogBootRecord("Task update view BootRecord", bootRecord);

        RecordSize = bootRecord?.RecordSize;
        Version = bootRecord?.Version;
        RootDirectoryId = bootRecord?.RootDirectoryId;
        OffsetFileTable = bootRecord?.OffsetFileTable;
        CountRecordsInTable = bootRecord?.CountRecordsInTable;
        Crc = bootRecord?.Crc;

        var calcCrc = StorageService?.GetBootRecord()?.BootRecordCalcCrc() ?? 0;
        IsCorrectCrc = Crc == calcCrc ? true : false;

        await Task.Delay(1);
    }

    void OnUpdateBootRecord(object sender, EventArgs e)
    {
        //Dispatcher.UIThread.Post(() => Update(), DispatcherPriority.Background); 
        Dispatcher.UIThread.InvokeAsync(() => Update(), DispatcherPriority.Background);
    }

    #region Properties

    public ushort RecordSize
    {
        get => _BootRecord.RecordSize;
        set
        {
            _BootRecord.RecordSize = value;
            OnPropertyChanged("RecordSize");
        }
    }

    public byte Version
    {
        get => _BootRecord.Version;
        set
        {
            _BootRecord.Version = value;
            OnPropertyChanged("Version");
        }
    }

    public byte IsSupportCompression
    {
        get => _BootRecord.IsSupportCompression; 
        set
        {
            _BootRecord.IsSupportCompression = value;
            OnPropertyChanged("IsSupportCompression");
        }
    }

    public byte IsSupportEncription
    {
        get => _BootRecord.IsSupportEncription; 
        set
        {
            _BootRecord.IsSupportEncription = value;
            OnPropertyChanged("IsSupportEncription");
        }
    }

    public uint RootDirectoryId
    {
        get => _BootRecord.RootDirectoryId; 
        set
        {
            _BootRecord.RootDirectoryId = value;
            OnPropertyChanged("RootDirectoryId");
        }
    }
    public uint OffsetFileTable
    {
        get => _BootRecord.OffsetFileTable; 
        set
        {
            _BootRecord.OffsetFileTable = value;
            OnPropertyChanged("OffsetFileTable");
        }
    }
    public uint CountRecordsInTable
    {
        get => _BootRecord.CountRecordsInTable; 
        set
        {
            _BootRecord.CountRecordsInTable = value;
            OnPropertyChanged("CountRecordsInTable");
        }
    }

    public byte Crc
    {
        get => _BootRecord.Crc; 
        set
        {
            _BootRecord.Crc = value;
            OnPropertyChanged("Crc");
        }
    }


    public bool IsCorrectCrc
    {
        get => _IsCorrectCrc; 
        set
        {
            _IsCorrectCrc = value;
            OnPropertyChanged("IsCorrectCrc");
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

    IFileCommanderLogService? LogService
    {
        get
        {
            if (_LogService == null)
                _LogService = FileCommanderServices.GetLogService();
            return _LogService;
        }
    }

    #endregion Properties


    private BootRecord  _BootRecord;
    private bool        _IsCorrectCrc;

    private IEventManagerService?       _EventManager;
    private IVirtualStorageService?     _StorageService;
    private IFileCommanderLogService?   _LogService;


}