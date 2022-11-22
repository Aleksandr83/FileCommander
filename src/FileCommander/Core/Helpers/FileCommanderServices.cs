using alg.Types;
using FileCommander.Services;

namespace alg.Helpers;

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