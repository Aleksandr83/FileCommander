// Copyright (c) 2021 Lukin Aleksandr
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types.Configuration
{
    public class JsonConfigurationFile
    {
        private String   _FileName;        

        private IConfiguration _Configuration;

        public JsonConfigurationFile(String fileName)             
        {
            _FileName = fileName;
        }

        public IConfiguration GetConfiguration()  => _Configuration;
        private String GetConfigurationFileName() => _FileName;
        private String GetConfigurationDataDir()  => Path.GetDirectoryName(_FileName);

        public void InitConfiguration()
        {
            var configuration = (IConfigurationRoot)new ConfigurationBuilder()?
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
            _Configuration = new JsonConfiguration(this, configuration);            
        }       

        private JsonConfigurationProvider GetConfigurationProvider()
        {
            return (JsonConfigurationProvider)GetConfiguration()?.Providers?
                .Where(provider => provider is WritableJsonConfigurationProvider)?
                .FirstOrDefault();         
        }

        public void Save()
        {
            var fileName = GetConfigurationFileName();
            var configurationProvider = (WritableJsonConfigurationProvider)GetConfigurationProvider();            
            String jsonText = configurationProvider?.GetSettings()?.ToJson();           
            File.WriteAllText(fileName, jsonText);
        }

    }
}
