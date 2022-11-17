// Copyright (c) 2021 Lukin Aleksandr
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types.Generic
{
    public class JsonCollection<T> 
    {
        public IList<T> Items { get; set; } = new List<T>();
       
    }
}
