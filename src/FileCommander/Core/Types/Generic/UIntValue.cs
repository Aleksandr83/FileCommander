using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Agl.Types.Generic;

public class UIntValue : GenericValue<uint>
{    
    public UIntValue(uint value = 0) : base(value)
    {                     
    }
    
}