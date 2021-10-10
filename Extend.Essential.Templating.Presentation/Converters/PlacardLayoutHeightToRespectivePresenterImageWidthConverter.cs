namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Converters
{
    public class PlacardLayoutHeightToRespectivePresenterImageWidthConverter : Xamarin.Forms.IValueConverter
    {
        public Xamarin.Forms.Layout<Xamarin.Forms.View> PlacardLayout { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            var height = (double)value;

            if (height < 0) return null;

            var model = PlacardLayout.BindingContext as Models.View.Facade.IPresentedByImagePlacardViewModelFacade;

            return PlacardLayout.Height * model.PresenterImageWidth / model.PresenterImageHeigth;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}