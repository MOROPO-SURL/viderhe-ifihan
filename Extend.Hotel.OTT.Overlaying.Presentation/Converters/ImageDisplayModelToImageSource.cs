namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Converters
{
    public class ImageDisplayModelToImageSource : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            var model = value as HIPS.Web.API.Common.Models.ImageDisplayModel;

            return Xamarin.Forms.ImageSource.FromUri(new System.Uri(string.Format("{0}media/images/{1}.{2}", Providers.HIPSAPIHttpClientHelperProvider.Instance.BaseUrl, model.Id, model.Extension)));
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
