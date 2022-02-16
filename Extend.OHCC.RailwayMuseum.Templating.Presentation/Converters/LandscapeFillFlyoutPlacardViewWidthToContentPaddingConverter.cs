namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Converters
{
    public class LandscapeFillFlyoutPlacardViewWidthToContentPaddingConverter : Xamarin.Forms.IValueConverter
    {
        public Views.LandscapeFillFlyoutPlacardView PlacardView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var width = (double)value;

            if (width < 0) return new Xamarin.Forms.Thickness();

            var concreteBindingContext = PlacardView.BindingContext as Models.View.LandscapeFillFlyoutPlacardViewModel;

            var padding = width / 25d;

            var invertedPadding = concreteBindingContext.FlyoutShapeKind == Enumerations.FlyoutShapeKind.Tally ? width / 33d : 0;

            switch (concreteBindingContext.FlyoutHorizontalOrientation)
            {
                case Enumerations.FlyoutHorizontalOrientation.Left:
                    return new Xamarin.Forms.Thickness(padding, padding, invertedPadding, padding + invertedPadding);

                case Enumerations.FlyoutHorizontalOrientation.Right:
                default:
                    return new Xamarin.Forms.Thickness(invertedPadding, padding, padding, padding + invertedPadding);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
