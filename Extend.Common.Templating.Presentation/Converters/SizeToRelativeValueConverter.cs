namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Converters
{
    public class SizeToRelativeValueConverter : Xamarin.Forms.BindableObject, Xamarin.Forms.IValueConverter
    {
        private const double RELATIVE_REFERENCE_SIZE = 1920;

        public Views.Contract.IRelativeDimensionScalable RelativeDimensionScalable { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var concreteValue = System.Convert.ToDouble(value);

            if (concreteValue == -1) return concreteValue;

            var applicationPageLargeSize = System.Math.Max(Xamarin.Forms.Application.Current.MainPage.Width, Xamarin.Forms.Application.Current.MainPage.Height);

            if (applicationPageLargeSize == RELATIVE_REFERENCE_SIZE || applicationPageLargeSize <= 0) return concreteValue;

            return concreteValue * applicationPageLargeSize / RELATIVE_REFERENCE_SIZE * (RelativeDimensionScalable?.RelativeDeimensionScaleFactor ?? 1);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw null;
        }
    }
}
