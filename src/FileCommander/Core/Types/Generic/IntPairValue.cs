using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Types.Generic;

public class IntPairValue : PairGenericValue<string,int>
{              
    public IntPairValue(int value) : base(value, value.ToString())
    {                     
    }            
   
    protected override void OnChangeNewValue(string? value)
    {          
        int result; 
        if (!IsInit) return;
        
        if (int.TryParse(value, out result))
        {
            Value = result;
        }
    }
}