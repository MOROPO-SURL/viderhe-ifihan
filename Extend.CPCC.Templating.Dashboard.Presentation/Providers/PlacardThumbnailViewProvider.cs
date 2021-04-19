namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == Descriptors.PortraitPosterVideoEventPromotionTemplateDescriptor.ID)
            {
                return new Views.PortraitPosterVideoEventPromotionEventPlacardThumbnailView(model, cloudServerProvider);
            }

            return null;
        }
    }
}
