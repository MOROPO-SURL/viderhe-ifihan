namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Block
{
    public static class TransparentSeparatorContentBlockConfigurationPageModelFactory
    {
        public static Models.Page.Configuration.Block.TransparentSeparatorContentBlockConfigurationPageModel Build(Templating.Presentation.Models.View.Block.TransparentSeparatorContentBlockViewModel model)
        {
            if (model == null) return new Models.Page.Configuration.Block.TransparentSeparatorContentBlockConfigurationPageModel();

            var result = new Models.Page.Configuration.Block.TransparentSeparatorContentBlockConfigurationPageModel
            {
                Id = model.Id,
                SizingMode = model.SizingMode
            };

            return result;
        }
    }
}
