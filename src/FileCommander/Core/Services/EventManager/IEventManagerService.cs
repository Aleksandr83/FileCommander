using System;
using System.Threading.Tasks;
using alg.Services;

namespace FileCommander.Services;

public interface IEventManagerService : IService
{
    
    void Registred(string eventName, EventManagerHandler? handler = null);
    void Unregistred(string eventName, EventManagerHandler handler);
    void RaiseEvent(string eventName, object sender, EventManagerArgs args);


    Task WaitEmptyEventsInQueue(string eventName);
}