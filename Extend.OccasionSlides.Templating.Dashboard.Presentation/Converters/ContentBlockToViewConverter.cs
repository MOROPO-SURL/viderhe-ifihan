using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Converters
{
    public class ContentBlockToViewConverter : Xamarin.Forms.IValueConverter
    {
        public event System.EventHandler OptionButtonClicked;

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            if (!(value is ContentBlockCollectionItemViewModel)) return value;

            var item = value as ContentBlockCollectionItemViewModel;

            if (item.Target is TextContentBlockViewModel) return new Views.Block.TextContentBlockView(item.Target as TextContentBlockViewModel, OptionButtonClicked);

            if (item.Target is HeaderTextContentBlockViewModel) return new Views.Block.HeaderTextContentBlockView(item.Target as HeaderTextContentBlockViewModel, OptionButtonClicked);

            if (item.Target is ImageContentBlockViewModel) return new Views.Block.ImageContentBlockView(item.Target as ImageContentBlockViewModel, OptionButtonClicked);

            if (item.Target is TransparentSeparatorContentBlockViewModel) return new Views.Block.TransparentSeparatorContentBlockView(item.Target as TransparentSeparatorContentBlockViewModel, OptionButtonClicked);

            throw new System.InvalidOperationException();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
