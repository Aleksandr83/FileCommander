﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agl.Types.Configuration;

internal class SectionBlock   
{       
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

    public string Section { get; set; } = String.Empty;
    public List<SectionValue> Values { get; private set; } = new();
}
