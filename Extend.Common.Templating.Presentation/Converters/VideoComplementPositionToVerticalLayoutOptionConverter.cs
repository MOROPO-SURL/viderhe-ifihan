namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Converters
{
    public class VideoComplementPositionToVerticalLayoutOptionConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var corner = (Enumerations.VideoComplementPosition)value;

            switch (corner)
            {
                case Enumerations.VideoComplementPosition.TopLeft:
                case Enumerations.VideoComplementPosition.TopRight:
                    return Xamarin.Forms.LayoutOptions.Start;

                case Enumerations.VideoComplementPosition.BottomLeft:
                case Enumerations.VideoComplementPosition.BottomRight:
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
