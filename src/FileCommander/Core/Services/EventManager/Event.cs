using System;

namespace FileCommander.Services
{
    public class Event
    {       
        public Event(string eventName)
        {
            Name = eventName;
        }

        public string Name { get; }
    }
}