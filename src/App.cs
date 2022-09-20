// Copyright (c) 2021 Lukin Aleksandr
// using EmployeeClient.Configuration;
// using EmployeeClient.Services.App;
// using EmployeeClient.Services.Commands;
// using EmployeeClient.Services.DockManager;
// using EmployeeClient.Services.Reffers;
// using EmployeeClient.Services.Views;
// using alg.Types.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alg.Types;
using FileCommander.Services;
using FileCommander.Services.App;
//using EmployeeClient.Views.Interfaces;

namespace MyApp.FileCommander
{
    internal sealed class App
    {
        public static void Init()
        {
            Services.Registration();          
            InitConfiguration();
            RegisteringCommands();
            //Reffers.Registration();
            //Services.Views
            //    .Views.Registration();
            //AttachViewsInDockManager();
            //DbManager.Disconnected();           

        }             

        private static void InitConfiguration()
        {
            (ServicesManager
                .GetService<IAppService>() as IAppService)?
                .InitConfiguration();
        }

        private static void AttachViewsInDockManager()
        {
            // var views = ViewManager.GetAll<IView>();
            // var dockManager = (IDockManagerService)ServicesManager
            //     .GetService<IDockManagerService>();
            // foreach (var view in views)
            //     dockManager?.AddView(view);
        }         
      
        private static void RegisteringCommands()
        {          
            // var commandsService = (ICommandsService)ServicesManager
            //     .GetService<ICommandsService>();
            // commandsService.CommandRegistration(new Command
            //     (
            //         CommandsNames.CONNECTED_TO_DB,                    
            //         AppCommands.ConnectionToDB
            //     ));
        }              

    }
}
