using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Core.Services.Storages
{
    public abstract class StoragePath : Path, IStoragePath
    {
        public   abstract bool IsRootDirectory();
        public   abstract void Set(UInt32 folderId);
        protected virtual char GetFolderSeparator() => System.IO.Path.DirectorySeparatorChar;

        public UInt32 GetCurrentFolderId() => _CurrentFolderId;

        public override string ToString()
        {
            int i;
            string path = GetRoot();            

            if (Items.Count == 0) return path;

            i = 0;
            foreach (var pathItem in Items)
            {
                path += (i == 0) ? pathItem.Name : GetFolderSeparator() + pathItem.Name;
                i++;
            }

            return path;
        }


        protected UInt32 _CurrentFolderId = 0;
    }
}
