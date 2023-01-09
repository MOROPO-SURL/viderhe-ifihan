namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Providers.Facade
{
    public interface IPlacardViewModelCompletitionHelperProvider
    {
        Helpers.Facade.IPlacardViewModelCompletitionHelperFacade GetFor(Cloud.Api.Common.Models.PlacardDisplayModel model);
    }
}
