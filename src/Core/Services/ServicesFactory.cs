// Copyright (c) 2021 Lukin Aleksandr
using alg.Services;
using alg.Services.Settings;
using FileCommander.Services.App;
//using EmployeeClient.Controls;
// using EmployeeClient.Services.App;
// using EmployeeClient.Services.ColumnsConfiguration;
// using EmployeeClient.Services.Commands;
// using EmployeeClient.Services.DockManager;
// using EmployeeClient.Services.Reffers;
using EmployeeClient.Services.Settings;

//using EmployeeClient.src.Services.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Services
{
    internal sealed class ServicesFactory
    {
      
        public static IService Create<T>()
        {
            if (typeof(T) == typeof(ILogService))
                return (IService)Activator.CreateInstance(typeof(FileCommanderLogService));
            if (typeof(T) == typeof(IAppService))
                return (IService)Activator.CreateInstance(typeof(AppService));            
            if (typeof(T) == typeof(ISettingsService))
                return (IService)Activator.CreateInstance(typeof(SettingsService));
            if (typeof(T) == typeof(IEventManagerService))
                return (IEventManagerService)Activator.CreateInstance(typeof(EventManagerService));
            if (typeof(T) == typeof(IVirtualStorageService))
                return (IVirtualStorageService)Activator.CreateInstance(typeof(StorageService));
            
            
            // if (typeof(T) == typeof(ICommandsService))
            //     return (IService)Activator.CreateInstance(typeof(CommandsService));
            // if (typeof(T) == typeof(alg.Data.Services.DB.IDbService))
            //     return (IService)Activator.CreateInstance(typeof(DbService));
            // if (typeof(T) == typeof(IReffersService))
            //     return (IService)Activator.CreateInstance(typeof(ReffersService));
            // if (typeof(T) == typeof(IColumnsConfigurationService))
            //     return (IService)Activator.CreateInstance(typeof(ColumnsConfigurationService));
            // if (typeof(T) == typeof(IDockManagerService))
            //     return (IService)Activator.CreateInstance(typeof(DockManagerControl));
            // if (typeof(T) == typeof(IDataFilterService))
            //     return (IService)Activator.CreateInstance(typeof(DataFilterService));
            return null;
        }

    }
}
