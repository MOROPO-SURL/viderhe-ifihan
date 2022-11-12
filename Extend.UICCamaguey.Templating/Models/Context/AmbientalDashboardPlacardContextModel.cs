namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Models.Context
{
    public class AmbientalDashboardPlacardContextModel : Common.Templating.Models.Context.AbstractScreenTimedPlacardContextModel
    {
        public string IoTPlatformEndpointBaseUri { get; set; }

        public Enumerations.AmbientalVariable AmbientalVariable { get; set; }
    }
}
