// Copyright (c) 2021 Lukin Aleksandr
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types.Configuration
{    
    internal class SectionValue
    {
        public String[] Value = new String[2] { "", "" };

        public SectionValue()
        {
        }

        public SectionValue(String key, String value)
        {
            SetKey(key);
            SetValue(value);
        }

        public String GetKey() => Value.First();
        public void SetKey(String key)
        {
            Value[0] = key;
        }

        public String GetValue() => Value.Last();
        public void SetValue(String value)
        {
            Value[1] = value;
        }

    }
}
