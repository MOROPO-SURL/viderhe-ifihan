namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Presentation.Converters
{
    public class AmbientalReadingDisplayModelToLastValuePresentationConverter : Xamarin.Forms.IValueConverter
    {
        public Views.AmbientalDashboardPlacardView PlacardView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return "...";

            var concreteValue = value as MOROPO.UIC.IoTPlatform.Interop.Sync.Receptor.API.Common.Models.AmbientalReadingDisplayModel;

            switch ((PlacardView.BindingContext as Models.View.AmbientalDashboardPlacardViewModel).AmbientalVariable)
            {
                case Enumerations.AmbientalVariable.Humidity:
                    return string.Format("{0}%", concreteValue.Humidity);

                case Enumerations.AmbientalVariable.SmogPPM:
                    return string.Format("{0} ppm", concreteValue.SmogPPM);

                case Enumerations.AmbientalVariable.Temperature:
                default:
                    return string.Format("{0}°C", concreteValue.Temperature);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
