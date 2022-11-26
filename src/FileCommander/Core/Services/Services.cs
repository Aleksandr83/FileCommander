using Agl.Types;
using Agl.Services.Settings;
using FileCommander.Services.App;

namespace FileCommander.Services;

internal sealed class Services
{
    public static void Registration()
    {
        ServicesManager.Registration<ILogService>
            ((ILogService?)ServicesFactory.Create<ILogService>());
        ServicesManager.Registration<IAppService>
            ((IAppService?)ServicesFactory.Create<IAppService>());
        ServicesManager.Registration<ISettingsService>
            ((ISettingsService?)ServicesFactory.Create<ISettingsService>());
        ServicesManager.Registration<IEventManagerService>
            ((IEventManagerService?)ServicesFactory.Create<IEventManagerService>());
        ServicesManager.Registration<ICommandManagerService>
            ((ICommandManagerService?)ServicesFactory.Create<ICommandManagerService>());
        ServicesManager.Registration<IVirtualStorageService>
            ((IVirtualStorageService?)ServicesFactory.Create<IVirtualStorageService>());
        ServicesManager.Registration<IStorageSelectorService>
            ((IStorageSelectorService?)ServicesFactory.Create<IStorageSelectorService>());                  
    }
}
