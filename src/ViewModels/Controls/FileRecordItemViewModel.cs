using System;
using VirtualFS;

namespace FileCommander.ViewModels
{
    public class FileRecordItemViewModel  : ViewModelBase
    {
        FileRecord _FileRecord;

        public byte Crc
        {
            get {return _FileRecord.Crc; }
            set
            {
                _FileRecord.Crc = value;
                OnPropertyChanged("Crc");
            }
        }

        public UInt16  RecordSize
        {
            get {return _FileRecord.RecordSize; }
            set
            {
                _FileRecord.RecordSize = value;
                OnPropertyChanged("RecordSize");
            }
        }

        public byte IsDeleted
        {
            get {return _FileRecord.IsDeleted; }
            set
            {
                _FileRecord.IsDeleted = value;
                OnPropertyChanged("IsDeleted");
            }
        }

        public UInt32  NextFileRecord
        {
            get {return _FileRecord.NextFileRecord; }
            set
            {
                _FileRecord.NextFileRecord = value;
                OnPropertyChanged("NextFileRecord");
            }
        }

        public UInt32 Id
        {
            get { return _FileRecord.Id; }
            set
            {
                _FileRecord.Id = value;
                OnPropertyChanged("Id");
            }
        }

        public byte IsDirectory
        {
            get {return _FileRecord.IsDirectory; }
            set
            {
                _FileRecord.IsDirectory = value;
                OnPropertyChanged("IsDirectory");
            }
        }

        public UInt32 ParentId
        {
            get { return _FileRecord.ParentId; }
            set
            {
                _FileRecord.ParentId = value;
                OnPropertyChanged("ParentId");
            }
        }

        public byte IsCompressed
        {
            get { return _FileRecord.IsCompressed; }
            set 
            {
                _FileRecord.IsCompressed = value;
                OnPropertyChanged("IsCompressed");
            }
        }

        public byte CompressedType
        {
            get { return _FileRecord.CompressedType; }
            set
            {
                _FileRecord.CompressedType = value;
                OnPropertyChanged("CompressedType");
            }
        }

        public byte IsEncripted
        {
            get { return _FileRecord.IsEncripted; }
            set
            {
                _FileRecord.IsEncripted = value;
                OnPropertyChanged("IsEncripted");
            }
        }

        public UInt16 Alg
        {
            get { return _FileRecord.Alg; }
            set
            {
                _FileRecord.Alg = value;
                OnPropertyChanged("Alg");
            }
        }

        public UInt32 DataSize
        {
            get { return _FileRecord.DataSize; }
            set
            {
                _FileRecord.DataSize = value;
                OnPropertyChanged("DataSize");
            }
        }

        public UInt32  DataBlockCount
        {
            get { return _FileRecord.DataBlockCount; }
            set
            {
                _FileRecord.DataBlockCount = value;
                OnPropertyChanged("DataBlockCount");
            }
        }

        public UInt32  FirstDataBlockOffset
        {
            get { return _FileRecord.FirstDataBlockOffset; }
            set
            {
                _FileRecord.FirstDataBlockOffset = value;
                OnPropertyChanged("FirstDataBlockOffset");
            }
        }

        public byte EncodingNameType
        {
            get { return _FileRecord.EncodingNameType; }
            set
            {
                _FileRecord.EncodingNameType = value;
                OnPropertyChanged("EncodingNameType");
            }
        }

        public byte NameLength
        {
            get { return _FileRecord.NameLength; }
            set
            {
                _FileRecord.NameLength = value;
                OnPropertyChanged("NameLength");
            }
        }

        public byte[]  Name
        {
            get { return _FileRecord.Name; }
            set
            {
                _FileRecord.Name = value;
                OnPropertyChanged("Name");
            }
        }

        #region  Constructor
        public FileRecordItemViewModel()
        {

        }
        #endregion  Constructor

        public FileRecordItemViewModel(FileRecord fileRecord)
        {
            Crc                 = fileRecord.Crc;
            RecordSize          = fileRecord.RecordSize;
            IsDeleted           = fileRecord.IsDeleted;
            NextFileRecord      = fileRecord.NextFileRecord;            
            Id                  = fileRecord.Id;
            IsDirectory         = fileRecord.IsDirectory;
            ParentId            = fileRecord.ParentId;
            IsCompressed        = fileRecord.IsCompressed;
            CompressedType      = fileRecord.CompressedType;
            IsEncripted         = fileRecord.IsEncripted;
            Alg                 = fileRecord.Alg;
            DataSize            = fileRecord.DataSize;
            DataBlockCount      = fileRecord.DataBlockCount;
            FirstDataBlockOffset= fileRecord.FirstDataBlockOffset;
            EncodingNameType    = fileRecord.EncodingNameType;
            NameLength          = fileRecord.NameLength;
            Name                = fileRecord.Name;
        }
    }
}