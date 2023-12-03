namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Models.Context.Placard.Contract
{
    public abstract class AbstractInteroperablePlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public string APIServer { get; set; }

        public bool UseSSL { get; set; }

        public bool AllowAnyCertificate { get; set; }

        public string APIKey { get; set; }
    }
}
