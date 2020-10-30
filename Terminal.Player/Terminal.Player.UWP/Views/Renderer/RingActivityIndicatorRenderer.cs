[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(Xamarin.Forms.ActivityIndicator), typeof(SmartSolucionesCuba.Videre.Terminal.Player.UWP.Views.Renderer.RingActivityIndicatorRenderer))]

namespace SmartSolucionesCuba.Videre.Terminal.Player.UWP.Views.Renderer
{
    public class RingActivityIndicatorRenderer : Xamarin.Forms.Platform.UWP.ViewRenderer<Xamarin.Forms.ActivityIndicator, Microsoft.UI.Xaml.Controls.ProgressRing>
    {
        protected override void OnElementChanged(Xamarin.Forms.Platform.UWP.ElementChangedEventArgs<Xamarin.Forms.ActivityIndicator> eventArgs)
        {
            base.OnElementChanged(eventArgs);

            if (eventArgs.NewElement != null)
            {
                if (Control == null)
                {
                    var control = new Microsoft.UI.Xaml.Controls.ProgressRing
                    {
                        IsActive = Element.IsRunning
                    };

                    SetNativeControl(control);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Xamarin.Forms.ActivityIndicator.IsRunningProperty.PropertyName)
            {
                Control.IsActive = Element.IsRunning;
            }
        }
    }
}
