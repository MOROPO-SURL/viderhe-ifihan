using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Views.Facade;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Converters
{
    public class ThicknessToRelativeValueConverter : Xamarin.Forms.BindableObject, Xamarin.Forms.IValueConverter
    {
        public IRelativeSizeScalableViewFacade SizeScalableView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is Xamarin.Forms.Thickness)) return value;

            var concreteValue = (Xamarin.Forms.Thickness)value;

            var sizeToRelativeValueConverter = new SizeToRelativeValueConverter
            {
                SizeScalableView = SizeScalableView
            };

            return new Xamarin.Forms.Thickness
            (
                (double)sizeToRelativeValueConverter.Convert(concreteValue.Left, typeof(double), null, culture),
                (double)sizeToRelativeValueConverter.Convert(concreteValue.Top, typeof(double), null, culture),
                (double)sizeToRelativeValueConverter.Convert(concreteValue.Right, typeof(double), null, culture),
                (double)sizeToRelativeValueConverter.Convert(concreteValue.Bottom, typeof(double), null, culture)
            );
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
