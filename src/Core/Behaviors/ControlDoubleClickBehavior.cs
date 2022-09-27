using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Xaml.Interactivity;
using FileCommander.Services;

namespace alg.Behaviors
{

public class ControlDoubleClickBehavior<T> : Behavior<T> where T : Control
{
    const int __DOUBLE_CLICK_TIMEOUT_SEC = 3; 

    struct LastPointerClickData
         {
            internal object?     lastItem;
            internal DateTime    lastTime;
         }

    LastPointerClickData _LastPointerClickData = new LastPointerClickData();

    public ControlDoubleClickBehavior()
    {

    }

    protected override void OnAttached()
        {
            base.OnAttached();
            if (AssociatedObject == null) return;

            AssociatedObject.PointerReleased += OnPointerReleased;           
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (AssociatedObject == null) return;

            AssociatedObject.PointerReleased -= OnPointerReleased;            
        }

        void OnPointerReleased(object? sender, PointerReleasedEventArgs? e)
        {                   
            dynamic? source   = sender;        
            dynamic? captured = e?.Pointer?.Captured;
                  
            dynamic? content  = captured?.DataContext;
           
            if (_LastPointerClickData.lastItem != null)
            {                    
                if (e?.InitialPressMouseButton == MouseButton.Left)
                if (_LastPointerClickData.lastItem == content)
                {
                    var timeSpan = DateTime.Now
                                    .Subtract(_LastPointerClickData.lastTime)
                                    .Seconds;
                    
                    if (timeSpan < __DOUBLE_CLICK_TIMEOUT_SEC)
                    {                        
                        OnDoubleClick(content);

                        _LastPointerClickData.lastItem = null;
                        return;
                    }
                }
            }

            _LastPointerClickData.lastItem = content;
            _LastPointerClickData.lastTime = DateTime.Now;
        }

        protected virtual void OnDoubleClick(object? sender)
        {
            
        }

}

}