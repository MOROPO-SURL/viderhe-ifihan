namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Dashboard.Presentation.Factories
{
    public static class NMTourOverlayConfigurationPageModelFactory
    {
        public static Models.Page.NMTourOverlayConfigurationPageModel Build(string serializedContext)
        {
            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.NMTourOverlayContextModel>(serializedContext);

            return new Models.Page.NMTourOverlayConfigurationPageModel
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
