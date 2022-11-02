namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Block
{
    public static class ImageContentBlockConfigurationPageModelFactory
    {
        public static Models.Page.Configuration.Block.ImageContentBlockConfigurationPageModel Build(Templating.Presentation.Models.View.Block.ImageContentBlockViewModel model)
        {
            if (model == null) return new Models.Page.Configuration.Block.ImageContentBlockConfigurationPageModel();

            var result = new Models.Page.Configuration.Block.ImageContentBlockConfigurationPageModel
            {
                Id = model.Id,
                Image = model.Image,
                HorizontalAlignament = model.HorizontalAlignament,
                HeightByScreenVerticalSizePercent = model.HeightByScreenVerticalSizePercent
            };

            return result;
        }
    }
}
