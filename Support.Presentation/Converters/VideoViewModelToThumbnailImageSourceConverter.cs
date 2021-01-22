namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Converters
{
    public class VideoViewModelToThumbnailImageSourceConverter : Xamarin.Forms.BindableObject, Xamarin.Forms.IValueConverter
    {
        public static Xamarin.Forms.BindableProperty CloudServerProviderProperty = Xamarin.Forms.BindableProperty.Create(nameof(CloudServerProvider), typeof(Providers.Facade.ICloudServerProviderFacade), typeof(VideoViewModelToThumbnailImageSourceConverter));

        public Providers.Facade.ICloudServerProviderFacade CloudServerProvider
        {
            get { return (Providers.Facade.ICloudServerProviderFacade)GetValue(CloudServerProviderProperty); }
            set { SetValue(CloudServerProviderProperty, value); }
        }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            try
            {
                return Xamarin.Forms.ImageSource.FromUri(Factories.ThumbnailUriFactory.BuildThumbnailUri(CloudServerProvider, (value as Models.View.VideoViewModel).ThumbnailId));
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
