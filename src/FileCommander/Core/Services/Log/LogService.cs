using System.IO;
using Serilog;
using static System.Environment;

namespace FileCommander.Services;

public class LogService : ILogService
{
    const string __DEFAULT_LOG_FILE   = "log.txt";
                    
    public LogService()
    {
        string fullFileName = Path.Combine(__DEFAULT_LOG_FOLDER, __DEFAULT_LOG_FILE);

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.File(fullFileName,rollingInterval: RollingInterval.Day,rollOnFileSizeLimit: true)
            .CreateLogger();        
       
        
        Log.Information("Start Logger");           
    }

    public void Information(string message)
    {
        Log.Information(message);
    }

    public void Information(string message, params object[] args)
    {
        Log.Information(message, args);
    }

    private string __DEFAULT_LOG_FOLDER = System.IO.Path.Combine
                (
                    System.Environment.GetFolderPath(SpecialFolder.UserProfile),
                    ".FileCommander"
                );
}