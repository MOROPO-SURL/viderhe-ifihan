namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Converters
{
    public class ImageViewModelToImageSourceConverter : Xamarin.Forms.BindableObject, Xamarin.Forms.IValueConverter
    {
        public static Xamarin.Forms.BindableProperty CloudServerProviderProperty = Xamarin.Forms.BindableProperty.Create(nameof(CloudServerProvider), typeof(Providers.Facade.ICloudServerProviderFacade), typeof(ImageViewModelToImageSourceConverter));

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
                return Xamarin.Forms.ImageSource.FromUri(Factories.ImageUriFactory.BuildImageUri(CloudServerProvider, (value as Models.View.ImageViewModel).Id));
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
