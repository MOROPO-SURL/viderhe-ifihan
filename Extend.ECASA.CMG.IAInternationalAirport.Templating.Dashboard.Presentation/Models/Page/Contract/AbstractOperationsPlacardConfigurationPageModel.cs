namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractOperationsPlacardConfigurationPageModel : AbstractInteroperablePlacardConfigurationPageModel
    {
        private int updateInterval;

        public AbstractOperationsPlacardConfigurationPageModel()
        {
            updateInterval = 60;
        }

        public int UpdateInterval { get => updateInterval; set => SetProperty(ref updateInterval, value); }
    }
}
