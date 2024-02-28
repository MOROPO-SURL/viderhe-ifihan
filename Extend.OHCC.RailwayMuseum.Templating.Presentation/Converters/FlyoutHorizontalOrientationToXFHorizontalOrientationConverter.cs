namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Converters
{
    public class FlyoutHorizontalOrientationToXFHorizontalOrientationConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((Enumerations.FlyoutHorizontalOrientation)value)
            {
                case Enumerations.FlyoutHorizontalOrientation.Left:
                    return Xamarin.Forms.LayoutOptions.Start;

                case Enumerations.FlyoutHorizontalOrientation.Right:
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
