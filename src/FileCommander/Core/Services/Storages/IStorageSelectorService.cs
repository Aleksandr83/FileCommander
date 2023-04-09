using Agl.Services;
using FileCommander.Core.Services.Storages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Services;

internal interface IStorageSelectorService : IService
{
    IList<IStorageInfo> GetAll();

    //void SelectStorageLeftPanel(IStorageInfo storageInfo);
    //void SelectStorageRightPanel(IStorageInfo storageInfo);
}
