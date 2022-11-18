using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using alg.Helpers;
using alg.Types.Generic;
using FileCommander.Services;
using Serilog;

namespace VirtualFS
{
    public class VirtualStorageLoader
    {        
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TruncatedFileRecord
        {
            internal byte    Crc;
            internal UInt16  RecordSize;
            internal byte    IsDeleted;
            internal UInt32  NextFileRecord; 
        }

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
        #region LogService
        IFileCommanderLogService?   _LogService;

        IFileCommanderLogService? LogService 
        { 
            get
            {
                if (_LogService == null)
                    _LogService = FileCommanderServices.GetLogService();
                return _LogService;
            }
        }
        #endregion LogService

        public VirtualStorageLoader()
        {

        }

        public async void Load(Storage storage, string fileName)
        {      
            if (EventManager != null)      
              await EventManager.WaitEmptyEventsInQueue(EventNames.__UPDATE_BOOTREC_EVENT);

            StreamReader sr = new StreamReader(fileName);

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



    }
}