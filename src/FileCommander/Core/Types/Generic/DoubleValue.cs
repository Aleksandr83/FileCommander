using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Agl.Types.Generic;

public class DoubleValue : GenericValue<double>
{   
    public DoubleValue(double value = 0.0) : base(value)
    {                     
    }
    
}