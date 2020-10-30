[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(SmartSolucionesCuba.Videre.Extend.Common.Templating.Presentation.Views.Rendered.FontOverflowLabel), typeof(SmartSolucionesCuba.Videre.Terminal.Player.UWP.Views.Renderer.FontOverflowLabelRenderer))]

namespace SmartSolucionesCuba.Videre.Terminal.Player.UWP.Views.Renderer
{
    public class FontOverflowLabelRenderer : Xamarin.Forms.Platform.UWP.LabelRenderer
    {
        protected override void OnElementChanged(Xamarin.Forms.Platform.UWP.ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextLineBounds = Windows.UI.Xaml.TextLineBounds.TrimToBaseline;
            }
        }
    }
}
