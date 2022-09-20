using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Types.Generic
{
    public class UIntValue : GenericValue<uint>
    {
        #region Constructor
        public UIntValue(uint value = 0) : base(value)
        {                     
        }
        #endregion Constructor 
    }

}