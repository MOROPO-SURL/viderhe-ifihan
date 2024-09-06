using System.Linq;
using Windows.UI.Xaml.Input;

[assembly: Xamarin.Forms.ResolutionGroupName("XFToolKit")]
[assembly: Xamarin.Forms.ExportEffect(typeof(MOROPO.VIDERHE.Terminal.Dashboard.UWP.Effects.NativeTouchEffect), "TouchEffect")]

namespace MOROPO.VIDERHE.Terminal.Dashboard.UWP.Effects
{
    public class NativeTouchEffect : Xamarin.Forms.Platform.UWP.PlatformEffect
    {
        private Windows.UI.Xaml.FrameworkElement frameworkElement;
        private Support.Presentation.Dashboard.Effects.TouchEffect effect;
        private System.Action<Xamarin.Forms.Element, Support.Presentation.Dashboard.Delegates.TouchActionEventArgs> onTouchAction;

        protected override void OnAttached()
        {
            // Get the Windows FrameworkElement corresponding to the Element that the effect is attached to
            frameworkElement = Control == null ? Container : Control;

            // Get access to the TouchEffect class in the .NET Standard library
            effect = (Support.Presentation.Dashboard.Effects.TouchEffect)Element.Effects.FirstOrDefault(e => e is Support.Presentation.Dashboard.Effects.TouchEffect);

            if (effect != null && frameworkElement != null)
            {
                // Save the method to call on touch events
                onTouchAction = effect.OnTouchAction;

                // Set event handlers on FrameworkElement
                frameworkElement.PointerEntered += OnPointerEntered;
                frameworkElement.PointerPressed += OnPointerPressed;
                frameworkElement.PointerMoved += OnPointerMoved;
                frameworkElement.PointerReleased += OnPointerReleased;
                frameworkElement.PointerExited += OnPointerExited;
                frameworkElement.PointerCanceled += OnPointerCancelled;
            }
        }

        protected override void OnDetached()
        {
            if (onTouchAction != null)
            {
                // Release event handlers on FrameworkElement
                frameworkElement.PointerEntered -= OnPointerEntered;
                frameworkElement.PointerPressed -= OnPointerPressed;
                frameworkElement.PointerMoved -= OnPointerMoved;
                frameworkElement.PointerReleased -= OnPointerReleased;
                frameworkElement.PointerExited -= OnPointerEntered;
                frameworkElement.PointerCanceled -= OnPointerCancelled;
            }
        }

        void OnPointerEntered(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, Support.Presentation.Dashboard.Enumerations.TouchActionKind.Entered, args);
        }

        void OnPointerPressed(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, Support.Presentation.Dashboard.Enumerations.TouchActionKind.Pressed, args);

            // Check setting of Capture property
            if (effect.Capture)
            {
                (sender as Windows.UI.Xaml.FrameworkElement).CapturePointer(args.Pointer);
            }
        }

        void OnPointerMoved(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, Support.Presentation.Dashboard.Enumerations.TouchActionKind.Moved, args);
        }

        void OnPointerReleased(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, Support.Presentation.Dashboard.Enumerations.TouchActionKind.Released, args);
        }

        void OnPointerExited(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, Support.Presentation.Dashboard.Enumerations.TouchActionKind.Exited, args);
        }

        void OnPointerCancelled(object sender, PointerRoutedEventArgs args)
        {
            CommonHandler(sender, Support.Presentation.Dashboard.Enumerations.TouchActionKind.Cancelled, args);
        }

        void CommonHandler(object sender, Support.Presentation.Dashboard.Enumerations.TouchActionKind touchActionType, PointerRoutedEventArgs args)
        {
            var pointerPoint = args.GetCurrentPoint(sender as Windows.UI.Xaml.UIElement);

            var windowsPoint = pointerPoint.Position;

            onTouchAction(Element, new Support.Presentation.Dashboard.Delegates.TouchActionEventArgs(args.Pointer.PointerId, touchActionType, new Xamarin.Forms.Point(windowsPoint.X, windowsPoint.Y), args.Pointer.IsInContact));
        }
    }
}
