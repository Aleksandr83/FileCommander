// Copyright (c) 2021 Lukin Aleksandr
using alg.Services.Settings;
using alg.Types;
using alg.Types.Configuration;
//using EmployeeClient.Helpers;
using FileCommander.Services.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClient.Services.Settings;

internal class SettingsService:ISettingsService
{
    public string GetStringValue
        (String section, String parameterName, String defaultValue)
    {
        String result = String.Empty;
        var configuration = GetConfiguration();

        if (configuration != null)
        {
            result = configuration
                .GetSection(string.Format("{0}:{1}", section, parameterName))
                .Value;

            if (String.IsNullOrEmpty(result)) result = defaultValue;
        }

        return result;
    }

    public void SetStringValue
        (String section, String parameterName,String value = "")
    {            
        var configuration = GetConfiguration();

        if (configuration != null)
        {
            configuration
                .GetSection(string.Format("{0}:{1}",section, parameterName))
                .Value = value;
        }
    }

    public bool GetBoolValue
        (String section, String parameterName, bool defaultValue = false)
    {
        bool result = false;           
        var configuration = GetConfiguration();

        var s = configuration?
            .GetSection(string.Format("{0}:{1}", section, parameterName))
            .Value;

        return bool.TryParse(s, out result) ? result : defaultValue;
    }
    public void SetBoolValue
        (String section, String parameterName, bool value = false)
    {
        var configuration = GetConfiguration();

        if  (configuration != null)
        {
            configuration
                .GetSection(string.Format("{0}:{1}", section, parameterName))
                .Value = value.ToString()?.Normalize();
        }
    }
    
    public int GetIntValue
        (String section, String parameterName, int defaultValue = 0)
    {
        int result = 0;
        var configuration = GetConfiguration();
        var s = configuration?
            .GetSection(string.Format("{0}:{1}", section, parameterName))
            .Value;
        return int.TryParse(s, out result) ? result : defaultValue;
    }

    private IConfiguration? GetConfiguration()
    {
        return (IConfiguration?)(ServicesManager
            .GetService<IAppService>() as IAppService)?
            .GetConfiguration();
    }

    public void Save()
    {           
        GetConfiguration()?.Save();
    }
}