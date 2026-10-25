[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(MOROPO.VIDERHE.Terminal.Player.Views.Rendered.IndeterminableProgressBarView), typeof(MOROPO.VIDERHE.Terminal.Player.UWP.Views.Renderer.IndeterminableProgressBarViewRenderer))]

namespace MOROPO.VIDERHE.Terminal.Player.UWP.Views.Renderer
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
