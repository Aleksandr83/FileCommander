// Copyright (c) 2021 Lukin Aleksandr
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Helpers
{
    public class JsonHelper
    {
        public enum Formatting
        {
            None     = 0,
            Indented = 1
        }
        public static String Serialize(object value, Formatting formatting = Formatting.Indented)
        {
            if (value == null)
                return String.Empty;
            return Newtonsoft.Json.JsonConvert
                .SerializeObject(value, GetFormatingType(formatting));
        }

        private static Newtonsoft.Json.Formatting GetFormatingType(Formatting formatting)
        {
            if (formatting == Formatting.Indented)
                return Newtonsoft.Json.Formatting.Indented;
            return Newtonsoft.Json.Formatting.None;
        }

        public static T Deserialize<T>(String json, bool isCreateObjectOnEmpty = false) where T : class
        {
            if (String.IsNullOrEmpty(json.Trim()))                         
                return (isCreateObjectOnEmpty)? Activator.CreateInstance<T>(): null;
            return (T)Newtonsoft.Json.JsonConvert
                .DeserializeObject<T>(json);
        }
       
    }
}
