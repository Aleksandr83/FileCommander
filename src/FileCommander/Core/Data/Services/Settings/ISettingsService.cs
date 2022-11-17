// Copyright (c) 2021 Lukin Aleksandr
using alg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Services.Settings
{
    public interface ISettingsService:IService
    {
        string GetStringValue(String section, String parameterName,String defaultValue = "");
        void   SetStringValue(String section, String parameterName,String value = ""); 
        bool   GetBoolValue(String section, String parameterName, bool defaultValue = false);
        void   SetBoolValue(String section, String parameterName, bool value = false);
        int    GetIntValue(String section, String parameterName, int defaultValue = 0);

        void   Save();
    }
}
