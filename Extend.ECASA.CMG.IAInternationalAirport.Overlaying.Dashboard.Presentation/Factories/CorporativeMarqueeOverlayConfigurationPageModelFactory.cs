namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Dashboard.Presentation.Factories
{
    internal class CorporativeMarqueeOverlayConfigurationPageModelFactory
    {
        internal static Models.Page.CorporativeMarqueeOverlayConfigurationPageModel Build(string serializedContext)
        {
            try
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.CorporativeMarqueeOverlayContextModel>(serializedContext);

                return new Models.Page.CorporativeMarqueeOverlayConfigurationPageModel
                {
                    InformationSourceKind = context.InformationSourceKind,
                    InformationSource = context.InformationSource,
                    InformationSourceUpdateMinuteInterval = context.InformationSourceUpdateMinuteInterval,
                    IsRectangle19x6LogoSizeModeSelected = context.LogoSizeMode == Overlaying.Presentation.Enumerations.MarqueeLogoSizeMode.Rectangle19x6,
                    IsRectangle4x3LogoSizeModeSelected = context.LogoSizeMode == Overlaying.Presentation.Enumerations.MarqueeLogoSizeMode.Rectangle4x3,
                    IsRectangle1x1LogoSizeModeSelected = context.LogoSizeMode == Overlaying.Presentation.Enumerations.MarqueeLogoSizeMode.Square1x1,
                    FailbackMessage = context.FailbackMessage,
                    Head = context.Head,
                    Tail = context.Tail,
                    Separator = context.Separator,
                    BackgroundColor = Xamarin.Forms.Color.FromHex(context.BackgroundColor),
                    TextColor = Xamarin.Forms.Color.FromHex(context.TextColor),
                    FrontierColor = Xamarin.Forms.Color.FromHex(context.FrontierColor),
                    LogoOutlineColor = Xamarin.Forms.Color.FromHex(context.LogoOutlineColor),
                    IsDateTimePresentationRequired = context.IsDateTimePresentationRequired
                };
            }
            catch
            {
                return new Models.Page.CorporativeMarqueeOverlayConfigurationPageModel();
            }
        }
    }
}
