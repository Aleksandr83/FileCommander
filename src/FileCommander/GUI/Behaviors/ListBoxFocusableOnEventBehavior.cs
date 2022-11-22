using System;
using System.Threading.Tasks;
using alg.Helpers;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using Avalonia.Xaml.Interactivity;
using FileCommander.Services;

namespace FileComander.GUI.Behaviors;

public class ListBoxFocusableOnEventBehavior : Behavior<ListBox>
{        
    const string __SET_FOCUS_FILELIST_EVENT  = EventNames.__SET_FOCUS_FILELIST_EVENT; 
    
    
    public ListBoxFocusableOnEventBehavior():base()
    {
        EventManager?.Registred(__SET_FOCUS_FILELIST_EVENT, OnUpdateFocus);
    }
      

    async Task UpdateFocus()
    {
        await Task.Delay(1);

        if (_IsAttached)
        {
            var listBox = AssociatedObject;
            var item = listBox?.SelectedItem;

            if (item != null)
            {
                var containers = listBox?.ItemContainerGenerator.Containers; //.ContainerFromItem(item);

                if (containers != null)
                {
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

    protected override void OnAttached()
    {
        base.OnAttached();
        if (AssociatedObject == null) return;

        AssociatedObject.PointerReleased += OnPointerReleased;
        _IsAttached = true;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        if (AssociatedObject == null) return;

        AssociatedObject.PointerReleased -= OnPointerReleased;
        _IsAttached = false;
    }

    void OnPointerReleased(object? sender, PointerReleasedEventArgs? e)
    {

    }

    void OnUpdateFocus(object sender, EventArgs e)
    {
        //Dispatcher.UIThread.Post(() => UpdateFocus(), DispatcherPriority.Background);
        Dispatcher.UIThread.InvokeAsync(() => UpdateFocus(), DispatcherPriority.Background);
    }

    IEventManagerService? EventManager
    {
        get
        {
            if (_EventManager == null)
                _EventManager = BasicServices.GetEventManagerService();
            return _EventManager;
        }
    }

    private bool _IsAttached = false;
   
    private IEventManagerService? _EventManager;
}