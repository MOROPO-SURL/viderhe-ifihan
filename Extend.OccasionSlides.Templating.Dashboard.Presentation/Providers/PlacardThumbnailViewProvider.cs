using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Descriptors;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == TranslucentContextualOverlapForImageTemplateDescriptor.ID ||
                model.Template.Id == FlatContextualOverlapForImageTemplateDescriptor.ID ||
                model.Template.Id == TrailContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.CommonContextualOverlapForImagePlacardThumbnailView(model);
            }

            if (model.Template.Id == CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.CenteredTraslucentIntroOverImagePlacardThumbnailView(model);
            }

            if (model.Template.Id == TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.TranslucentContextualOverlapForImageSecuencePlacardThumbnailView(model);
            }

            if (model.Template.Id == TrailContextualOverlapForVideoTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.TrailContextualOverlapForVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == TranslucentContextualOverlapForVideoTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.TranslucentContextualOverlapForVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == FlatContextualOverlapForVideoTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.FlatContextualOverlapForVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == FlatContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.FlatContextualOverlapForImageSecuencePlacardThumbnailView(model);
            }

            if (model.Template.Id == TrailContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.TrailContextualOverlapForImageSecuencePlacardThumbnailView(model);
            }

            return null;
        }
    }
}
