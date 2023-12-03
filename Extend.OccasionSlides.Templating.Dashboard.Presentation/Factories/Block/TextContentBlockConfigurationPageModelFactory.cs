using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block;
using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Block
{
    public static class TextContentBlockConfigurationPageModelFactory
    {
        public static TextContentBlockConfigurationPageModel Build(TextContentBlockViewModel model)
        {
            if (model == null) return new TextContentBlockConfigurationPageModel();

            var result = new TextContentBlockConfigurationPageModel
            {
                Id = model.Id,
                Text = model.Text,
                TextFontFamily = model.TextFontFamily,
                TextFontSize = model.TextFontSize,
                TextMaxLineCount = model.TextMaxLineCount,
                TextColor = model.TextColor
            };

            return result;
        }
    }
}
