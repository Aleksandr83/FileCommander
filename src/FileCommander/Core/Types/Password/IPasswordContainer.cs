// Copyright (c) 2021 Lukin Aleksandr
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types
{
    public interface IPasswordContainer
    {
        String GetPassword();
        void   SetPassword(String password);
        String ToJson();
    }
}
