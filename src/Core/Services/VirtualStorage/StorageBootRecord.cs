using System;
using System.Threading.Tasks;
using alg.Helpers;
using alg.Types.Generic;
using Avalonia.Threading;
using FileCommander.Services;
using Mimica.Types.CRC;
using Serilog;

namespace VirtualFS
{
    public class StorageBootRecord
    {
        const string __UPDATE_BOOTREC_EVENT = EventNames.__UPDATE_BOOTREC_EVENT;
        const string __UPDATE_FILEREC_EVENT = EventNames.__UPDATE_FILEREC_EVENT;

        BootRecord  _BootRecord  = default(BootRecord);
        bool        _IsWasErrors = false;   
                  

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

        internal BootRecord GetValue()           => _BootRecord; 
        internal bool       IsWasErrors()        => _IsWasErrors;
        internal UInt32     GetRootDirectoryId() => _BootRecord.RootDirectoryId;       

        public StorageBootRecord()
        {          
            EventManager?.Registred(__UPDATE_BOOTREC_EVENT);
            EventManager?.Registred(__UPDATE_FILEREC_EVENT, OnUpdateFileRecordsTable);
        
            Init();
        }

        void Init()
        {
            CreateNewBootRecord();            
        }        

        public async void LoadBootRecord(Byte[] bytes, UInt32 length)
        {         
            var bootRecord = ArrayType.ToStruct<BootRecord>(bytes, length);        

            _BootRecord = bootRecord;

            if (_BootRecord.Crc != BootRecordCalcCrc())
            {
                _IsWasErrors = true;               
            }

            LogService.LogBootRecord("Load BootRecord",_BootRecord);
            
            EventManager?.RaiseEvent(__UPDATE_BOOTREC_EVENT,this, new EventManagerArgs());               
        }      

        async void CreateNewBootRecord()
        {           
            BootRecord bootRecord = default(BootRecord);

            unsafe
            {
                byte* ptr = (byte*)&bootRecord;
                uint  len = (uint)sizeof(BootRecord);
                                
                while (len-- > 0)
                {
                    *(ptr+len) = 0; 
                }
            }                       

            bootRecord.RecordSize = (UInt16)Struct.GetSize<BootRecord>();
            bootRecord.Version    = 1;      
            bootRecord.OffsetFileTable = bootRecord.RecordSize;

            _BootRecord = bootRecord; 
            _BootRecord.Crc = BootRecordCalcCrc();  

            EventManager?.RaiseEvent(__UPDATE_BOOTREC_EVENT,this, new EventManagerArgs());                         
        }     
        
        public byte BootRecordCalcCrc()
        {
            Crc8 crc8   = new Crc8();
            byte result = 0;
            
            UInt32 size  = Struct.GetSize<BootRecord>();
            Byte[] bytes = Struct.ToArray<BootRecord>(_BootRecord);

            crc8.CalcArrayCrc(ref result, bytes, 0, size-1);           

            return result;
        }       

        async void OnUpdateFileRecordsTable(object sender, EventArgs e)
        {                  
            if (_IsWasErrors) return;

            UInt32? countRecords = (UInt32)StorageService.GetFileTable().Count;

            if (countRecords == null) return;

            if (_BootRecord.CountRecordsInTable == countRecords)
                return;

            _BootRecord.CountRecordsInTable = countRecords ?? 0;
            _BootRecord.Crc = BootRecordCalcCrc(); 

            EventManager?.RaiseEvent(__UPDATE_BOOTREC_EVENT,this, new EventManagerArgs());          
           
        }

    }
}