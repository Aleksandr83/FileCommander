using alg.Services;

namespace FileCommander.Services
{
    public interface ILogService : IService
    {
        void Information(string message);
        void Information(string message, params object[] args);
    }
}