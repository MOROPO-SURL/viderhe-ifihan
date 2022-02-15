namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Providers.Facade
{
    public interface IPlacardConfigurationPageProviderFacade
    {
        Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback);

        Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback);
    }
}
