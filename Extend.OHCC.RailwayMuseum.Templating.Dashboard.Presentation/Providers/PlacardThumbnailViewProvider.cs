namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.CornerTileVideoPresentingVideoTemplateDescriptor.ID)
            {
                return new Views.CornerTileVideoPresentingVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.InfinityVideoTemplateDescriptor.ID)
            {
                return new Views.InfinityVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.LandscapeCrossStripeTemplateDescriptor.ID)
            {
                return new Views.LandscapeCrossStripePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.LandscapeFramedTemplateDescriptor.ID)
            {
                return new Views.LandscapeFramedPlacardThumbnailView();
            }

            if (model.Template.Id == Descriptors.LandscapePennantTemplateDescriptor.ID)
            {
                return new Views.LandscapePennantTrainPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.LandscapeFloatingFlyoutTemplateDescriptor.ID)
            {
                return new Views.LandscapeFloatingFlyoutPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.LandscapeAnonimusHeroTemplateDescriptor.ID)
            {
                return new Views.LandscapeAnonimusHeroPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.LandscapeFillFlyoutTemplateDescriptor.ID)
            {
                return new Views.LandscapeFillFlyoutPlacardThumbnailView(model);
            }

            return null;
        }
    }
}
