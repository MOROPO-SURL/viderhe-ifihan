using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.Views.Rendered.IndeterminableProgressBarView), typeof(SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Views.Renderer.IndeterminableProgressBarViewRenderer))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Droid.Views.Renderer
{
    public class IndeterminableProgressBarViewRenderer : ProgressBarRenderer
    {
        public IndeterminableProgressBarViewRenderer(Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                {
                    //var drawable = (Android.Graphics.Drawables.LayerDrawable)Control.IndeterminateDrawable.Mutate();
                    ////var drawable = Android.Support.V4.Graphics.Drawable.DrawableCompat.Wrap(Control.IndeterminateDrawable);

                    ////Android.Support.V4.Graphics.Drawable.DrawableCompat.SetTint(drawable, Element.ProgressColor.ToAndroid());

                    //drawable.fin

                    //drawable.SetColorFilter(Element.ProgressColor.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);

                    Control.IndeterminateDrawable.SetColorFilter(new Android.Graphics.PorterDuffColorFilter(Element.ProgressColor.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn));
                }
                else
                {
                    Control.IndeterminateTintList = Android.Content.Res.ColorStateList.ValueOf(Element.ProgressColor.ToAndroid());
                }

                Control.Indeterminate = (Element as Player.Views.Rendered.IndeterminableProgressBarView).IsIndeterminate;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Player.Views.Rendered.IndeterminableProgressBarView.IsIndeterminateProperty.PropertyName)
            {
                Control.Indeterminate = (Element as Player.Views.Rendered.IndeterminableProgressBarView).IsIndeterminate;
            }
        }
    }
}