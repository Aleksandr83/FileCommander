using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Xaml.Interactivity;

namespace alg.Behaviors
{
public class HidePointeroverBehavior : Behavior<Control>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        if (AssociatedObject == null) return;

        AssociatedObject.PointerEnter += OnPointerEnter;        
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        if (AssociatedObject == null) return;

        AssociatedObject.PointerEnter -= OnPointerEnter;
        
    }

     private void OnPointerEnter(object? sender, PointerEventArgs e)
     {
        //AssociatedObject.PointerPressed
     }
}

}