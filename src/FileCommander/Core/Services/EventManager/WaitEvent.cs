using System.Threading;

namespace FileCommander.Services
{
    public class WaitEvent
    {
        ManualResetEvent _Event = new ManualResetEvent(false);
      
        internal void Set()
        {
            _Event.Set();
        }

        public void Wait()
        {
            _Event.WaitOne();
        }
    }
}