// Copyright (c) 2021 Lukin Aleksandr
//using alg.Data.Services.DB;
using alg.Services;
using alg.Services.Settings;
using alg.Types;
using FileCommander.Services.App;
// using EmployeeClient.Services.App;
// using EmployeeClient.Services.Commands;
// using EmployeeClient.Services.DockManager;
// using EmployeeClient.Services.Reffers;
// using EmployeeClient.Services.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Services
{
    internal sealed class Services
    {
        public static void Registration()
        {
            ServicesManager.Registration<ILogService>
                ((ILogService)ServicesFactory.Create<ILogService>());
            ServicesManager.Registration<IAppService>
                ((IAppService)ServicesFactory.Create<IAppService>());
            ServicesManager.Registration<ISettingsService>
                ((ISettingsService)ServicesFactory.Create<ISettingsService>());
            ServicesManager.Registration<IEventManagerService>
                ((IEventManagerService)ServicesFactory.Create<IEventManagerService>());
            ServicesManager.Registration<IVirtualStorageService>
                ((IVirtualStorageService)ServicesFactory.Create<IVirtualStorageService>());

            // ServicesManager.Registration<ICommandsService>
            //     ((ICommandsService)ServicesFactory.Create<ICommandsService>());
            // ServicesManager.Registration<IDbService>
            //     ((IDbService)ServicesFactory.Create<IDbService>());
            // ServicesManager.Registration<IReffersService>
            //     ((IReffersService)ServicesFactory.Create<IReffersService>());
            // ServicesManager.Registration<IColumnsConfigurationService>
            //     ((IColumnsConfigurationService)ServicesFactory.Create<IColumnsConfigurationService>());
            // ServicesManager.Registration<IDockManagerService>
            //     ((IDockManagerService)ServicesFactory.Create<IDockManagerService>());
            // ServicesManager.Registration<IDataFilterService>
            //      ((IDataFilterService)ServicesFactory.Create<IDataFilterService>());
        }
    }
}
