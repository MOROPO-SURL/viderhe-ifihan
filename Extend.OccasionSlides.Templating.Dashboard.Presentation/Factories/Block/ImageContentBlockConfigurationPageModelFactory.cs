using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Block
{
    public static class ImageContentBlockConfigurationPageModelFactory
    {
        public static Models.Page.Configuration.Block.ImageContentBlockConfigurationPageModel Build(ImageContentBlockViewModel model)
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
