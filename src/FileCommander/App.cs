// Copyright (c) 2021 Lukin Aleksandr
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agl.Types;
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
