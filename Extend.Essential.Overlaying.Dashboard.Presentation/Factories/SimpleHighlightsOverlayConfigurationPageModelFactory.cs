namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Overlaying.Dashboard.Presentation.Factories
{
    public static class SimpleHighlightsOverlayConfigurationPageModelFactory
    {
        public static Models.Page.SimpleHighlightsOverlayConfigurationPageModel Build(string serializedContext)
        {
            try
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.SimpleHighlightsContextModel>(serializedContext);

                return new Models.Page.SimpleHighlightsOverlayConfigurationPageModel
                {
                    Header = context.Header,
                    Highlights = context.Highlights
                };
            }
            catch
            {
                return new Models.Page.SimpleHighlightsOverlayConfigurationPageModel();
            }
        }
    }
}
