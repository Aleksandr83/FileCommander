using System.Threading;

namespace FileCommander.Services;

public class WaitEvent
{  
  
    internal void Set()
    {
        _Event.Set();
    }

    public void Wait()
    {
        _Event.WaitOne();
    }

    private ManualResetEvent _Event = new (false);
}