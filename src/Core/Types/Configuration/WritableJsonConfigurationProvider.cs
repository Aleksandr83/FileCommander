// Copyright (c) 2021 Lukin Aleksandr
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types.Configuration
{
    internal class WritableJsonConfigurationProvider    
        : JsonConfigurationProvider
    {
        public const char SECTION_SEPARATOR = ':';

        private JsonSettings _Settings = new JsonSettings();

        public JsonSettings GetSettings() => _Settings;

        public WritableJsonConfigurationProvider(JsonConfigurationSource source)
            : base(source)
        {          
        }

        public override void Load(Stream stream)
        {            
            var settings  = JsonConfigurationFileParser.Parse(stream);
            base.Data = settings.ToDictionary(SECTION_SEPARATOR);
        }

        public override void Set(string key, string value)
        {
            base.Set(key, value);            
            var fileFullPath = base.Source.FileProvider.GetFileInfo(base.Source.Path).PhysicalPath;
            String json = File.ReadAllText(fileFullPath);
            var sectionName   = key.Split(SECTION_SEPARATOR)?.First()?.Trim();
            var parameterName = key.Split(SECTION_SEPARATOR)?.Last()?.Trim();

            var settings = GetSettings();
            var section  = settings?.GetSectionByName(sectionName);
            if (section == null)
                section  = settings.Add(new SectionBlock() { Section = sectionName });
            section.SetValue(parameterName, value);            
        }

    }
}
