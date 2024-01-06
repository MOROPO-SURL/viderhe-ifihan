namespace MOROPO.VIDERHE.Support.Presentation.Converters
{
    public class VideoViewModelToVideoSourceConverter : Xamarin.Forms.BindableObject, Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            try
            {
                return SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Factories.VideoUriFactory.BuildVideoUri((value as Models.View.VideoViewModel).Id, string.Format(".{0}", (value as Models.View.VideoViewModel).Extension.ToLowerInvariant())).AbsoluteUri);
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
