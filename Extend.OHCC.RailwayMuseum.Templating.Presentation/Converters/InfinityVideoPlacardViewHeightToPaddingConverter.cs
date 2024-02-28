using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Converters
{
    public class InfinityVideoPlacardViewHeightToPaddingConverter : Xamarin.Forms.IValueConverter
    {
        public Views.InfinityVideoPlacardView PlacardView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var height = (double)value;

            if (height < 0) return new Xamarin.Forms.Thickness();

            var concreteBindingContext = PlacardView.BindingContext as InfinityVideoPlacardViewModel;

            if (concreteBindingContext.StartMargin > 0 || concreteBindingContext.EndMargin > 0)
            {
                switch (Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation)
                {
                    case Xamarin.Essentials.DisplayOrientation.Landscape:
                        return new Xamarin.Forms.Thickness(PlacardView.Width * concreteBindingContext.StartMargin / 100d, 0, PlacardView.Width * concreteBindingContext.EndMargin / 100d, 0);

                    case Xamarin.Essentials.DisplayOrientation.Portrait:
                        return new Xamarin.Forms.Thickness(0, PlacardView.Height * concreteBindingContext.StartMargin / 100d, 0, PlacardView.Height * concreteBindingContext.EndMargin / 100d);

                    default:
                        break;
                }
            }

            return new Xamarin.Forms.Thickness();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
