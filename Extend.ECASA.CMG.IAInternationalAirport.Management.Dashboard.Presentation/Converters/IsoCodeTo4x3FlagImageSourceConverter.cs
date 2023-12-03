namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Converters
{
    public class IsoCodeTo4x3FlagImageSourceConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("http://{0}/images/country-4x3/{1}.svg", Managers.SessionManager.Instance.Server, value.ToString().ToLowerInvariant())));
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
