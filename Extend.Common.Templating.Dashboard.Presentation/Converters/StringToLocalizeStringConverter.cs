namespace MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Converters
{
    public class StringToLocalizeStringConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return LocalizedResources.ResourceManager.GetString(value.ToString(), culture);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
