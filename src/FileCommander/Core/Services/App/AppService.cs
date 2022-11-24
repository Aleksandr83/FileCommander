using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Agl.Types.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Services.App;

internal class AppService : IAppService
{
    private const String CONFIG_FILE_NAME    = "config.json";

    JsonConfigurationFile? _ConfigurationFile = null;        

    public String GetAppId()
    {
        String appId = "";
        var attribute = (GuidAttribute?)Assembly
            .GetEntryAssembly()?
            .GetCustomAttributes(typeof(GuidAttribute), true)[0];
        if (attribute != null)
            appId = attribute.Value;
        return (attribute != null)?appId:String.Empty;
    }

    public String GetAppName()
    {
        return Assembly.GetEntryAssembly()?.GetName()?.Name ?? String.Empty;
    }

    public String GetAppVersion()
    {
        return Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString() ?? String.Empty;
    }

    public String GetAuthor()
    {
        return "Lukin Aleksandr";
    }

    public String GetAuthorEmail()
    {
        return "lukin.a.g.spb@gmail.com";
    }

    public String GetLicenseType()
    {
        return "GPL-3.0 License";
    }

    public String GetCopyright()
    {
        var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly()?.Location??String.Empty);
        return versionInfo?.LegalCopyright ?? String.Empty;
    }

    public String GetConfigurationDataDir()
    {
        String configurationDataDir;
        configurationDataDir = Path.Combine
            (
               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
               GetAppName()
            );
        return configurationDataDir;
    }        

    public bool IsExistConfigurationDataDir()
    {
        return Directory.Exists(GetConfigurationDataDir());
    }
    public void CreateConfigurationDataDir()
    {
        if (!IsExistConfigurationDataDir())
            Directory.CreateDirectory(GetConfigurationDataDir());
    }

    public String GetConfigurationFileName() => CONFIG_FILE_NAME;

    public String GetConfigurationFile()
    {
        String configFile;
        configFile = Path.Combine
            (
               GetConfigurationDataDir(),
               CONFIG_FILE_NAME
            );
        return configFile;
    }

    public bool IsExistConfigurationFile()
    {
        return File.Exists(GetConfigurationFile());
    }

    public void CreateConfigurationFile()
    {
        if (_ConfigurationFile != null) return;
        var configurationFileName = GetConfigurationFile();
        var configurationFile = new JsonConfigurationFile(configurationFileName);
        if (!IsExistConfigurationFile())
            configurationFile.Save();
        _ConfigurationFile = configurationFile;
    }

    public void InitConfiguration()
    {            
        CreateConfigurationDataDir();
        CreateConfigurationFile();
        _ConfigurationFile?.InitConfiguration();
    }

   
    public Agl.Types.Configuration.IConfiguration? GetConfiguration() => _ConfigurationFile?.GetConfiguration();
    
}
