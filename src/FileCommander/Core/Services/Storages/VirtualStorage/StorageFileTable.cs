using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Agl.Helpers;
using FileCommander.Services;
using System.Collections.Specialized;
using Agl.Types.Generic;
using Mimica.Types.CRC;
using System.Reflection;
using System.Runtime.InteropServices;
using FileCommander.Models.FileManagerPanels.VirtualFS;

namespace VirtualFS;

public class StorageFileTable : Tree<FileRecord, UInt32>
{
    const string __UPDATE_FILEREC_EVENT = EventNames.__UPDATE_FILEREC_EVENT;    

    public StorageFileTable()
    {                  
        EventManager?.Registred(__UPDATE_FILEREC_EVENT);                      

        Init();
    }

    void Init()
    {
        ClearFileRecords();
    }

    #region Tree   

    protected override IEnumerable<FileRecord> GetAll()
    {
        return _FileRecords;
    }

    public IEnumerable<FileRecord> GetAllByParentId(UInt32 parentId)
    {
        return base.GetNodesByParentId(parentId);
    }

    protected override UInt32 GetNodeId(FileRecord node)
    {
        return node.Id;
    }

    protected override UInt32 GetNodeParentId(FileRecord node)
    {
        return node.ParentId;
    }

    protected override int    CompareNodeId(UInt32 id1, UInt32 id2)
    {
        if (id1 > id2) return -1;
        if (id1 < id2) return  1;
        return 0;
    }

    #endregion Tree

    public IList<FileRecord> GetFileRecords()
    {
        return new List<FileRecord>(_FileRecords);                       
    }

    void ClearFileRecords()
    {
        if (_FileRecords.Count > 0)
            _FileRecords.Clear();

        EventManager?.RaiseEvent(__UPDATE_FILEREC_EVENT,this, new EventManagerArgs());
    }

    public void CreateFile(VirtualFS.StoragePath path,string fileName)
    {
        CreateFileRecord(path, fileName, 0);
    }

    public void CreateFolder(VirtualFS.StoragePath path,string folderName)
    {
        CreateFileRecord(path, folderName, 1);
    }

    public void CreateFileRecord(VirtualFS.StoragePath path,string name,Byte isDirectory)
    {
        StoragePath.PathItem? parent = path?.Last();          
        UInt32? parentId      = (parent == null)? GetRootDirectoryId() : parent?.Id;
        Byte[]  itemName      = EncodingConverter.ToAssciByteArray(name);
        
        var record = new FileRecord()
        {
            Id          = GetNewFileRecordId(),
            ParentId    = parentId ?? UInt32.MinValue,
            IsDirectory = isDirectory,
            IsDeleted   = 0,
            
            NameLength  =  (Byte)itemName.Length,
            Name        =  itemName
        };     

        var size = Struct.GetSizeExt<FileRecord>();
        record.RecordSize = (ushort)(itemName.Length + size);               
        
        record.Crc    = CalcFileRecordCrc(record, size);              

        if (_FileRecords.Count != 0)
        {
            UInt32 offset = 0;
            var lastFileRecord = _FileRecords.Last();
            size = lastFileRecord.RecordSize;                              
            offset += GetFileRecordOffset(lastFileRecord.Id);  
            offset += size;    

            var prevItemIndex = _FileRecords.Count-1;
            var prevItem  = _FileRecords[prevItemIndex];
            size =  prevItem.RecordSize;
            prevItem.NextFileRecord = offset;                
            prevItem.Crc            = CalcFileRecordCrc(prevItem, size); 
            _FileRecords[prevItemIndex] = prevItem;               
        }

        _FileRecords.Add(record);           
        
        EventManager?.RaiseEvent(__UPDATE_FILEREC_EVENT,this, new EventManagerArgs());
    }

    public Byte CalcFileRecordCrc(FileRecord record, UInt32 size)
    {
        Byte result      = 0;
        Crc8 crc8        = new ();
        List<Byte> bytes = new (Struct.ToArrayExt<FileRecord>(record));
       
        crc8.CalcArrayCrc(ref result, bytes.ToArray(),  1, size-1);             

        return result;
    }

