using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Converters
{
    public class VideoComplementPositionToHorizontalLayoutOptionConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var corner = (VideoComplementPosition)value;

            switch (corner)
            {
                case VideoComplementPosition.TopLeft:
                case VideoComplementPosition.BottomLeft:
                    return Xamarin.Forms.LayoutOptions.Start;

                case VideoComplementPosition.TopRight:
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
