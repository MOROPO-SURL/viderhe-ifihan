namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Dashboard.Presentation.Factories
{
    public static class AdvicesMarqueeOverlayConfigurationPageModelFactory
    {
        public static Models.Page.AdvicesMarqueeOverlayConfigurationPageModel Build(string serializedContext)
        {
            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.AdvicesMarqueeOverlayContextModel>(serializedContext);

            return new Models.Page.AdvicesMarqueeOverlayConfigurationPageModel
            {
                ServerName = context.ServerName,
                IsSecureServer = context.IsSecureServer,
                IsRequiredSecurityStrict = context.IsRequiredSecurityStrict,
                Head = context.Head,
                Tail = context.Tail,
                Separator = context.Separator,
                FailbackMessage = context.FailbackMessage
            };
        }
    }
}
