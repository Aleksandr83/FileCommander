using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agl.Types.Generic;

public class List
{        
    public static IList<T> Empty<T>() => new List<T>();
  
}
