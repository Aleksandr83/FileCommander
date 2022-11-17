using Avalonia;
using Avalonia.Controls;
using Avalonia.Xaml.Interactivity;

namespace alg.Behaviors
{

public class FocusOnPropertyChangedBehavior : Behavior<Control>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        if (AssociatedObject == null) return;

        AssociatedObject.PropertyChanged += FocuseControl;
    }
    protected override void OnDetaching()
    {
        base.OnDetaching();
        if (AssociatedObject == null) return;

        AssociatedObject.PropertyChanged -= FocuseControl;
    }
    private void FocuseControl(object? sender, AvaloniaPropertyChangedEventArgs e)
    {      
        if (AssociatedObject != null && !AssociatedObject.IsFocused) 
            AssociatedObject.Focus();
    }
}

}