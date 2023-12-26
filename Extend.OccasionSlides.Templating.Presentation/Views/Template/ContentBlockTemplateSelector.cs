using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Views.Template
{
    public class ContentBlockTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public Common.Templating.Presentation.Views.Facade.IRelativeSizeScalableViewFacade RelativeSizeScalableView { get; set; }

        protected override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, Xamarin.Forms.BindableObject container)
        {
            if (item is HeaderTextContentBlockViewModel) return new Xamarin.Forms.DataTemplate(() => new Block.HeaderTextContentBlockView(RelativeSizeScalableView.RelativeSizeScaleFactor));

            if (item is TextContentBlockViewModel) return new Xamarin.Forms.DataTemplate(() => new Block.TextContentBlockView(RelativeSizeScalableView.RelativeSizeScaleFactor));

            if (item is TransparentSeparatorContentBlockViewModel) return new Xamarin.Forms.DataTemplate(() => new Block.TransparentSeparatorContentBlockView(RelativeSizeScalableView.RelativeSizeScaleFactor));

            if (item is ImageContentBlockViewModel) return new Xamarin.Forms.DataTemplate(() => new Block.ImageContentBlockView(RelativeSizeScalableView.RelativeSizeScaleFactor));

            if (item is GlyphContentBlockViewModel) return new Xamarin.Forms.DataTemplate(() => new Block.GlyphContentBlockView(RelativeSizeScalableView.RelativeSizeScaleFactor));
            
            throw new System.InvalidOperationException();
        }
    }
}
