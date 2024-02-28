using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Descriptors;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == CornerTileVideoPresentingVideoTemplateDescriptor.ID)
            {
                return new Views.CornerTileVideoPresentingVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == InfinityVideoTemplateDescriptor.ID)
            {
                return new Views.InfinityVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == LandscapeCrossStripeTemplateDescriptor.ID)
            {
                return new Views.LandscapeCrossStripePlacardThumbnailView(model);
            }

            if (model.Template.Id == LandscapeFramedTemplateDescriptor.ID)
            {
                return new Views.LandscapeFramedPlacardThumbnailView();
            }

            if (model.Template.Id == LandscapePennantTemplateDescriptor.ID)
            {
                return new Views.LandscapePennantTrainPlacardThumbnailView(model);
            }

            if (model.Template.Id == LandscapeFloatingFlyoutTemplateDescriptor.ID)
            {
                return new Views.LandscapeFloatingFlyoutPlacardThumbnailView(model);
            }

            if (model.Template.Id == LandscapeAnonimusHeroTemplateDescriptor.ID)
            {
                return new Views.LandscapeAnonimusHeroPlacardThumbnailView(model);
            }

            if (model.Template.Id == LandscapeFillFlyoutTemplateDescriptor.ID)
            {
                return new Views.LandscapeFillFlyoutPlacardThumbnailView(model);
            }

            return null;
        }
    }
}
