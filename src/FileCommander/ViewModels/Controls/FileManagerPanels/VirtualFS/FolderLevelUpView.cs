using FileCommander.Models.FileManagerPanels.VirtualFS;

namespace FileCommander.ViewModels.Controls.FileManagerPanels.VirtualFS;


public class FolderLevelUpView : FsItemViewModel
{
    public FolderLevelUpView() 
        : base(new FileRecord() { NameLength = 2, Name = new byte[2] { (byte)'.', (byte)'.' } })
    {
    }

}