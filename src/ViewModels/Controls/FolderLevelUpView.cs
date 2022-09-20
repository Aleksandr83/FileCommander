using VirtualFS;

namespace FileCommander.ViewModels
{

    public class FolderLevelUpView : FsItemViewModel
    {        
        public FolderLevelUpView() : base(new FileRecord(){ NameLength = 2, Name = new byte[2]{(byte)'.',(byte)'.'}})
        {            
        }

    }

}