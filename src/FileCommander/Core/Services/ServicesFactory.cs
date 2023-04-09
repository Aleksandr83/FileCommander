using System;
using Agl.Services;
using Agl.Services.Settings;
using FileCommander.Services.App;
using EmployeeClient.Services.Settings;

namespace FileCommander.Services;

internal sealed class ServicesFactory
{
  
    public static IService? Create<T>()
    {
        if (typeof(T) == typeof(ILogService))
            return (IService?)Activator.CreateInstance(typeof(FileCommanderLogService));
        if (typeof(T) == typeof(IAppService))
            return (IService?)Activator.CreateInstance(typeof(AppService));            
        if (typeof(T) == typeof(ISettingsService))
            return (IService?)Activator.CreateInstance(typeof(SettingsService));
        if (typeof(T) == typeof(IEventManagerService))
            return (IEventManagerService?)Activator.CreateInstance(typeof(EventManagerService));
        if (typeof(T) == typeof(ICommandManagerService))
            return (ICommandManagerService?)Activator.CreateInstance(typeof(CommandManagerService));
        if (typeof(T) == typeof(IStorageSelectorService))
            return (IStorageSelectorService?)Activator.CreateInstance(typeof(StorageSelectorService));
        if (typeof(T) == typeof(IVirtualStorageService))
            return (IVirtualStorageService?)Activator.CreateInstance(typeof(VirtualStorageService));          
        
        return null;
    }

}
