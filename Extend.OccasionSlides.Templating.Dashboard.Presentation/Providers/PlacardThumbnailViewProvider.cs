namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.LandscapeContextualTranslucentOverlapForImageTemplateDescriptor.ID ||
                model.Template.Id == Descriptors.LandscapeContextualFlatOverlapForImageTemplateDescriptor.ID ||
                model.Template.Id == Descriptors.LandscapeContextualTrailOverlapForImageTemplateDescriptor.ID)
            {
                return new Views.PortraitTranslucentContextualOverlapForImagePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.PortraitTranslucentContextualOverlapForImageTemplateDescriptor.ID)
            {
                return new Views.PortraitTranslucentContextualOverlapForImagePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.CenteredTraslucentIntroOverImageTemplateDescriptor.ID)
            {
                return new Views.CenteredTraslucentIntroOverImagePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.LandscapeTranslucentContextualOverlapForImageSecuenceTemplateDescriptor.ID)
            {
                return new Views.LandscapeTranslucentContextualOverlapForImageSecuencePlacardThumbnailView(model);
            }

            return null;
        }
    }
}
