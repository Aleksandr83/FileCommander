using Agl.Services;
using FileCommander.Core.Services.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualFS;

namespace FileCommander.Services;

public interface IStorageService : IService
{
    internal IStoragePath GetCurrentPath();

    internal void CreateFolder(string folderName);
    internal void CreateFile(string fileName);
}
