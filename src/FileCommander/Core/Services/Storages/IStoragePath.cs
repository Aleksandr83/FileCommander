using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FileCommander.Core.Services.Storages.Path;

namespace FileCommander.Core.Services.Storages;

public interface IStoragePath
{

    bool   IsRootDirectory();
    UInt32 GetCurrentFolderId();

    string GetRoot();
    IList  GetAll();

    void   Add(UInt32 id, UInt32 parentId, string name);

    void   Set(Path path);
    void   Set(UInt32 folderId);    

    void   RemoveLast();
    void   Clear();

    PathItem? First();
    PathItem? Last();
    
}
