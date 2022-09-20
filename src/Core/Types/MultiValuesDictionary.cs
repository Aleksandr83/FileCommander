// Copyright (c) 2021 Lukin Aleksandr
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace alg.Types
{
    public class MultiValuesDictionary<TKey, TValue>
    {
        MultiDictionary<TKey, TValue> Items = 
            new MultiDictionary<TKey, TValue>(true);

        public ICollection<TKey>   GetKeys() => Items?.Keys;
        public ICollection<TValue> GetValues(TKey key) => Items?[key];
        public bool IsContainsKey(TKey key) => Items?.ContainsKey(key) ?? false;

        public void Add(TKey key, TValue value)
        {
            Items?.Add(key, value);
        }

        public bool Remove(TKey key) => Items?.Remove(key) ?? false;

        public void Clear()
        {
            Items?.Clear();
        }
    }
}
