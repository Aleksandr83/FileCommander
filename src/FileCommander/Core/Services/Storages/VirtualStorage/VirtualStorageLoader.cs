using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Agl.Helpers;
using Agl.Types.Generic;
using FileCommander.Models.FileManagerPanels.VirtualFS;
using FileCommander.Services;
using Serilog;


namespace VirtualFS;

public class VirtualStorageLoader
{        
    public VirtualStorageLoader()
    {

    }

    public async void Load(Storage storage, string fileName)
    {      
        if (EventManager != null)      
          await EventManager.WaitEmptyEventsInQueue(EventNames.__UPDATE_BOOTREC_EVENT);

        StreamReader sr = new (fileName);

        using (BinaryReader br = new BinaryReader(sr.BaseStream))
        {                
            LoadBootRecord(br, storage);  
            await LoadFileTable (br, storage);

            br.Close();
        }           
    }

    void LoadBootRecord(BinaryReader reader, Storage storage)
    {
        Byte    currentByte;
        UInt16  recordSize = 0;

        recordSize  = reader.ReadByte();
        currentByte = reader.ReadByte(); 
        recordSize |= (UInt16)(currentByte << 8);
        reader.BaseStream.Seek(0, SeekOrigin.Begin);                
        Byte[] bytes = reader.ReadBytes(recordSize);

        LogService?.Information("Load bytes for BootRecord: {@SpecialBytes}", bytes);
        
        storage.GetBootRecord().LoadBootRecord(bytes, recordSize);
    }

    async Task LoadFileTable(BinaryReader reader, Storage storage)
    {
        List<Byte> bytes;            
        BootRecord? bootTable = null;
        if (StorageService != null)
          bootTable = (BootRecord?)StorageService.GetBootRecord().GetValue();
        UInt32 offset = bootTable?.OffsetFileTable ?? 0;            
        UInt32 defaultSize  = Struct.GetSizeExt<FileRecord>();            

        if (offset < Struct.GetSizeExt<BootRecord>()) return;

        for (UInt32 i = 0; i < bootTable?.CountRecordsInTable; i++)
        {
            reader.BaseStream.Seek(offset, SeekOrigin.Begin);
            bytes = new List<byte>(reader.ReadBytes((int)defaultSize));
            
            var recInfo = ArrayType.ToStruct<TruncatedFileRecord>
                        (
                            bytes.ToArray(), 
                            Struct.GetSize<TruncatedFileRecord>()
                        );
            var  factNameLength = recInfo.RecordSize - defaultSize;
            
            while(factNameLength-- > 0)                
                bytes.Add(reader.ReadByte());

            LogService?.Information("Load bytes for FileRecord[{@i}]: {@SpecialBytes}",i, bytes.ToArray());

            if (EventManager != null)
            await EventManager.WaitEmptyEventsInQueue(EventNames.__UPDATE_FILEREC_EVENT);

            storage.GetFileTable().LoadFileRecord(bytes.ToArray(), (UInt32)bytes.Count);
            
            offset = recInfo.NextFileRecord;
        }
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


    private IEventManagerService?     _EventManager;
    private IVirtualStorageService?   _StorageService;
    private IFileCommanderLogService? _LogService;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TruncatedFileRecord
    {
        internal byte Crc;
        internal UInt16 RecordSize;
        internal byte IsDeleted;
        internal UInt32 NextFileRecord;
    }
}