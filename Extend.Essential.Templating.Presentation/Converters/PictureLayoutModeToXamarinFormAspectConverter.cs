using SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Converters
{
    public class PictureLayoutModeToXamarinFormAspectConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var layoutMode = (Enumerations.PictureLayoutMode)value;

            return layoutMode.ToXamarinFormsAspect();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
