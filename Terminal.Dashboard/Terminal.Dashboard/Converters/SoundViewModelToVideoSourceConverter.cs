namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Converters
{
    partial class SoundViewModelToVideoSourceConverter : Xamarin.Forms.BindableObject, Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            try
            {
                return XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.SoundUriFactory.BuildUri((value as Support.Presentation.Dashboard.Models.View.SoundViewModel).Id, string.Format(".{0}", (value as Support.Presentation.Dashboard.Models.View.SoundViewModel).Extension.ToLowerInvariant())).AbsoluteUri);
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
