namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Models.View.Contract
{
    public abstract class AbstractInteroperablePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public string APIServer { get; set; }

        public bool UseSSL { get; set; }

        public bool AllowAnyCertificate { get; set; }

        public string APIKey { get; set; }
    }
}
