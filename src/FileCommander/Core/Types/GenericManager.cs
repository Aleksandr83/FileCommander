using Types.Generic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agl.Types.Generic;

namespace Agl.Types;

public class GenericManager
{
    protected static ServiceCollection GetServices() => _Services;
    protected static ServiceProvider? GetServiceProvider() => _ServiceProvider;
    protected static void BuildServiceProvider() => _ServiceProvider = GetServices().BuildServiceProvider();
    protected static void AddSingleton<T>(T value) where T : class
    {
        try
        {
            var services = GetServices();
            services?.AddSingleton<T>(value);
            ValueСaching(value);
        }
        catch (Exception) 
        {
            //throw;
        }
    }

    public static void Registration<T>(T? service) where T : class
    {
        if (service != null)
        {
            AddSingleton<T>(service);
            BuildServiceProvider();
        }
    }

    private static void ValueСaching(object value)
    {
        _Cache?.Add(value);
    }

    private static IEnumerable<object> GetCachingValues() => (IEnumerable<object>)_Cache;
    public static IEnumerable<T> GetAll<T>()
    {
        IList<T> result = new List<T>();
        var values = GetCachingValues();
        foreach (var value in values ?? (IEnumerable<object>)List.Empty<T>())
        {
            if (value is T)
                result?.Add((T)value);
        }
        return result;
        
    }

    private static IList<object>     _Cache    = new List<object>();
    private static ServiceCollection _Services = new ();
    private static ServiceProvider?  _ServiceProvider;

}
