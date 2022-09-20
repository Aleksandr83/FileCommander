// Copyright (c) 2021 Lukin Aleksandr
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types.Configuration
{
    internal class JsonConfiguration : IConfiguration
    {
        JsonConfigurationFile _JsonFile;
        IConfigurationRoot    _Configuration;        

        public JsonConfiguration
            (JsonConfigurationFile jsonFile, IConfigurationRoot configuration)
        {
            _JsonFile      = jsonFile;
            _Configuration = configuration;
        }

        private JsonConfigurationFile GetJsonFile() => _JsonFile;

        public string this[string key] { get => _Configuration[key]; set => _Configuration[key] = value; }

        public IEnumerable<Microsoft.Extensions.Configuration.IConfigurationProvider> Providers => _Configuration.Providers;

        public IEnumerable<Microsoft.Extensions.Configuration.IConfigurationSection> GetChildren()
        {
            return _Configuration.GetChildren();
        }

        public IChangeToken GetReloadToken()
        {
            return _Configuration.GetReloadToken();
        }

        public Microsoft.Extensions.Configuration.IConfigurationSection GetSection(string key)
        {
            return _Configuration.GetSection(key);
        }

        public void Reload()
        {
            _Configuration.Reload();
        }        

        public void Save()
        {
            GetJsonFile()?.Save();            
        }

    }
}
