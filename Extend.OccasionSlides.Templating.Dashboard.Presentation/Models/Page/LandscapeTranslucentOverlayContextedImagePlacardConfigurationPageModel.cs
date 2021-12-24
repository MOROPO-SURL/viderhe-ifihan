namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeTranslucentOverlayContextedImagePlacardConfigurationPageModel : Contract.AbstractLandscapeContextedMediaPlacardConfigurationPageModel
    {
        private Xamarin.Forms.Color overlayBackgroundColor;
        private Support.Presentation.Models.View.ImageViewModel contextedImage;

        public Xamarin.Forms.Color OverlayBackgroundColor { get => overlayBackgroundColor; set => SetProperty(ref overlayBackgroundColor, value); }

        public Support.Presentation.Models.View.ImageViewModel ContextedImage { get => contextedImage; set => SetProperty(ref contextedImage, value); }
    }
}
