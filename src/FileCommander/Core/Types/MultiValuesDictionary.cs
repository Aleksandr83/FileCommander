using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Agl.Types;

public class MultiValuesDictionary<TKey, TValue>
{
    public ICollection<TKey>?   GetKeys() => Items?.Keys;
    public ICollection<TValue>? GetValues(TKey key) => Items?[key];
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

    MultiDictionary<TKey, TValue> Items = new(true);
}
