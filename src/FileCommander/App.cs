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
using FileCommander;
using FileCommander.Services;
using FileCommander.Services.App;


namespace MyApp.FileCommander;

internal sealed class App
{
    public static void Init()
    {
        Services.Registration();          
        InitConfiguration();
        RegisteringCommands();                 
    }             

    private static void InitConfiguration()
    {
        (ServicesManager
            .GetService<IAppService>() as IAppService)?
            .InitConfiguration();
    }           
  
    private static void RegisteringCommands()
    {          
        CommandRegistrator.Registration();    
    }              

}
