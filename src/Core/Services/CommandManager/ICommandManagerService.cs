using System;
using System.Threading.Tasks;
using alg.Services;

namespace FileCommander.Services
{
     public interface ICommandManagerService : IService
     {
          
        string CommandRegistration(Action<object> action, string description="", string commandId = "");
        void ExecuteCommandById(string commandId, object? parameter = null);

     }
}