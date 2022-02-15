namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Converters
{
    public class ImageViewModelToThumbnailImageSourceConverter : Xamarin.Forms.BindableObject, Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            try
            {
                return Xamarin.Forms.ImageSource.FromUri(Factories.ThumbnailUriFactory.BuildThumbnailUri((value as Models.View.ImageViewModel).ThumbnailId));
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
