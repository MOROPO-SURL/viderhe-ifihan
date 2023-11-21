namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is Descriptors.ClassicDeparturesTemplateDescriptor)
            {
                return new Pages.ClassicDeparturesPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.ClassicArraivalsTemplateDescriptor)
            {
                return new Pages.ClassicArraivalsPlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == Descriptors.ClassicDeparturesTemplateDescriptor.ID)
            {
                return new Pages.ClassicDeparturesPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.ClassicArraivalsTemplateDescriptor.ID)
            {
                return new Pages.ClassicArraivalsPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
