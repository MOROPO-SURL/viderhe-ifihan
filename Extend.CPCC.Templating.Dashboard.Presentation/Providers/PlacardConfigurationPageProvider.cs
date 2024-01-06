using MOROPO.VIDERHE.Extend.CPCC.Templating.Descriptors;

namespace MOROPO.VIDERHE.Extend.CPCC.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is PortraitPosterVideoEventPromotionTemplateDescriptor)
            {
                return new Pages.PortraitPosterVideoEventPromotionEventPlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == PortraitPosterVideoEventPromotionTemplateDescriptor.ID)
            {
                return new Pages.PortraitPosterVideoEventPromotionEventPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
