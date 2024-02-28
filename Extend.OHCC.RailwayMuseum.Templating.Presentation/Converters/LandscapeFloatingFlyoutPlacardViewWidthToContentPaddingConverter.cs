namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Converters
{
    public class LandscapeFloatingFlyoutPlacardViewWidthToContentPaddingConverter : Xamarin.Forms.IValueConverter
    {
        public Views.LandscapeFloatingFlyoutPlacardView PlacardView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var width = (double)value;

            if (width < 0) return new Xamarin.Forms.Thickness();

            var concreteBindingContext = PlacardView.BindingContext as Models.View.LandscapeFloatingFlyoutPlacardViewModel;

            var invertedPadding = concreteBindingContext.FlyoutShapeKind == Enumerations.FlyoutShapeKind.Train ? width / 33d : 0;

            switch (concreteBindingContext.FlyoutHorizontalOrientation)
            {
                case Enumerations.FlyoutHorizontalOrientation.Left:
                    return new Xamarin.Forms.Thickness(width / 25d, 0, 0, invertedPadding);

                case Enumerations.FlyoutHorizontalOrientation.Right:
                default:
                    return new Xamarin.Forms.Thickness(invertedPadding, 0, width / 25d, 0);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
