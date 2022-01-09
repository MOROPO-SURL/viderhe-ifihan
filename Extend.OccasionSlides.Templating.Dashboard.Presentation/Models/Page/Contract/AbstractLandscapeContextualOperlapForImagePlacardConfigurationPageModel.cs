namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public class AbstractLandscapeContextualOperlapForImagePlacardConfigurationPageModel : AbstractLandscapeContextedMediaPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel contextedImage;
        private bool contextedImageZoomingEnabled;

        public Support.Presentation.Models.View.ImageViewModel ContextedImage { get => contextedImage; set => SetProperty(ref contextedImage, value); }

        public bool ContextedImageZoomingEnabled { get => contextedImageZoomingEnabled; set => SetProperty(ref contextedImageZoomingEnabled, value); }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ContextedImage = null;
        }
    }
}
