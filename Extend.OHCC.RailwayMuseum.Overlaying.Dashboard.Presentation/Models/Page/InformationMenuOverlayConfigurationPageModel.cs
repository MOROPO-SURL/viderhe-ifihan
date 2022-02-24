namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Models.Page
{
    public class InformationMenuOverlayConfigurationPageModel : Contract.AbstractDefaultCallToActionOverlayConfigurationPageModel
    {
        private string railwayMuseumAboutUri;
        private string railwayMuseumOfferUri;
        private string railwayMuseumBillboardUri;
        private string _OHCCAboutUri;
        private string _OHCCOfferUri;
        private string _OHCCBillboardUri;

        public InformationMenuOverlayConfigurationPageModel()
        {
            CallToActionMessage = "toca la pantalla para comenzar";
            CallToActionMessageFontSize = 30;
        }

        public string RailwayMuseumAboutUri { get => railwayMuseumAboutUri; set => SetProperty(ref railwayMuseumAboutUri, value); }

        public string RailwayMuseumOfferUri { get => railwayMuseumOfferUri; set => SetProperty(ref railwayMuseumOfferUri, value); }

        public string RailwayMuseumBillboardUri { get => railwayMuseumBillboardUri; set => SetProperty(ref railwayMuseumBillboardUri, value); }

        public string OHCCAboutUri { get => _OHCCAboutUri; set => SetProperty(ref _OHCCAboutUri, value); }

        public string OHCCOfferUri { get => _OHCCOfferUri; set => SetProperty(ref _OHCCOfferUri, value); }

        public string OHCCBillboardUri { get => _OHCCBillboardUri; set => SetProperty(ref _OHCCBillboardUri, value); }
    }
}
