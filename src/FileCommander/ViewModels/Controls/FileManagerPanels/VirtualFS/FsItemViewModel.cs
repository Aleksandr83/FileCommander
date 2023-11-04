using FileCommander.Models.FileManagerPanels.VirtualFS;

namespace FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;

public class FsItemViewModel : ViewModelBase, IFsItem
{

    public FsItemViewModel(FileRecord fileRecord)
    {
        _FileRecord = fileRecord;
        OnPropertyChanged(nameof(Name));
    }

    public FileRecord GetValue() => _FileRecord;


    public byte[] Name => _FileRecord.Name;  
    public byte IsDirectory => _FileRecord.IsDirectory;      

    
    private FileRecord _FileRecord;
}