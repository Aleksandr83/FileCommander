using FileCommander.Core.Services.Storages;
using FileCommander.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Services;

public class StorageService : IStorageService
{
    public StorageService()
    {

    }

    public IStoragePath GetCurrentPath() => _CurrentPath;

    public void CreateFolder(string folderName)
    {
        //_Storage.CreateFolder(_CurrentPath, folderName);
    }
    public void CreateFile(string fileName)
    {
        //_Storage.CreateFile(_CurrentPath, fileName);
    }

    private FS.StoragePath _CurrentPath = new();

}
