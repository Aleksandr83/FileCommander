using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Types.Generic
{
    public class IntValue : GenericValue<int>
    {
        #region Constructor
        public IntValue(int value = 0) : base(value)
        {                     
        }
        #endregion Constructor 
    }

}