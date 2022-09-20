using VirtualFS;

namespace FileCommander.ViewModels
{
    public class FsItemViewModel : ViewModelBase, IFsItem
    {
        FileRecord _FileRecord;

        public byte[] Name
        {
            get { return _FileRecord.Name; }
        }

        public FileRecord GetValue() => _FileRecord;

        public FsItemViewModel(FileRecord fileRecord)
        {
            _FileRecord = fileRecord;
            OnPropertyChanged("Name");
        }
    }
}