namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Block
{
    public static class TextContentBlockConfigurationPageModelFactory
    {
        public static Models.Page.Configuration.Block.TextContentBlockConfigurationPageModel Build(Templating.Presentation.Models.View.Block.TextContentBlockViewModel model)
        {
            if (model == null) return new Models.Page.Configuration.Block.TextContentBlockConfigurationPageModel();

            var result = new Models.Page.Configuration.Block.TextContentBlockConfigurationPageModel
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
