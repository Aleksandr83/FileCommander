using System.Collections.Generic;
using System.Collections.ObjectModel;
using Agl.Services;
using VirtualFS;

namespace FileCommander.Services;

public interface IVirtualStorageService : IService
{
    internal StoragePath GetCurrentPath();

    internal StorageBootRecord  GetBootRecord();    

    internal StorageFileTable   GetFileTable();

    internal void CreateNewStorage();
    internal void LoadDefaultStorage();
    internal void SaveDefaultStorage();
    internal void CreateFolder(string folderName);
    internal void CreateFile(string fileName);
}
