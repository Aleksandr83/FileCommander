using System.Collections.Generic;
using System.Threading.Tasks;
using alg.Helpers;
using FileCommander.Services;

namespace VirtualFS;

public class Storage
{     
    
    public Storage()
    {           
        Init();            
    }

    internal StorageBootRecord GetBootRecord() => _BootRecord;
    internal StorageFileTable GetFileTable()   => _FileTable;

    public void Init()
    {                      
    }    

    internal void CreateFolder(VirtualFS.Path path,string folderName)
    {                
        _FileTable.CreateFolder(path, folderName);
    }
    
    internal void CreateFile(VirtualFS.Path path,string fileName)
    {
        _FileTable.CreateFile(path, fileName);
    }

    StorageBootRecord _BootRecord = new StorageBootRecord();
    StorageFileTable  _FileTable  = new StorageFileTable();

}