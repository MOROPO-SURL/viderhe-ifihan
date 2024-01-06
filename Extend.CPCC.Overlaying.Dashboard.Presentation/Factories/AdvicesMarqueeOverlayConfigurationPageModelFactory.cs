using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Extend.CPCC.Overlaying.Presentation.Models.Context;

namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Factories
{
    public static class AdvicesMarqueeOverlayConfigurationPageModelFactory
    {
        public static AdvicesMarqueeOverlayConfigurationPageModel Build(string serializedContext)
        {
            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<AdvicesMarqueeOverlayContextModel>(serializedContext);

            return new AdvicesMarqueeOverlayConfigurationPageModel
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
