﻿using Microsoft.Extensions.DependencyInjection;
using alg.Types;
using Agl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Agl.Types;

public sealed class ServicesManager: GenericManager
{
    public static IService? GetService<T>()
    {
        IService? result    = null;      
        var serviceProvider = GetServiceProvider();
        
        if (serviceProvider != null)
        result = (IService?)serviceProvider.GetService<T>();  

        return result;
    }
}
