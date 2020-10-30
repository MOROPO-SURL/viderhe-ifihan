[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(SmartSolucionesCuba.Videre.Terminal.Player.Views.Rendered.IndeterminableProgressBarView), typeof(SmartSolucionesCuba.Videre.Terminal.Player.UWP.Views.Renderer.IndeterminableProgressBarViewRenderer))]

namespace SmartSolucionesCuba.Videre.Terminal.Player.UWP.Views.Renderer
{
    public class IndeterminableProgressBarViewRenderer : Xamarin.Forms.Platform.UWP.ProgressBarRenderer
    {
        protected override void OnElementChanged(Xamarin.Forms.Platform.UWP.ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.IsIndeterminate = (Element as Player.Views.Rendered.IndeterminableProgressBarView).IsIndeterminate;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Player.Views.Rendered.IndeterminableProgressBarView.IsIndeterminateProperty.PropertyName)
            {
                Control.IsIndeterminate = (Element as Player.Views.Rendered.IndeterminableProgressBarView).IsIndeterminate;
            }
        }
    }
}
