namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeContextualFlatOverlapForImagePlacardConfigurationPageModel : Contract.AbstractLandscapeContextualOperlapForImagePlacardConfigurationPageModel
    {
        private Xamarin.Forms.Color overlapBackgroundColor;
        private bool useOverlapShadown;
        private Xamarin.Forms.Color textColor;
        private bool contextedImageCenteredAtPresentation;

        public LandscapeContextualFlatOverlapForImagePlacardConfigurationPageModel()
        {
            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
            TextColor = Xamarin.Forms.Color.White;
        }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public bool UseOverlapShadown { get => useOverlapShadown; set => SetProperty(ref useOverlapShadown, value); }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        public bool ContextedImageCenteredAtPresentation { get => contextedImageCenteredAtPresentation; set => SetProperty(ref contextedImageCenteredAtPresentation, value); }
    }
}
