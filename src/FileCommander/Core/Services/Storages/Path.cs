using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Core.Services.Storages;

public abstract class Path 
{

    public Path()
    {
        _Items.CollectionChanged += new NotifyCollectionChangedEventHandler(OnPathChanged);           
    }

    public    abstract string GetRoot();
       
    public void Add(UInt32 id, UInt32 parentId, string name)
    {
        UInt32 index;

        index = (UInt32)_Items.Count;

        var pathItem = new PathItem() { Id = id, Index = index, ParentId = parentId, Name = name };
        _Items.Add(pathItem);
    }

    public void Set(Path path)
    {
        Clear();

        if (path._Items.Count == 0) return;

        foreach (var item in path._Items)
        {
            _Items.Add(item);
        }
    }

    public virtual void Clear()
    {
        if (_Items.Count > 0) _Items.Clear();
    }

    public virtual void RemoveLast()
    {
        if (_Items.Count == 0) return;

        _Items.RemoveAt(_Items.Count - 1);
    }

    public IList GetAll() => new List<PathItem>(_Items);    

    public PathItem? First()
    {
        return (_Items.Count == 0) ? null : _Items.First();
    }

    public PathItem? Last()
    {
        return (_Items.Count == 0) ? null : _Items.Last();
    }

    

    protected virtual void OnPathChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {

    }

    protected ObservableCollection<PathItem> Items => _Items;

    readonly  ObservableCollection<PathItem> _Items = new();

    public struct PathItem
    {
        internal UInt32 Id;
        internal UInt32 Index;
        internal string Name;
        internal UInt32 ParentId;
    }
}
