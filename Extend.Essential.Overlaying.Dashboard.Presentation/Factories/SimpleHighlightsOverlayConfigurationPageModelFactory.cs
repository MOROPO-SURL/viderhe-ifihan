using MOROPO.VIDERHE.Extend.Essential.Overlaying.Dashboard.Presentation.Models.Page;

namespace MOROPO.VIDERHE.Extend.Essential.Overlaying.Dashboard.Presentation.Factories
{
    public static class SimpleHighlightsOverlayConfigurationPageModelFactory
    {
        public static SimpleHighlightsOverlayConfigurationPageModel Build(string serializedContext)
        {
            try
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.SimpleHighlightsContextModel>(serializedContext);

                return new SimpleHighlightsOverlayConfigurationPageModel
                {
                    Header = context.Header,
                    Highlights = context.Highlights
                };
            }
            catch
            {
                return new SimpleHighlightsOverlayConfigurationPageModel();
            }
        }
    }
}
