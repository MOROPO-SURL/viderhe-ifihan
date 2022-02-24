namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Factories
{
    public static class InformationMenuOverlayConfigurationPageModelFactory
    {
        public static Models.Page.InformationMenuOverlayConfigurationPageModel Build(string serializedContext)
        {
            try
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.InformationMenuOverlayContextModel>(serializedContext);

                return new Models.Page.InformationMenuOverlayConfigurationPageModel
                {
                    CallToActionMessage = context.CallToActionMessage,
                    CallToActionMessageFontSize = context.CallToActionMessageFontSize,
                    RailwayMuseumAboutUri = context.RailwayMuseumAboutUri,
                    RailwayMuseumOfferUri = context.RailwayMuseumOfferUri,
                    RailwayMuseumBillboardUri = context.RailwayMuseumBillboardUri,
                    OHCCAboutUri = context.OHCCAboutUri,
                    OHCCOfferUri = context.OHCCOfferUri,
                    OHCCBillboardUri = context.OHCCBillboardUri
                };
            }
            catch
            {
                return new Models.Page.InformationMenuOverlayConfigurationPageModel();
            }
        }
    }
}
