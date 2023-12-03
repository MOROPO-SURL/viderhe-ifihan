using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Descriptors;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedCallbackAction)
        {
            if (templateDescriptor is InmersiveCityWeatherOverviewTemplateDescriptor)
            {
                return new Pages.InmersiveCityWeatherOverviewPlacardConfigurationPage(completedCallbackAction);
            }

            if (templateDescriptor is RssFeedCollageHeroTemplateDescriptor)
            {
                return new Pages.RssFeedCollageHeroPlacardConfigurationPage(completedCallbackAction);
            }

            if (templateDescriptor is HeroLocalNowDateTimeTemplateDescriptor)
            {
                return new Pages.HeroLocalNowDateTimePlacardConfigurationPage(completedCallbackAction);
            }

            if (templateDescriptor is OverlayHeroCityTimeWeatherTemplateDescriptor)
            {
                return new Pages.OverlayHeroCityTimeWeatherPlacardConfigurationPage(completedCallbackAction);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedCallbackAction)
        {
            if (placardViewModel.Template.Id == InmersiveCityWeatherOverviewTemplateDescriptor.ID)
            {
                return new Pages.InmersiveCityWeatherOverviewPlacardConfigurationPage(placardViewModel, completedCallbackAction);
            }

            if (placardViewModel.Template.Id == RssFeedCollageHeroTemplateDescriptor.ID)
            {
                return new Pages.RssFeedCollageHeroPlacardConfigurationPage(placardViewModel, completedCallbackAction);
            }

            if (placardViewModel.Template.Id == HeroLocalNowDateTimeTemplateDescriptor.ID)
            {
                return new Pages.HeroLocalNowDateTimePlacardConfigurationPage(placardViewModel, completedCallbackAction);
            }

            if (placardViewModel.Template.Id == OverlayHeroCityTimeWeatherTemplateDescriptor.ID)
            {
                return new Pages.OverlayHeroCityTimeWeatherPlacardConfigurationPage(placardViewModel, completedCallbackAction);
            }

            return null;
        }
    }
}
