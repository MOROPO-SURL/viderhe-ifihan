namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeContextualTrailOverlapForImagePlacardConfigurationPageModel : Contract.AbstractLandscapeContextualOperlapForImagePlacardConfigurationPageModel
    {
        private Xamarin.Forms.Color overlapBackgroundColor;
        private Templating.Presentation.Enumerations.OverlapTrailMode overlapTrailMode;
        private Xamarin.Forms.Color textColor;
        private bool contextedImageCenteredAtPresentation;

        public LandscapeContextualTrailOverlapForImagePlacardConfigurationPageModel()
        {
            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
            TextColor = Xamarin.Forms.Color.White;
            OverlapTrailMode = Templating.Presentation.Enumerations.OverlapTrailMode.Dual;
            AvailableOverlapTrailModes = new Templating.Presentation.Enumerations.OverlapTrailMode[] 
            {
                Templating.Presentation.Enumerations.OverlapTrailMode.Single,
                Templating.Presentation.Enumerations.OverlapTrailMode.Dual,
                Templating.Presentation.Enumerations.OverlapTrailMode.Triplex,
                Templating.Presentation.Enumerations.OverlapTrailMode.Fourfold
            };
        }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public Templating.Presentation.Enumerations.OverlapTrailMode OverlapTrailMode { get => overlapTrailMode; set => SetProperty(ref overlapTrailMode, value); }

        public Templating.Presentation.Enumerations.OverlapTrailMode[] AvailableOverlapTrailModes { get; private set; }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        public bool ContextedImageCenteredAtPresentation { get => contextedImageCenteredAtPresentation; set => SetProperty(ref contextedImageCenteredAtPresentation, value); }
    }
}
