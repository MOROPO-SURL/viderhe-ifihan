namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == Descriptors.LandscapeContextualTranslucentOverlapForImageTemplateDescriptor.ID)
            {
                return new Views.LandscapeContextualTranslucentOverlapForImagePlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.LandscapeContextualFlatOverlapForImageTemplateDescriptor.ID)
            {
                return new Views.LandscapeContextualFlatOverlapForImagePlacardThumbnailView(model, cloudServerProvider);
            }

            return null;
        }
    }
}
