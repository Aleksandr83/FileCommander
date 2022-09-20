using System;
using System.Threading;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using Avalonia.Controls.ApplicationLifetimes;
using System.Threading.Tasks;
using alg.Helpers;
using System.Collections;

namespace FileCommander.Services
{
    public delegate void EventManagerHandler(object sender, EventArgs e);

    public class EventManagerService : IEventManagerService
    {
        
        struct ThreadState
        {
            public bool IsStop;
            public Queue<EventQueueItem> QueueEvents;
            public MultiDictionary<string, EventManagerHandler> EventHandlers;
            public EventManagerService   EventManager;
        } ;

        struct EventQueueItem
        {
            public Event     SelectedEvent;
            public object    Sender;
            public EventManagerArgs Args;
        };

        Thread       _Thread;
        ThreadState  _ThreadState;
        Queue<EventQueueItem> _QueueEvents;

        Dictionary<string, Event> _Events = new Dictionary<string, Event>();
        MultiDictionary<string, EventManagerHandler> _EventHandlers = new MultiDictionary<string, EventManagerHandler>(true);
        
        #region LogService
        IFileCommanderLogService   _LogService;

        IFileCommanderLogService LogService 
        { 
            get
            {
                if (_LogService == null)
                    _LogService = FileCommanderServices.GetLogService();
                return _LogService;
            }
        }
        #endregion LogService

        public EventManagerService()
        {   
            _ThreadState.IsStop = false;   
            _ThreadState.EventManager  = this;
            _ThreadState.QueueEvents   = _QueueEvents = new Queue<EventQueueItem>();    
            _ThreadState.EventHandlers = _EventHandlers;  
            _Thread = new Thread(EventHandlerExecute);

            _Thread.Start(_ThreadState);
          
            dynamic? currentApp = Avalonia.Application.Current?.ApplicationLifetime;
            IClassicDesktopStyleApplicationLifetime? app = currentApp;

            if (app == null) 
            {
                return;
            }

            app.ShutdownRequested += delegate(object? sender, ShutdownRequestedEventArgs e) 
            {
                _ThreadState.IsStop = true;                
            };
            
        }        

        bool IsExistEventsInQueue(string eventName)
        {
            lock(_QueueEvents)
            {
                foreach (var eventItem in _QueueEvents)
                {
                    if (eventItem.SelectedEvent.Name == eventName)
                        return true;
                }
            }
            return false;
        }

        public Task WaitEmptyEventsInQueue(string eventName)
        {
            var action = new Action(()=>
            {
                string s = eventName;
                while (IsExistEventsInQueue(s)) Thread.Sleep(1);
                LogService.Information("Oueue with events named='{@eventName}' is empty", eventName);
            });

            return Task.Factory.StartNew(action);           
        }

        public void Registred(string eventName, EventManagerHandler? handler = null)
        {
            Event myEvent;
            if (_Events.ContainsKey(eventName))
            {
                myEvent = _Events[eventName];
            } 
            else
            {
                myEvent = new Event(eventName);
                _Events.Add(eventName, myEvent);
            }
            
            if (handler != null)
                _EventHandlers.Add(eventName, handler);
        }

        public void Unregistred(string eventName, EventManagerHandler handler)
        {           
            if (_EventHandlers.ContainsKey(eventName))
            {               
                _EventHandlers.Remove(eventName, handler);
            }
        }        

        public void RaiseEvent(string eventName, object sender, EventManagerArgs args)
        {    
            if (String.IsNullOrEmpty(eventName)) return;                         
            
            if (!_Events.ContainsKey(eventName)) return;  

            lock(_QueueEvents)
            {         
                EventQueueItem item = new EventQueueItem();
                item.SelectedEvent  = _Events[eventName];
                item.Sender = sender;
                item.Args   = args;

                _QueueEvents.Enqueue(item);
            }
        }

        void PushEvent(EventQueueItem eventItem)
        {
            lock(_QueueEvents)
            {
                _QueueEvents.Enqueue(eventItem);
            }
        }

        EventQueueItem PeekEvent()
        {
            EventQueueItem result;

            lock(_QueueEvents)
            {               
                result = _QueueEvents.Peek();
            }

            return result;
        }

        EventQueueItem PopEvent()
        {
            EventQueueItem result;

            lock(_QueueEvents)
            {               
                result = _QueueEvents.Dequeue();
            }

            return result;
        }

        UInt32 GetEventsCount()
        {
            UInt32 result;
            lock(_QueueEvents)
            {
                result = (UInt32)_QueueEvents.Count;
            }
            return result;
        } 

        static void EventHandlerExecute(object data)
        {
            ThreadState state = (ThreadState)data;            
            
            for (;;)
            {
                var eventManager = state.EventManager;

                state = eventManager._ThreadState;

                Thread.Sleep(10);                
                if (state.IsStop) break;
               
                if (eventManager.GetEventsCount() == 0) continue;
                do
                {
                    if (state.IsStop) break;                    
                    var selectedItem  = eventManager.PeekEvent();           
                    var selectedEvent = selectedItem.SelectedEvent;

                    if (!state.EventHandlers.ContainsKey(selectedEvent.Name)) 
                    {                        
                        eventManager.PushEvent(selectedItem);
                        eventManager.PopEvent();
                        Thread.Sleep(100);
                        continue;
                    }

                    var items = new List<EventManagerHandler>(state.EventHandlers[selectedEvent.Name]);
                    
                     foreach (var item in items)
                     {
                         item.Invoke(selectedItem.Sender, selectedItem.Args);
                     }

                     selectedItem.Args.GetWaitEvent().Set();
                     eventManager.PopEvent();

                }
                while (state.QueueEvents.Count != 0);                
            }
        }

        ~EventManagerService()
        {
            _ThreadState.IsStop = true;
            _Thread.Join();
        }

    }
}