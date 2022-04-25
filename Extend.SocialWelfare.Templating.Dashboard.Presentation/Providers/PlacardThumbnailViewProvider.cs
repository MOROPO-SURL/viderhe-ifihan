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

            return null;
        }
    }
}
