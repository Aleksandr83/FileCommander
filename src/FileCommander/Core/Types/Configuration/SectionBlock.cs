// Copyright (c) 2021 Lukin Aleksandr
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types.Configuration
{
    internal class SectionBlock   
    {
        public string Section { get; set; }

        public List<SectionValue> Values { get; private set; }
                = new List<SectionValue>();

        public void SetValue(String key, String value)
        {
            foreach (var item in Values)
            {
                if (item.GetKey() == key)
                {
                    item.SetValue(value);
                    return;
                }
            }
            Values.Add(new SectionValue(key, value));
        }
    }
}
