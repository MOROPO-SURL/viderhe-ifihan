using SmartSolucionesCuba.Viderhe.Support.Presentation.Models.View;

namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Converters
{
    public class SoundViewModelToVideoSourceConverter : Xamarin.Forms.BindableObject, Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return value;

            try
            {
                return Factories.SoundUriFactory.BuildUri((value as SoundViewModel).Id, string.Format(".{0}", (value as SoundViewModel).Extension.ToLowerInvariant())).AbsoluteUri;
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