    UInt32 GetRootDirectoryId()
    {          
        return StorageService?.GetBootRecord().GetValue().RootDirectoryId ?? 0;           
    }        

    UInt32 GetNewFileRecordId()
    {
        UInt32 result = 0;

        do
        {
            if (result == GetRootDirectoryId())
            {
                result++;
                continue;
            }

            var searchItem = GetNodeById(result);
            if (IsNodeDefault(searchItem)) return result;

            result++;
        }
        while(true);            
    }

    bool IsEmptyNextRecord(FileRecord record) 
    {            
        return (record.NextFileRecord == 0);
    }

    UInt32 GetFileRecordOffset(UInt32 fileRecordId)
    {            
        if (StorageService == null) return 0;

        UInt32 result = StorageService.GetBootRecord().GetValue()
                            .OffsetFileTable;

        foreach (var item in _FileRecords)
        {
            if (GetNodeId(item) == fileRecordId)
            {
                return result;
            }

            result += item.RecordSize;
        }

        return result;
    }     

    public void LoadFileRecord(Byte[] bytes, UInt32 length)
    {
        int i    = 0;          
        var b    = bytes;
        var fileRecord = ArrayType
                .ToStructExt<FileRecord>(bytes, length, SetFieldFileRecord);

        var nameLength = fileRecord.NameLength;
        var offset     = length - nameLength;
        var name       = new Byte[nameLength];          
        
        while (nameLength-- > 0)              
            name[i++] += bytes[offset++];
        fileRecord.Name = name;

        _FileRecords.Add(fileRecord);

        LogService?.LogFileRecord("Load FileRecord:", fileRecord);
        EventManager?.RaiseEvent(__UPDATE_FILEREC_EVENT,this, new EventManagerArgs());

    }
    
    FileRecord SetFieldFileRecord(FileRecord fileRecord, FieldInfo field, dynamic value)
    {      
        if (field.Name == "Crc")
            fileRecord.Crc = (Byte)value;
        else if (field.Name == "RecordSize")
            fileRecord.RecordSize = (UInt16)value;
        else if (field.Name == "IsDeleted")
            fileRecord.IsDeleted = (Byte)value;
        else if (field.Name == "NextFileRecord")
            fileRecord.NextFileRecord = (UInt32)value;
        else if (field.Name == "Id")
            fileRecord.Id = (UInt32)value;
        else if (field.Name == "IsDirectory")
            fileRecord.IsDirectory = (Byte)value;
        else if (field.Name == "ParentId")
            fileRecord.ParentId = (UInt32)value;
        else if (field.Name == "IsCompressed")
            fileRecord.IsCompressed = (Byte)value;
        else if (field.Name == "CompressedType")
            fileRecord.CompressedType = (Byte)value;
        else if (field.Name == "IsEncripted")
            fileRecord.IsEncripted = (Byte)value;
        else if (field.Name == "Alg")
            fileRecord.Alg = (UInt16)value;
        else if (field.Name == "DataSize")
            fileRecord.DataSize = (UInt32)value;
        else if (field.Name == "DataBlockCount")
            fileRecord.DataBlockCount = (UInt32)value;
        else if (field.Name == "FirstDataBlockOffset")
            fileRecord.FirstDataBlockOffset = (UInt32)value;
        else if (field.Name == "EncodingNameType")
            fileRecord.EncodingNameType = (Byte)value;
        else if (field.Name == "NameLength")
            fileRecord.NameLength = (Byte)value;
        else if (field.Name == "Name")            
            fileRecord.Name = value;  

        return fileRecord;
    }

    #region Properties

    public int Count => _FileRecords.Count;

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

    private readonly List<FileRecord> _FileRecords = new ();

    private IEventManagerService?     _EventManager;
    private IVirtualStorageService?   _StorageService;
    private IFileCommanderLogService? _LogService;

}