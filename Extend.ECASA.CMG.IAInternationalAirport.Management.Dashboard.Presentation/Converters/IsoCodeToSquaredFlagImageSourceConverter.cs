namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Converters
{
    public class IsoCodeToSquaredFlagImageSourceConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("http://{0}/images/country-squared/{1}.svg", Managers.SessionManager.Instance.Server, value.ToString().ToLowerInvariant())));
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
