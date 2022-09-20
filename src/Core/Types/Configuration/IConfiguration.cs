// Copyright (c) 2021 Lukin Aleksandr
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types.Configuration
{
    public interface IConfiguration : IConfigurationRoot
    {
        void Save();
    }
}
