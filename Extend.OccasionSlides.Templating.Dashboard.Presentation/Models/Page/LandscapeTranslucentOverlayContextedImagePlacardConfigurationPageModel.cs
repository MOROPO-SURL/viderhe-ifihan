namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeTranslucentOverlayContextedImagePlacardConfigurationPageModel : Contract.AbstractLandscapeContextedMediaPlacardConfigurationPageModel
    {
        private Xamarin.Forms.Color overlayBackgroundColor;
        private Xamarin.Forms.Color textColor;
        private Support.Presentation.Models.View.ImageViewModel contextedImage;

        public LandscapeTranslucentOverlayContextedImagePlacardConfigurationPageModel()
        {
            OverlayBackgroundColor = Xamarin.Forms.Color.Black;
            TextColor = Xamarin.Forms.Color.White;
        }

        public Xamarin.Forms.Color OverlayBackgroundColor { get => overlayBackgroundColor; set => SetProperty(ref overlayBackgroundColor, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        public Support.Presentation.Models.View.ImageViewModel ContextedImage { get => contextedImage; set => SetProperty(ref contextedImage, value); }
    }
}
