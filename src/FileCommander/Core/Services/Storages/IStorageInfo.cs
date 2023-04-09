using FileCommander.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Core.Services.Storages;

public interface IStorageInfo
{
    public Guid   Id   { get; }
    public string Name { get; }
    public IStorageService StorageService { get; }
}
