// Copyright (c) 2021 Lukin Aleksandr
using alg.Services;
using alg.Types.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Services.App;

internal interface IAppService : IService
{
    String GetAppId();
    String GetAppName();
    String GetAppVersion();
    String GetAuthor();
    String GetAuthorEmail();
    String GetLicenseType();
    String GetCopyright();
    String GetConfigurationDataDir();        
    bool   IsExistConfigurationDataDir();
    void   CreateConfigurationDataDir();
    String GetConfigurationFileName();
    String GetConfigurationFile();
    bool   IsExistConfigurationFile();
    void   CreateConfigurationFile();
    void   InitConfiguration();
    IConfiguration? GetConfiguration();
}
