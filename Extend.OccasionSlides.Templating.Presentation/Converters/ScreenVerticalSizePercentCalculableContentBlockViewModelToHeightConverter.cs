using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block.Contract;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Converters
{
    public class ScreenVerticalSizePercentCalculableContentBlockViewModelToHeightConverter : Xamarin.Forms.IValueConverter
    {
        public Common.Templating.Presentation.Views.Facade.IRelativeSizeScalableViewFacade SizeScalableView { get; set; }

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || !(value is IScreenVerticalSizePercentCalculableContentBlockViewModel)) return -1;

            var target = value as IScreenVerticalSizePercentCalculableContentBlockViewModel;

            return Xamarin.Forms.Application.Current.MainPage.Height * target.HeightByScreenVerticalSizePercent / 100 * (SizeScalableView?.RelativeSizeScaleFactor ?? 1);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
