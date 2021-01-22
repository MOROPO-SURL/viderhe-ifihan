namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Converters
{
    public class OverlayDescriptorToStringConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return "<Configuración de la Cuenta>";

            return (value as Extend.Common.Overlaying.Descriptors.IOverlayDescriptor).Name;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
