using Microsoft.Extensions.Configuration;

namespace Agl.Types.Configuration;

public interface IConfiguration : IConfigurationRoot
{
    void Save();
}
