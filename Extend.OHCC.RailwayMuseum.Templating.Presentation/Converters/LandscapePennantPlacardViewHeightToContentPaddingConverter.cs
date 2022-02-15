namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Converters
{
    public class LandscapePennantPlacardViewHeightToContentPaddingConverter : Xamarin.Forms.IValueConverter
    {
        public Views.LandscapePennantPlacardView PlacardView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var height = (double)value;

            if (height < 0) return new Xamarin.Forms.Thickness();

            switch ((PlacardView.BindingContext as Models.View.LandscapePennantPlacardViewModel).PennantVerticalOrientation)
            {
                case Enumerations.PennantVerticalOrientation.Top:
                    return new Xamarin.Forms.Thickness(0, height / 20d, 0, 0);

                case Enumerations.PennantVerticalOrientation.Bottom:
                default:
                    return new Xamarin.Forms.Thickness(0, 0, 0, height / 20d);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
