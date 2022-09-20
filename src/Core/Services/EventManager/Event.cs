using System;

namespace FileCommander.Services
{
    public class Event
    {        
        public string Name    { get; }

        public Event(string eventName)
        {
            Name = eventName;
        }
    }
}