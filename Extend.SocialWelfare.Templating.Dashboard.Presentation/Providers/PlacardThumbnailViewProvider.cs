namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.InmersiveCityWeatherOverviewTemplateDescriptor.ID)
            {
                return new Views.InmersiveCityWeatherOverviewPlacardThumnailView(model);
            }

            if (model.Template.Id == Descriptors.RssFeedCollageHeroTemplateDescriptor.ID)
            {
                return new XFToolKit.Mvvm.Views.ContentView { BackgroundColor = Xamarin.Forms.Color.Black };
            }

            if (model.Template.Id == Descriptors.HeroLocalNowDateTimeTemplateDescriptor.ID)
            {
                return new Views.HeroLocalNowDateTimePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.OverlayHeroCityTimeWeatherTemplateDescriptor.ID)
            {
                return new Views.OverlayHeroCityTimeWeatherPlacardThumbnailView(model);
            }

            return null;
        }
    }
}
