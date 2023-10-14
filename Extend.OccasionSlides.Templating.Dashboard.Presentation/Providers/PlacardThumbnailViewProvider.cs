namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.TranslucentContextualOverlapForImageTemplateDescriptor.ID ||
                model.Template.Id == Descriptors.FlatContextualOverlapForImageTemplateDescriptor.ID ||
                model.Template.Id == Descriptors.TrailContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.CommonContextualOverlapForImagePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.CenteredTraslucentIntroOverImagePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.TranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.TranslucentContextualOverlapForImageSecuencePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.TrailContextualOverlapForVideoTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.TrailContextualOverlapForVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.TranslucentContextualOverlapForVideoTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.TranslucentContextualOverlapForVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.FlatContextualOverlapForVideoTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.FlatContextualOverlapForVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.FlatContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.FlatContextualOverlapForImageSecuencePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.TrailContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Views.Thumbnail.TrailContextualOverlapForImageSecuencePlacardThumbnailView(model);
            }

            return null;
        }
    }
}
