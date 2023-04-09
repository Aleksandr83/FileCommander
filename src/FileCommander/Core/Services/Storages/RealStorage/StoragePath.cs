using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS;

public class StoragePath : FileCommander.Core.Services.Storages.StoragePath
{
    public StoragePath()
    {

    }

    public override string GetRoot() => throw new NotImplementedException();

    public override void Set(UInt32 folderId)
    {
        throw new NotImplementedException();
    }

    public override bool IsRootDirectory()
    {
        throw new NotImplementedException();
    }



}
