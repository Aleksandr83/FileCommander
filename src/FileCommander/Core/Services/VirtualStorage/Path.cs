using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace VirtualFS
{
    public class Path
    {
        readonly string  __ROOT_DIR  = System.IO.Path.DirectorySeparatorChar.ToString();
        readonly char    __SEPARATOR = System.IO.Path.DirectorySeparatorChar;

        internal struct PathItem
        {
            internal UInt32 Id;
            internal UInt32 Index;
            internal string Name;
            internal UInt32 ParentId;
            
        }

        readonly ObservableCollection<PathItem> _Items = new ObservableCollection<PathItem>();

        public Path()
        {
           _Items.CollectionChanged += new NotifyCollectionChangedEventHandler(OnPathChanged);           
        }

        public void Add(UInt32 id, UInt32 parentId, string name)
        {
            UInt32 index;
                       
            index = (UInt32)_Items.Count;            

            var pathItem = new PathItem(){Id = id, Index = index, ParentId = parentId, Name = name};
            _Items.Add(pathItem);
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

        public void Set(VirtualFS.Path path)
        {
            Clear();

            if (path._Items.Count == 0) return;

            foreach (var item in path._Items)
            {
                _Items.Add(item);
            }
        }      

        public override string ToString()
        {
            int    i;
            string path = __ROOT_DIR;

            if (_Items.Count == 0) return path;

            i = 0;
            foreach (var pathItem in _Items)
            {
                path += (i == 0)? pathItem.Name : __SEPARATOR + pathItem.Name;
                i++;
            }

            return path;
        }

        internal IList GetAll()
        {
            return new List<PathItem>(_Items);
        }

        internal PathItem? First()
        {
            return (_Items.Count == 0)? null : _Items.First();           
        }

        internal PathItem? Last()
        {           
            return (_Items.Count == 0)? null : _Items.Last();
        }

        protected virtual void OnPathChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {

        }
    }
}