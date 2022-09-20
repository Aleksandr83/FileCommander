using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using alg.Helpers;
using alg.Types;
using Avalonia.Threading;
using FileCommander.Services;
using VirtualFS;

namespace FileCommander.ViewModels
{   


public class BootRecordViewMode : ViewModelBase
{
    const string __UPDATE_BOOTREC_EVENT = EventNames.__UPDATE_BOOTREC_EVENT;

    BootRecord              _BootRecord;  
   

    bool _IsCorrectCrc;

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
    #region LogService
    IFileCommanderLogService   _LogService;

    IFileCommanderLogService LogService 
    { 
        get
        {
            if (_LogService == null)
                _LogService = FileCommanderServices.GetLogService();
            return _LogService;
        }
     }
    #endregion LogService


    public UInt16 RecordSize
    {
        get { return _BootRecord.RecordSize; }
        set
        {
            _BootRecord.RecordSize = value;
            OnPropertyChanged("RecordSize");
        }
    }

    public byte Version
    {
        get {return _BootRecord.Version; }
        set
        {
            _BootRecord.Version = value;
            OnPropertyChanged("Version");
        }
    }

    public byte IsSupportCompression
    {
        get { return _BootRecord.IsSupportCompression; }
        set
        {
            _BootRecord.IsSupportCompression = value;
            OnPropertyChanged("IsSupportCompression");
        }
    }

    public byte IsSupportEncription
    {
        get { return _BootRecord.IsSupportEncription; }
        set
        {
            _BootRecord.IsSupportEncription = value;
            OnPropertyChanged("IsSupportEncription");
        }
    }

    public UInt32  RootDirectoryId
    {
        get {return _BootRecord.RootDirectoryId; }
        set
        {
            _BootRecord.RootDirectoryId = value;
            OnPropertyChanged("RootDirectoryId"); 
        }
    }

    public UInt32 OffsetFileTable
    {
        get {return _BootRecord.OffsetFileTable; }
        set
        {
            _BootRecord.OffsetFileTable = value;
            OnPropertyChanged("OffsetFileTable");
        }
    }

    public UInt32 CountRecordsInTable
    {
        get {return _BootRecord.CountRecordsInTable; }
        set
        {
            _BootRecord.CountRecordsInTable = value;
            OnPropertyChanged("CountRecordsInTable");
        }
    }

    // public UInt32 OffsetData
    // {
    //     get {return _BootRecord.OffsetData;}
    //     set
    //     {
    //         _BootRecord.OffsetData = value;
    //         OnPropertyChanged("OffsetData");
    //     }
    // }

    public byte Crc
    {
        get {return _BootRecord.Crc; }
        set
        {
            _BootRecord.Crc = value;
            OnPropertyChanged("Crc");
        }
    }


    public bool IsCorrectCrc
    {
        get {return _IsCorrectCrc; }
        set
        {
            _IsCorrectCrc = value;
            OnPropertyChanged("IsCorrectCrc");
        }
    }

    public BootRecordViewMode()
    {       
        EventManager?.Registred(__UPDATE_BOOTREC_EVENT,OnUpdateBootRecord);        
    }    

    void OnUpdateBootRecord(object sender, EventArgs e)
    {        
        Dispatcher.UIThread.Post(() => Update(), DispatcherPriority.Background);        
    }

    async Task Update()
    {
        dynamic bootRecord = StorageService.GetBootRecord().GetValue(); 
        
        LogService.LogBootRecord("Task update view BootRecord", bootRecord); 

        RecordSize          = bootRecord.RecordSize;
        Version             = bootRecord.Version;
        RootDirectoryId     = bootRecord.RootDirectoryId;
        OffsetFileTable     = bootRecord.OffsetFileTable;
        CountRecordsInTable = bootRecord.CountRecordsInTable;    
        Crc                 = bootRecord.Crc; 

        var calcCrc  = StorageService.GetBootRecord().BootRecordCalcCrc();
        IsCorrectCrc = (Crc == calcCrc)? true: false;     

        await Task.Delay(1);  
    }

}


}