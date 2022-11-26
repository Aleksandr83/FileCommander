using FileCommander.Core.Services.Storages;
using ImTools;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using VirtualFS;
using static System.Environment;

namespace FileCommander.Services;

public class StorageService : IVirtualStorageService
{
    const string __DEFAULT_STORAGE_FILE   = "storege.pfs";
    
    public StorageService()
    {
        CheckAndCreateDefaultDir();
    }

    string GetDefaultStorageFile()         => __DEFAULT_STORAGE_FILE;
    string GetDefaultStorageFolder()       => __DEFAULT_STORAGE_FOLDER;

    public IStoragePath GetCurrentPath()    => _CurrentPath;
   

    public StorageBootRecord  GetBootRecord()  => _Storage.GetBootRecord();
    
    public StorageFileTable   GetFileTable()   => _Storage.GetFileTable();

    void Init()
    {
        _CurrentPath.Clear();
    }

    public void CreateNewStorage()
    {
        Init();
        _Storage = new Storage();
    }

    public void LoadDefaultStorage()
    {
        Init();
        CheckAndCreateDefaultDir();

        var folder = GetDefaultStorageFolder();
        var file   = GetDefaultStorageFile();
        
        string fullFilePath = System.IO.Path.Combine(folder, file);          
        
        _Storage = new Storage();    

        new VirtualStorageLoader().Load(_Storage, fullFilePath);          
    }

    public void SaveDefaultStorage()
    {
        CheckAndCreateDefaultDir();

        var folder = GetDefaultStorageFolder();
        var file   = GetDefaultStorageFile();
        
        string fullFilePath = System.IO.Path.Combine(folder, file); 

        var storageSaver = new VirtualStorageSaver();
        storageSaver.Save(_Storage, fullFilePath);
        
    }

    public void CreateFolder(string folderName)
    {
        _Storage.CreateFolder(_CurrentPath, folderName);
    }

    public void CreateFile(string fileName)
    {
        _Storage.CreateFile(_CurrentPath, fileName);
    }

    void CheckAndCreateDefaultDir()
    {            
        var folder = GetDefaultStorageFolder();
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);            
    }

    /*
    StorageBootRecord IVirtualStorageService.GetBootRecord()
    {
        throw new NotImplementedException();
    }

    StorageFileTable IVirtualStorageService.GetFileTable()
    {
        throw new NotImplementedException();
    }

    void IVirtualStorageService.CreateNewStorage()
    {
        throw new NotImplementedException();
    }

    void IVirtualStorageService.LoadDefaultStorage()
    {
        throw new NotImplementedException();
    }

    void IVirtualStorageService.SaveDefaultStorage()
    {
        throw new NotImplementedException();
    }

    IStoragePath IStorageService.GetCurrentPath()
    {
        throw new NotImplementedException();
    }

    void IStorageService.CreateFolder(string folderName)
    {
        throw new NotImplementedException();
    }

    void IStorageService.CreateFile(string fileName)
    {
        throw new NotImplementedException();
    }
    */

    private Storage _Storage = new();
    private VirtualFS.StoragePath _CurrentPath = new();

    string __DEFAULT_STORAGE_FOLDER = System.IO.Path.Combine
                (
                    System.Environment.GetFolderPath(SpecialFolder.UserProfile),
                    ".FileCommander"
                );

}

