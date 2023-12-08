[assembly: Xamarin.Forms.Dependency(typeof(MOROPO.VIDERHE.Terminal.Player.Droid.Helpers.TextWidthCalculationHelper))]

namespace MOROPO.VIDERHE.Terminal.Player.Droid.Helpers
{
    public class TextWidthCalculationHelper : Extend.Common.Overlaying.Presentation.Helpers.Facade.ITextWidthCalculationHelperFacade
    {
        public double CalculateTextWidth(string text, Xamarin.Forms.Font font)
        {
            var bounds = new Android.Graphics.Rect();

            var textView = new Android.Widget.TextView(Android.App.Application.Context)
            {
                TextSize = (float)(font.UseNamedSize ? Xamarin.Forms.Device.GetNamedSize(font.NamedSize, typeof(Xamarin.Forms.Label)) : font.FontSize)
            };

            textView.Paint.GetTextBounds(text, 0, text.Length, bounds);

            return bounds.Width() / Android.Content.Res.Resources.System.DisplayMetrics.ScaledDensity;
        }
    }
}