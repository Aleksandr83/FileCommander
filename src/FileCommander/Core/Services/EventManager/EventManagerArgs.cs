using System;

namespace FileCommander.Services
{
    public class EventManagerArgs : EventArgs
    {              

        public EventManagerArgs() :base()
        {

        }

        public   WaitEvent GetWaitEvent() => _Event;

        readonly WaitEvent _Event = new ();

    }
}