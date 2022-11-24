using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Agl.Types.Generic;


public abstract class Tree<T,TypeId> : IEnumerable
{
    protected abstract IEnumerable<T> GetAll();
    protected abstract TypeId GetNodeId(T node);
    protected abstract TypeId GetNodeParentId(T node);
    protected abstract int    CompareNodeId(TypeId id1, TypeId id2);

    protected virtual T? GetNodeById(TypeId id) 
    {           
        var items = GetAll();

        foreach (var item in items)
        {
            if (CompareNodeId(GetNodeId(item),id) == 0)
                return item;
        }

        return default(T);
    }

    protected virtual IEnumerable<T> GetNodesByParentId(TypeId parentId)
    {
        var result = new List<T>();

        var items = GetAll();

        foreach (var item in items)
        {
            if (CompareNodeId(GetNodeParentId(item),parentId) == 0)
                result.Add(item);
        }

        return result;
    }

    protected bool IsNodeDefault(T item)
    {
        if (default(T)?.Equals(item)??false) return true;
        return false;
    }

    public IEnumerator GetEnumerator()
    {
        return GetAll().GetEnumerator();
    }     

    
}