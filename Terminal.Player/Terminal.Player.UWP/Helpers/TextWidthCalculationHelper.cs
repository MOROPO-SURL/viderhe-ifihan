using Xamarin.Forms.Platform.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(MOROPO.VIDERHE.Terminal.Player.UWP.Helpers.TextWidthCalculationHelper))]

namespace MOROPO.VIDERHE.Terminal.Player.UWP.Helpers
{
    public class TextWidthCalculationHelper : Extend.Common.Overlaying.Presentation.Helpers.Facade.ITextWidthCalculationHelperFacade
    {
        public double CalculateTextWidth(string text, Xamarin.Forms.Font font)
        {
            var textBlock = new Windows.UI.Xaml.Controls.TextBlock();

            textBlock.ApplyFont(font);
            textBlock.Text = text;

            textBlock.MaxWidth = double.PositiveInfinity;

            textBlock.TextWrapping = Windows.UI.Xaml.TextWrapping.NoWrap;

            var parentBorder = new Windows.UI.Xaml.Controls.Border { Child = textBlock };

            parentBorder.Measure(new Windows.Foundation.Size(textBlock.MaxWidth, textBlock.MaxHeight));
            parentBorder.Child = null;

            return parentBorder.DesiredSize.Width;
        }
    }
}
