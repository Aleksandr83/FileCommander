﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agl.Types.Configuration;

public class JsonConfigurationFile
{
    public JsonConfigurationFile(String fileName)             
    {
        _FileName = fileName;
    }

    public IConfiguration? GetConfiguration() => _Configuration;
    private String GetConfigurationFileName() => _FileName;
    private String GetConfigurationDataDir()  => Path.GetDirectoryName(_FileName) ?? String.Empty;

    public void InitConfiguration()
    {
        var configuration = (IConfigurationRoot?)new ConfigurationBuilder()?
           .SetBasePath(GetConfigurationDataDir())?
           .Add<WritableJsonConfigurationSource>
               (
                   (Action<WritableJsonConfigurationSource>)(s =>
                   {
                       s.FileProvider = null;
                       s.Path = GetConfigurationFileName();
                       s.Optional = false;
                       s.ReloadOnChange = false;
                       s.ResolveFileProvider();
                   })
               )
           .Build();         
            
        
        _Configuration = (configuration != null)? new JsonConfiguration(this, configuration): null;            

    }       

    private JsonConfigurationProvider? GetConfigurationProvider()
    {
        return (JsonConfigurationProvider?)GetConfiguration()?.Providers?
            .Where(provider => provider is WritableJsonConfigurationProvider)?
            .FirstOrDefault();         
    }

    public void Save()
    {
        var fileName = GetConfigurationFileName();
        var configurationProvider = (WritableJsonConfigurationProvider?)GetConfigurationProvider();            
        String jsonText = configurationProvider?.GetSettings()?.ToJson() ?? String.Empty;           
        File.WriteAllText(fileName, jsonText);
    }

    private String _FileName;

    private IConfiguration? _Configuration;
}
