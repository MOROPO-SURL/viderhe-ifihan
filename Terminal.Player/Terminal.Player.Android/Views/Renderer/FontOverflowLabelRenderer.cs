using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Views.Rendered;

[assembly: Xamarin.Forms.ExportRenderer(typeof(FontOverflowLabel), typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Views.Renderer.FontOverflowLabelRenderer))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Views.Renderer
{
    public class FontOverflowLabelRenderer : Xamarin.Forms.Platform.Android.LabelRenderer
    {
        public FontOverflowLabelRenderer(Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Label> e)
        {
            base.OnElementChanged(e);

            Control?.SetIncludeFontPadding(false);
            Control?.SetPadding(0, (int)Android.App.Application.Context.Resources.DisplayMetrics.ScaledDensity * 1, 0, (int)Android.App.Application.Context.Resources.DisplayMetrics.ScaledDensity * 1);
        }
    }
}