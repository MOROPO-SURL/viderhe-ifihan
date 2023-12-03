using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Descriptors;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == InmersiveCityWeatherOverviewTemplateDescriptor.ID)
            {
                return new Views.InmersiveCityWeatherOverviewPlacardThumnailView(model);
            }

            if (model.Template.Id == RssFeedCollageHeroTemplateDescriptor.ID)
            {
                return new SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView { BackgroundColor = Xamarin.Forms.Color.Black };
            }

            if (model.Template.Id == HeroLocalNowDateTimeTemplateDescriptor.ID)
            {
                return new Views.HeroLocalNowDateTimePlacardThumbnailView(model);
            }

            if (model.Template.Id == OverlayHeroCityTimeWeatherTemplateDescriptor.ID)
            {
                return new Views.OverlayHeroCityTimeWeatherPlacardThumbnailView(model);
            }

            return null;
        }
    }
}
