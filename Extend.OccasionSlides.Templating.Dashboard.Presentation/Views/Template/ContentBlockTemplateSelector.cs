using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Views.Template
{
    public class ContentBlockTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public event System.EventHandler OptionButtonClicked;

        protected override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, Xamarin.Forms.BindableObject container)
        {
            if (item is HeaderTextContentBlockViewModel) return new Block.HeaderTextContentBlockViewTemplate(OptionButtonClicked);

            if (item is TextContentBlockViewModel) return new Block.TextContentBlockViewTemplate(OptionButtonClicked);

            if (item is TransparentSeparatorContentBlockViewModel) return new Block.TransparentSeparatorContentBlockViewTemplate();

            if (item is ImageContentBlockViewModel) return new Block.ImageContentBlockViewTemplate(OptionButtonClicked);

            throw new System.InvalidOperationException();
        }
    }
}
