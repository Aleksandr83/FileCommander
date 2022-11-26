using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCommander.Models.FileManagerPanels.FS;

internal interface IFsItem
{
    FileRecord GetValue();
}
