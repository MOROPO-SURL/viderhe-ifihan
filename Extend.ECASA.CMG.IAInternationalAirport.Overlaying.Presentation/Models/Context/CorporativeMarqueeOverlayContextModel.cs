namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Models.Context
{
    public class CorporativeMarqueeOverlayContextModel
    {
        public Enumerations.MarqueeLogoSizeMode LogoSizeMode { get; set; }
        
        public Enumerations.CorporativeInformationSourceKind InformationSourceKind { get; set; }

        public int InformationSourceUpdateMinuteInterval { get; set; }

        public string InformationSource { get; set; }

        public string Head { get; set; }

        public string Tail { get; set; }

        public string Separator { get; set; }

        public string FailbackMessage { get; set; }

        public string BackgroundColor { get; set; }

        public string TextColor { get; set; }

        public string FrontierColor { get; set; }

        public string LogoOutlineColor { get; set; }

        public bool IsDateTimePresentationRequired { get; set; }
    }
}
