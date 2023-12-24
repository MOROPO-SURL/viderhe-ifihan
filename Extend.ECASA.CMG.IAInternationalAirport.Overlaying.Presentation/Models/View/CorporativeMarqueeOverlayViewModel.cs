namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Overlaying.Presentation.Models.View
{
    public class CorporativeMarqueeOverlayViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private string marqueeContent;

        public Context.CorporativeMarqueeOverlayContextModel Context { get; set; }

        public string MarqueeContent { get => marqueeContent; set => SetProperty(ref marqueeContent, value); }
    }
}
