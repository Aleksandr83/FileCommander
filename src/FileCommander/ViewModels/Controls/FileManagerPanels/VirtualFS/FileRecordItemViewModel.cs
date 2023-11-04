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
            OnPropertyChanged(nameof(Crc));
        }
    }

    public ushort RecordSize
    {
        get => _FileRecord.RecordSize;
        set
        {
            _FileRecord.RecordSize = value;
            OnPropertyChanged(nameof(RecordSize));
        }
    }

    public byte IsDeleted
    {
        get => _FileRecord.IsDeleted;
        set
        {
            _FileRecord.IsDeleted = value;
            OnPropertyChanged(nameof(IsDeleted));
        }
    }

    public uint NextFileRecord
    {
        get => _FileRecord.NextFileRecord;
        set
        {
            _FileRecord.NextFileRecord = value;
            OnPropertyChanged(nameof(NextFileRecord));
        }
    }

    public uint Id
    {
        get => _FileRecord.Id;
        set
        {
            _FileRecord.Id = value;
            OnPropertyChanged(nameof(Id));
        }
    }

    public byte IsDirectory
    {
        get => _FileRecord.IsDirectory;
        set
        {
            _FileRecord.IsDirectory = value;
            OnPropertyChanged(nameof(IsDirectory));
        }
    }

    public uint ParentId
    {
        get => _FileRecord.ParentId;
        set
        {
            _FileRecord.ParentId = value;
            OnPropertyChanged(nameof(ParentId));
        }
    }

    public byte IsCompressed
    {
        get => _FileRecord.IsCompressed;
        set
        {
            _FileRecord.IsCompressed = value;
            OnPropertyChanged(nameof(IsCompressed));
        }
    }

    public byte CompressedType
    {
        get => _FileRecord.CompressedType;
        set
        {
            _FileRecord.CompressedType = value;
            OnPropertyChanged(nameof(CompressedType));
        }
    }

    public byte IsEncripted
    {
        get => _FileRecord.IsEncripted;
        set
        {
            _FileRecord.IsEncripted = value;
            OnPropertyChanged(nameof(IsEncripted));
        }
    }

    public ushort Alg
    {
        get => _FileRecord.Alg;
        set
        {
            _FileRecord.Alg = value;
            OnPropertyChanged(nameof(Alg));
        }
    }

    public uint DataSize
    {
        get => _FileRecord.DataSize;
        set
        {
            _FileRecord.DataSize = value;
            OnPropertyChanged(nameof(DataSize));
        }
    }

    public uint DataBlockCount
    {
        get => _FileRecord.DataBlockCount;
        set
        {
            _FileRecord.DataBlockCount = value;
            OnPropertyChanged(nameof(DataBlockCount));
        }
    }

    public uint FirstDataBlockOffset
    {
        get => _FileRecord.FirstDataBlockOffset;
        set
        {
            _FileRecord.FirstDataBlockOffset = value;
            OnPropertyChanged(nameof(FirstDataBlockOffset));
        }
    }

    public byte EncodingNameType
    {
        get => _FileRecord.EncodingNameType;
        set
        {
            _FileRecord.EncodingNameType = value;
            OnPropertyChanged(nameof(EncodingNameType));
        }
    }

    public byte NameLength
    {
        get => _FileRecord.NameLength;
        set
        {
            _FileRecord.NameLength = value;
            OnPropertyChanged(nameof(NameLength));
        }
    }

    public byte[] Name
    {
        get => _FileRecord.Name;
        set
        {
            _FileRecord.Name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    #endregion Properties

    private FileRecord _FileRecord;

}