namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Converters
{
    public class VideoViewModelToVideoSourceConverter : Xamarin.Forms.BindableObject, Xamarin.Forms.IValueConverter
    {
        public static Xamarin.Forms.BindableProperty CloudServerProviderProperty = Xamarin.Forms.BindableProperty.Create(nameof(CloudServerProvider), typeof(Providers.Facade.ICloudServerProviderFacade), typeof(VideoViewModelToVideoSourceConverter));

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
                return XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Factories.VideoUriFactory.BuildVideoUri(CloudServerProvider, (value as Models.View.VideoViewModel).Id, string.Format(".{0}",(value as Models.View.VideoViewModel).Extension.ToLowerInvariant())).AbsoluteUri);
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
