namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedCallbackAction)
        {
            if (templateDescriptor is Descriptors.InmersiveCityWeatherOverviewTemplateDescriptor)
            {
                return new Pages.InmersiveCityWeatherOverviewPlacardConfigurationPage(completedCallbackAction);
            }

            if (templateDescriptor is Descriptors.RssFeedCollageHeroTemplateDescriptor)
            {
                return new Pages.RssFeedCollageHeroPlacardConfigurationPage(completedCallbackAction);
            }

            if (templateDescriptor is Descriptors.HeroLocalNowDateTimeTemplateDescriptor)
            {
                return new Pages.HeroLocalNowDateTimePlacardConfigurationPage(completedCallbackAction);
            }

            if (templateDescriptor is Descriptors.OverlayHeroCityTimeWeatherTemplateDescriptor)
            {
                return new Pages.OverlayHeroCityTimeWeatherPlacardConfigurationPage(completedCallbackAction);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedCallbackAction)
        {
            if (placardViewModel.Template.Id == Descriptors.InmersiveCityWeatherOverviewTemplateDescriptor.ID)
            {
                return new Pages.InmersiveCityWeatherOverviewPlacardConfigurationPage(placardViewModel, completedCallbackAction);
            }

            if (placardViewModel.Template.Id == Descriptors.RssFeedCollageHeroTemplateDescriptor.ID)
            {
                return new Pages.RssFeedCollageHeroPlacardConfigurationPage(placardViewModel, completedCallbackAction);
            }

            if (placardViewModel.Template.Id == Descriptors.HeroLocalNowDateTimeTemplateDescriptor.ID)
            {
                return new Pages.HeroLocalNowDateTimePlacardConfigurationPage(placardViewModel, completedCallbackAction);
            }

            if (placardViewModel.Template.Id == Descriptors.OverlayHeroCityTimeWeatherTemplateDescriptor.ID)
            {
                return new Pages.OverlayHeroCityTimeWeatherPlacardConfigurationPage(placardViewModel, completedCallbackAction);
            }

            return null;
        }
    }
}
