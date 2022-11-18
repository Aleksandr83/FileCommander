using System;
using alg.Behaviors;
using alg.Helpers;
using Avalonia.Controls;
using FileCommander.Services;
using VirtualFS;

namespace FileComander.GUI.Behaviors
{
    public class ListBoxDoubleClickBehavior : ControlDoubleClickBehavior<ListBox>
    {
        const string __DBL_CLICK_FILE_LST_EVENT = EventNames.__DBL_CLICK_FILE_LST_EVENT;

        #region EventManager
        IEventManagerService?       _EventManager;
        IEventManagerService? EventManager
        {
            get
            {
                if (_EventManager == null)
                    _EventManager   = BasicServices.GetEventManagerService(); 
                return _EventManager; 
            }
        }
        #endregion EventManager

        public ListBoxDoubleClickBehavior() : base()
        {
            EventManager?.Registred(__DBL_CLICK_FILE_LST_EVENT); 
        }

        protected override void OnDoubleClick(object? sender)
        {          
            if (sender == null) sender = new ();
            EventManager?.RaiseEvent(__DBL_CLICK_FILE_LST_EVENT, sender, new EventManagerArgs());
        }
    }

}