namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is Descriptors.EventLiveStreamTemplateDescriptor)
            {
                return new Pages.EventLiveStreamPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.AmbientalDashboardTemplateDescriptor)
            {
                return new Pages.AmbientalDashboardPlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == Descriptors.EventLiveStreamTemplateDescriptor.ID)
            {
                return new Pages.EventLiveStreamPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.AmbientalDashboardTemplateDescriptor.ID)
            {
                return new Pages.AmbientalDashboardPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
