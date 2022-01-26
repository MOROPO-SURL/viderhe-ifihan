namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            if (model.Template.Id == Descriptors.CornerTileVideoPresentingVideoTemplateDescriptor.ID)
            {
                return new Views.CornerTileVideoPresentingVideoPlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.InfinityVideoTemplateDescriptor.ID)
            {
                return new Views.InfinityVideoPlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.LandscapeCrossStripeTemplateDescriptor.ID)
            {
                return new Views.LandscapeCrossStripePlacardThumbnailView(model, cloudServerProvider);
            }

            if (model.Template.Id == Descriptors.LandscapeFramedTemplateDescriptor.ID)
            {
                return new Views.LandscapeFramedPlacardThumbnailView();
            }

            if (model.Template.Id == Descriptors.LandscapePennantTrainTemplateDescriptor.ID)
            {
                return new Views.LandscapePennantTrainPlacardThumbnailView(model, cloudServerProvider);
            }

            return null;
        }
    }
}
