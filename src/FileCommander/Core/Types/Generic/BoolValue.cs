using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Types.Generic;

public class BoolValue : GenericValue<bool>
{        
    public BoolValue(bool value = false) : base(value)
    {                     
    }
   
}