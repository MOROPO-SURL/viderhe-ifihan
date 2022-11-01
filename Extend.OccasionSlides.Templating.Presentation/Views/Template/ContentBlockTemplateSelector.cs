using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Template
{
    public class ContentBlockTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        protected override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, Xamarin.Forms.BindableObject container)
        {
            if (item is TextContentBlockViewModel) return new Block.TextContentBlockViewTemplate();

            if (item is HeaderTextContentBlockViewModel) return new Block.HeaderTextContentBlockViewTemplate();

            if (item is TransparentSeparatorContentBlockViewModel) return new Block.TransparentSeparatorContentBlockViewTemplate();

            if (item is ImageContentBlockViewModel) return new Block.ImageContentBlockViewTemplate();

            throw new System.InvalidOperationException();
        }
    }
}
