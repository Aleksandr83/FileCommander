using System;

namespace FileCommander.Services
{
    public class EventManagerArgs : EventArgs
    {
        readonly WaitEvent _Event = new WaitEvent();        

        public EventManagerArgs() :base()
        {

        }

        public WaitEvent GetWaitEvent() => _Event;

    }
}