using System;
using System.Threading.Tasks;
using alg.Helpers;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Threading;
using Avalonia.Xaml.Interactivity;
using FileCommander.Services;

namespace FileComander.GUI.Behaviors
{
    public class ListBoxFocusableOnEventBehavior : Behavior<ListBox>
    {
        //AssociatedObject
        const string __SET_FOCUS_FILELIST_EVENT  = EventNames.__SET_FOCUS_FILELIST_EVENT;

        bool _IsAttached = false;

        #region EventManager
        IEventManagerService?       _EventManager;
        IEventManagerService EventManager
        {
            get
            {
                if (_EventManager == null)
                    _EventManager   = BasicServices.GetEventManagerService(); 
                return _EventManager; 
            }
        }
        #endregion EventManager

        #region Constructor
        public ListBoxFocusableOnEventBehavior():base()
        {
            EventManager?.Registred(__SET_FOCUS_FILELIST_EVENT, OnUpdateFocus);
        }
        #endregion Constructor

        protected override void OnAttached()
        {
            base.OnAttached();
            if (AssociatedObject == null) return;

            _IsAttached = true;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject == null) return;

            _IsAttached = false;
        }

        void OnUpdateFocus(object sender, EventArgs e)
        {
            Dispatcher.UIThread.Post(() => UpdateFocus(), DispatcherPriority.Background);
        }

         async Task UpdateFocus()
         {
            if (_IsAttached)
            {
                var listBox = AssociatedObject;
                var item    = listBox.SelectedItem;
                
                if (item != null) 
                {
                    var containers = listBox.ItemContainerGenerator.Containers; //.ContainerFromItem(item);
                    
                    foreach (var container in containers)
                    {
                        if (container.ContainerControl is ListBoxItem)
                        {                            
                            if (container.Item == item)
                                container.ContainerControl.Focus();
                        }
                    }
                }
                
                

            }
         }

        
    }
}