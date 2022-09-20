using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace Types.Generic
{
    public class DoubleValue : GenericValue<double>
    {
        #region Constructor
        public DoubleValue(double value = 0.0) : base(value)
        {                     
        }
        #endregion Constructor 
    }

}