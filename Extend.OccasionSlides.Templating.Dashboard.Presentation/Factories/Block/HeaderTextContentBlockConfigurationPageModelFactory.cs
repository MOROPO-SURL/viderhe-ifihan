namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories.Block
{
    public static class HeaderTextContentBlockConfigurationPageModelFactory
    {
        public static Models.Page.Configuration.Block.HeaderTextContentBlockConfigurationPageModel Build(Templating.Presentation.Models.View.Block.HeaderTextContentBlockViewModel model)
        {
            if (model == null) return new Models.Page.Configuration.Block.HeaderTextContentBlockConfigurationPageModel();

            var result = new Models.Page.Configuration.Block.HeaderTextContentBlockConfigurationPageModel
            {
                Id = model.Id,
                Text = model.Text,
                TextFontFamily = model.TextFontFamily,
                TextFontSize = model.TextFontSize,
                TextMaxLineCount = model.TextMaxLineCount,
                TextColor = model.TextColor,
                Header = model.Header,
                HeaderFontFamily = model.HeaderFontFamily,
                HeaderFontSize = model.HeaderFontSize,
                HeaderColor = model.HeaderColor
            };

            return result;
        }
    }
}
