// Copyright (c) 2021 Lukin Aleksandr
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types
{
    public interface IPassword
    {
        String GetValue();
        void   SetValue(String value);
        void   LoadEncodeString(String encodePassword);
        String GetEncodeString();
    }
}
