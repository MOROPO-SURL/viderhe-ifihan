using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Template
{
    public class ContentBlockTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public Common.Templating.Presentation.Views.Contract.IRelativeDimensionScalable RelativeDimensionScalable { get; set; }

        protected override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, Xamarin.Forms.BindableObject container)
        {
            if (item is HeaderTextContentBlockViewModel) return new Block.HeaderTextContentBlockViewTemplate
            {
                RelativeDeimensionScaleFactor = RelativeDimensionScalable.RelativeDeimensionScaleFactor
            };

            if (item is TextContentBlockViewModel) return new Block.TextContentBlockViewTemplate
            {
                RelativeDeimensionScaleFactor = RelativeDimensionScalable.RelativeDeimensionScaleFactor
            };

            if (item is TransparentSeparatorContentBlockViewModel) return new Block.TransparentSeparatorContentBlockViewTemplate
            {
                RelativeDeimensionScaleFactor = RelativeDimensionScalable.RelativeDeimensionScaleFactor
            };

            if (item is ImageContentBlockViewModel) return new Block.ImageContentBlockViewTemplate
            {
                RelativeDeimensionScaleFactor = RelativeDimensionScalable.RelativeDeimensionScaleFactor
            };

            throw new System.InvalidOperationException();
        }
    }
}
