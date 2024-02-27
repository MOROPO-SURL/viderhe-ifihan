using MOROPO.VIDERHE.Extend.Common.Overlaying.Presentation.Helpers.Facade;

namespace MOROPO.VIDERHE.Extend.Common.Overlaying.Presentation.Converters
{
    public class TextToAbsoluteLayoutBoundsConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            if (string.IsNullOrEmpty(value.ToString())) return null;

            var textWidthCalculationHelper = Xamarin.Forms.DependencyService.Get<ITextWidthCalculationHelperFacade>();

            var font = Xamarin.Forms.Font.Default;

            if (parameter != null && parameter is Xamarin.Forms.Label)
            {
                var label = (Xamarin.Forms.Label)parameter;

                if (label.FontFamily != null)
                {
                    font = Xamarin.Forms.Font.OfSize(label.FontFamily, label.FontSize);
                }
                else
                {
                    font = Xamarin.Forms.Font.SystemFontOfSize(label.FontSize);
                }
            }

            return new Xamarin.Forms.Rectangle(0, 0, textWidthCalculationHelper.CalculateTextWidth(value.ToString(), font), -1);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}