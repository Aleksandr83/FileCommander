using System;
using FileCommander.Models.FileManagerPanels.VirtualFS;

namespace FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;

public class FileRecordItemViewModel : ViewModelBase
{

    public FileRecordItemViewModel(FileRecord fileRecord)
    {
        Crc = fileRecord.Crc;
        RecordSize = fileRecord.RecordSize;
        IsDeleted = fileRecord.IsDeleted;
        NextFileRecord = fileRecord.NextFileRecord;
        Id = fileRecord.Id;
        IsDirectory = fileRecord.IsDirectory;
        ParentId = fileRecord.ParentId;
        IsCompressed = fileRecord.IsCompressed;
        CompressedType = fileRecord.CompressedType;
        IsEncripted = fileRecord.IsEncripted;
        Alg = fileRecord.Alg;
        DataSize = fileRecord.DataSize;
        DataBlockCount = fileRecord.DataBlockCount;
        FirstDataBlockOffset = fileRecord.FirstDataBlockOffset;
        EncodingNameType = fileRecord.EncodingNameType;
        NameLength = fileRecord.NameLength;
        Name = fileRecord.Name;
    }

    #region Properties

    public byte Crc
    {
        get => _FileRecord.Crc;
        set
        {
            _FileRecord.Crc = value;
            OnPropertyChanged("Crc");
        }
    }

    public ushort RecordSize
    {
        get => _FileRecord.RecordSize;
        set
        {
            _FileRecord.RecordSize = value;
            OnPropertyChanged("RecordSize");
        }
    }

    public byte IsDeleted
    {
        get => _FileRecord.IsDeleted;
        set
        {
            _FileRecord.IsDeleted = value;
            OnPropertyChanged("IsDeleted");
        }
    }

    public uint NextFileRecord
    {
        get => _FileRecord.NextFileRecord;
        set
        {
            _FileRecord.NextFileRecord = value;
            OnPropertyChanged("NextFileRecord");
        }
    }

    public uint Id
    {
        get => _FileRecord.Id;
        set
        {
            _FileRecord.Id = value;
            OnPropertyChanged("Id");
        }
    }

    public byte IsDirectory
    {
        get => _FileRecord.IsDirectory;
        set
        {
            _FileRecord.IsDirectory = value;
            OnPropertyChanged("IsDirectory");
        }
    }

    public uint ParentId
    {
        get => _FileRecord.ParentId;
        set
        {
            _FileRecord.ParentId = value;
            OnPropertyChanged("ParentId");
        }
    }

    public byte IsCompressed
    {
        get => _FileRecord.IsCompressed;
        set
        {
            _FileRecord.IsCompressed = value;
            OnPropertyChanged("IsCompressed");
        }
    }

    public byte CompressedType
    {
        get => _FileRecord.CompressedType;
        set
        {
            _FileRecord.CompressedType = value;
            OnPropertyChanged("CompressedType");
        }
    }

    public byte IsEncripted
    {
        get => _FileRecord.IsEncripted;
        set
        {
            _FileRecord.IsEncripted = value;
            OnPropertyChanged("IsEncripted");
        }
    }

    public ushort Alg
    {
        get => _FileRecord.Alg;
        set
        {
            _FileRecord.Alg = value;
            OnPropertyChanged("Alg");
        }
    }

    public uint DataSize
    {
        get => _FileRecord.DataSize;
        set
        {
            _FileRecord.DataSize = value;
            OnPropertyChanged("DataSize");
        }
    }

    public uint DataBlockCount
    {
        get => _FileRecord.DataBlockCount;
        set
        {
            _FileRecord.DataBlockCount = value;
            OnPropertyChanged("DataBlockCount");
        }
    }

    public uint FirstDataBlockOffset
    {
        get => _FileRecord.FirstDataBlockOffset;
        set
        {
            _FileRecord.FirstDataBlockOffset = value;
            OnPropertyChanged("FirstDataBlockOffset");
        }
    }

    public byte EncodingNameType
    {
        get => _FileRecord.EncodingNameType;
        set
        {
            _FileRecord.EncodingNameType = value;
            OnPropertyChanged("EncodingNameType");
        }
    }

    public byte NameLength
    {
        get => _FileRecord.NameLength;
        set
        {
            _FileRecord.NameLength = value;
            OnPropertyChanged("NameLength");
        }
    }

    public byte[] Name
    {
        get => _FileRecord.Name;
        set
        {
            _FileRecord.Name = value;
            OnPropertyChanged("Name");
        }
    }

    #endregion Properties

    private FileRecord _FileRecord;

}