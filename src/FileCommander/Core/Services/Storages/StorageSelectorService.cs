using FileCommander.Core.Services.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Services;

public class StorageSelectorService : IStorageSelectorService
{
    IList<IStorageInfo> IStorageSelectorService.GetAll()
    {
        throw new NotImplementedException();
    }
}


