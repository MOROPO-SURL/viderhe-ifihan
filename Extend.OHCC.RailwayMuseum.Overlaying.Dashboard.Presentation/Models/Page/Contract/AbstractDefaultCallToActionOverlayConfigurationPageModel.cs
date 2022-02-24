namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractDefaultCallToActionOverlayConfigurationPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string callToActionMessage;
        private int callToActionMessageFontSize;

        public string CallToActionMessage { get => callToActionMessage; set => SetProperty(ref callToActionMessage, value); }

        public int CallToActionMessageFontSize { get => callToActionMessageFontSize; set => SetProperty(ref callToActionMessageFontSize, value); }
    }
}
