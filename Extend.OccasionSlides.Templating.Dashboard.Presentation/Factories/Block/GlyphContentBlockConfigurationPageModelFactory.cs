namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Block
{
    internal static class GlyphContentBlockConfigurationPageModelFactory
    {
        public static Models.Page.Configuration.Block.GlyphContentBlockConfigurationPageModel Build(Templating.Presentation.Models.View.Block.GlyphContentBlockViewModel model)
        {
            if (model == null) return new Models.Page.Configuration.Block.GlyphContentBlockConfigurationPageModel();

            var result = new Models.Page.Configuration.Block.GlyphContentBlockConfigurationPageModel
            {
                Id = model.Id,
                Glyph = model.Glyph,
                FontSize = model.FontSize,
                Color = model.Color
            };

            return result;
        }
    }
}
