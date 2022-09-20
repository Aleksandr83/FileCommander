using alg.Types;
using FileCommander.Services;

namespace alg.Helpers
{
    public class BasicServices
    {
        public static IEventManagerService GetEventManagerService()
        {
            return (IEventManagerService)ServicesManager
                        .GetService<IEventManagerService>();            
        }     

        public static ILogService GetLogService()
        {
            return (ILogService)ServicesManager
                    .GetService<ILogService>();
        }

    }   
}