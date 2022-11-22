// Copyright (c) 2021 Lukin Aleksandr
using Microsoft.Extensions.Configuration;

namespace alg.Types.Configuration;

public interface IConfiguration : IConfigurationRoot
{
    void Save();
}
