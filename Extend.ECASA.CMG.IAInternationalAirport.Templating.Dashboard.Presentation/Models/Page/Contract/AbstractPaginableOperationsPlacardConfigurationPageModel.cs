namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractPaginableOperationsPlacardConfigurationPageModel : AbstractOperationsPlacardConfigurationPageModel
    {
        private int maxItemsCount;

        public int MaxItemsCount { get => maxItemsCount; set => SetProperty(ref maxItemsCount, value); }
    }
}
