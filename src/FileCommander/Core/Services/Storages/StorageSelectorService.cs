using FileCommander.Core.Services.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Services;

public sealed class StorageSelectorService : IStorageSelectorService
{
    static List<IStorageService> _Storages = new ();

    static StorageSelectorService()
    {
        Update(); // temp
    }   


    IList<IStorageInfo> IStorageSelectorService.GetAll()
    {
        var result = new List<IStorageInfo>();
        var items  = new List<IStorageService>(_Storages);

        if (items?.Count != 0)
        {
            foreach (var storageService in items)
            {
                //var storageInfo = new Sto
            }
        }

        return result;
    }

    static void Clear()
    {
        if (_Storages?.Count != 0) _Storages?.Clear();
    }

    static void Update()
    {
        Clear();
        UpdateVirtualStorageList();
        UpdatePhisicStorageList();
    }

    static void UpdateVirtualStorageList()
    {

    }

    static void UpdatePhisicStorageList()
    {
        var allDrives = DriveInfo.GetDrives();
        foreach (var driveInfo in allDrives)
        {
            //driveInfo.
        }
    }

}


