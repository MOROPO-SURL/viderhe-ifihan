namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Converters
{
    public class IsAspectFitWithOpaqueAspectFilledBySelfPictureLayoutModeToBooleanConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var layoutMode = (Enumerations.PictureLayoutMode)value;

            return layoutMode == Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
