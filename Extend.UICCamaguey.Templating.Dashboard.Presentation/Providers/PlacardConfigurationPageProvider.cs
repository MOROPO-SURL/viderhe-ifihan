namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Dashboard.Presentation.Providers
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

            if (templateDescriptor is Descriptors.GovDecisorPrototype1TemplateDescritor)
            {
                return new Pages.GovDecisorPrototype1PlacardConfigurationPage(completedActionCallback);
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

            if (placardViewModel.Template.Id == Descriptors.GovDecisorPrototype1TemplateDescritor.ID)
            {
                return new Pages.GovDecisorPrototype1PlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
