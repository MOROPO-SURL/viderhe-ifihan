namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == Descriptors.LandscapeContextualTranslucentOverlapForImageTemplateDescriptor.ID ||
                model.Template.Id == Descriptors.LandscapeContextualFlatOverlapForImageTemplateDescriptor.ID ||
                model.Template.Id == Descriptors.LandscapeContextualTrailOverlapForImageTemplateDescriptor.ID)
            {
                return new Views.LandscapeContextualCommonOverlapForImagePlacardThumbnailView(model, cloudServerProvider);
            }

            return null;
        }
    }
}
