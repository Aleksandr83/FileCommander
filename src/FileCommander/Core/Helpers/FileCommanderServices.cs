using Agl.Types;
using FileCommander.Services;

namespace Agl.Helpers;

public sealed class FileCommanderServices :  BasicServices
{
    public static IVirtualStorageService? GetStorageService()
    {
        return (IVirtualStorageService?)ServicesManager
                .GetService<IVirtualStorageService>();
    }   

    public new static IFileCommanderLogService? GetLogService()
    {
        return (IFileCommanderLogService?)ServicesManager
                .GetService<ILogService>();
    }
    
}