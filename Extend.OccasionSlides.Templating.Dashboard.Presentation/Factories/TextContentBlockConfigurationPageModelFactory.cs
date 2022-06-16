namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Factories
{
    public static class TextContentBlockConfigurationPageModelFactory
    {
        public static Models.Page.Block.TextContentBlockConfigurationPageModel Build(Models.View.TextContentBlockViewModel model)
        {
            if (model == null) return new Models.Page.Block.TextContentBlockConfigurationPageModel();

            var result = new Models.Page.Block.TextContentBlockConfigurationPageModel
            {
                Id = model.Id,
                Priority = model.Priority,
                Content = model.Content,
                ContentFontFamily = model.ContentFontFamily,
                ContentFontSize = model.ContentFontSize,
                ContentMaxLine = model.ContentMaxLine,
                IsHeaderVisible = model.IsHeaderVisible,
                Header = model.Header,
                HeaderFontFamily = model.HeaderFontFamily,
                HeaderFontSize = model.HeaderFontSize
            };

            return result;
        }
    }
}
