namespace MOROPO.VIDERHE.Support.Presentation.Converters
{
    public class ImageViewModelToImageSourceConverter : Xamarin.Forms.BindableObject, Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            try
            {
                return Xamarin.Forms.ImageSource.FromUri(Factories.ImageUriFactory.BuildImageUri((value as Models.View.ImageViewModel).Id));
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
