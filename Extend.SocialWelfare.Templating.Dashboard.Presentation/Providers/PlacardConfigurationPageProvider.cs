namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Providers
{
    public class PlacardConfigurationPageProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardConfigurationPageProviderFacade
    {
        public Xamarin.Forms.Page GetCreationEntryPointPageByDescriptor(Common.Templating.Descriptors.ITemplateDescriptor templateDescriptor, System.Action completedActionCallback)
        {
            if (templateDescriptor is Descriptors.InmersiveCityWeatherOverviewTemplateDescriptor)
            {
                return new Pages.InmersiveCityWeatherOverviewPlacardConfigurationPage(completedActionCallback);
            }

            if (templateDescriptor is Descriptors.RssFeedCollageHeroTemplateDescriptor)
            {
                return new Pages.RssFeedCollageHeroPlacardConfigurationPage(completedActionCallback);
            }

            return null;
        }

        public Xamarin.Forms.Page GetEditionPageByDescriptor(Support.Presentation.Models.View.PlacardViewModel placardViewModel, System.Action completedActionCallback)
        {
            if (placardViewModel.Template.Id == Descriptors.InmersiveCityWeatherOverviewTemplateDescriptor.ID)
            {
                return new Pages.InmersiveCityWeatherOverviewPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            if (placardViewModel.Template.Id == Descriptors.RssFeedCollageHeroTemplateDescriptor.ID)
            {
                return new Pages.RssFeedCollageHeroPlacardConfigurationPage(placardViewModel, completedActionCallback);
            }

            return null;
        }
    }
}
