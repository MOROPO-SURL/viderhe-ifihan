namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.PictureSlideSecuenceTemplateDescriptor.ID)
            {
                return new Views.PictureSecuencePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.SimpleVideoTemplateDescriptor.ID)
            {
                return new Views.SimpleVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.SimplePictureTemplateDescriptor.ID)
            {
                return new Views.SimplePicturePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.LandscapePicturePresentingPictureTemplateDescriptor.ID)
            {
                return new Views.LandscapePicturePresentingPicturePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.LandscapePicturePresentingVideoTemplateDescriptor.ID)
            {
                return new Views.LandscapePicturePresentingVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.PortraitPicturePresentingPictureTemplateDescriptor.ID)
            {
                return new Views.PortraitPicturePresentingPicturePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.PortraitPicturePresentingVideoTemplateDescriptor.ID)
            {
                return new Views.PortraitPicturePresentingVideoPlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.LandscapePicturePresentingPictureSlideSecuenceTemplateDescriptor.ID)
            {
                return new Views.LandscapePicturePresentingPictureSlideSecuencePlacardThumbnailView(model);
            }

            if (model.Template.Id == Descriptors.PortraitPicturePresentingPictureSlideSecuenceTemplateDescriptor.ID)
            {
                return new Views.PortraitPicturePresentingPictureSlideSecuencePlacardThumbnailView(model);
            }

            return null;
        }
    }
}
