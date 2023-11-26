using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Views.Template
{
    public class ContentBlockTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public Common.Templating.Presentation.Views.Facade.IRelativeSizeScalableViewFacade RelativeSizeScalableView { get; set; }

        protected override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, Xamarin.Forms.BindableObject container)
        {
            if (item is HeaderTextContentBlockViewModel) return new Xamarin.Forms.DataTemplate(() => new Views.Block.HeaderTextContentBlockView
            {
                RelativeSizeScaleFactor = RelativeSizeScalableView.RelativeSizeScaleFactor
            });

            if (item is TextContentBlockViewModel) return new Xamarin.Forms.DataTemplate(() => new Views.Block.TextContentBlockView
            {
                RelativeSizeScaleFactor = RelativeSizeScalableView.RelativeSizeScaleFactor
            });

            if (item is TransparentSeparatorContentBlockViewModel) return new Xamarin.Forms.DataTemplate(() => new Views.Block.TransparentSeparatorContentBlockView
            {
                RelativeSizeScaleFactor = RelativeSizeScalableView.RelativeSizeScaleFactor
            });

            if (item is ImageContentBlockViewModel) return new Xamarin.Forms.DataTemplate(() => new Views.Block.ImageContentBlockView
            {
                RelativeSizeScaleFactor = RelativeSizeScalableView.RelativeSizeScaleFactor
            });

            throw new System.InvalidOperationException();
        }
    }
}
