using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeContextualTrailOverlapForImagePlacardConfigurationPageModel : Contract.AbstractLandscapeContextualOperlapForImagePlacardConfigurationPageModel
    {
        private Xamarin.Forms.Color overlapBackgroundColor;
        private OverlapTrailMode overlapTrailMode;
        private Xamarin.Forms.Color textColor;
        private bool contextedImageCenteredAtPresentation;

        public LandscapeContextualTrailOverlapForImagePlacardConfigurationPageModel()
        {
            OverlapBackgroundColor = Xamarin.Forms.Color.Black;
            TextColor = Xamarin.Forms.Color.White;
            OverlapTrailMode = OverlapTrailMode.Dual;
            AvailableOverlapTrailModes = new OverlapTrailMode[] 
            {
                OverlapTrailMode.Single,
                OverlapTrailMode.Dual,
                OverlapTrailMode.Triplex,
                OverlapTrailMode.Fourfold
            };
        }

        public Xamarin.Forms.Color OverlapBackgroundColor { get => overlapBackgroundColor; set => SetProperty(ref overlapBackgroundColor, value); }

        public OverlapTrailMode OverlapTrailMode { get => overlapTrailMode; set => SetProperty(ref overlapTrailMode, value); }

        public OverlapTrailMode[] AvailableOverlapTrailModes { get; private set; }

        public Xamarin.Forms.Color TextColor { get => textColor; set => SetProperty(ref textColor, value); }

        public bool ContextedImageCenteredAtPresentation { get => contextedImageCenteredAtPresentation; set => SetProperty(ref contextedImageCenteredAtPresentation, value); }
    }
}
