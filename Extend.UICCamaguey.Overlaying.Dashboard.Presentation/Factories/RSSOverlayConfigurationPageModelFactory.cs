using MOROPO.VIDERHE.Extend.UICCamaguey.Overlaying.Dashboard.Presentation.Models.Page;

namespace MOROPO.VIDERHE.Extend.UICCamaguey.Overlaying.Dashboard.Presentation.Factories
{
    public static class RSSOverlayConfigurationPageModelFactory
    {
        public static RSSOverlayConfigurationPageModel Build(string serializedContext)
        {
            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.RSSOverlayContextModel>(serializedContext);

            return new RSSOverlayConfigurationPageModel
            {
                Head = context.Head,
                Tail = context.Tail,
                FeedUrl = context.FeedUrl?.ToString()
            };
        }
    }
}
