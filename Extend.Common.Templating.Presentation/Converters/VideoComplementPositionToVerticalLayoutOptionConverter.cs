using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Converters
{
    public class VideoComplementPositionToVerticalLayoutOptionConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var corner = (VideoComplementPosition)value;

            switch (corner)
            {
                case VideoComplementPosition.TopLeft:
                case VideoComplementPosition.TopRight:
                    return Xamarin.Forms.LayoutOptions.Start;

                case VideoComplementPosition.BottomLeft:
                case VideoComplementPosition.BottomRight:
                default:
                    return Xamarin.Forms.LayoutOptions.End;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
