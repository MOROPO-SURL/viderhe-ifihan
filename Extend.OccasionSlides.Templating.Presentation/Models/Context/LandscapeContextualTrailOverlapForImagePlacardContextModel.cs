namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.Context
{
    public class LandscapeContextualTrailOverlapForImagePlacardContextModel : Contract.BaseLandscapeContextualOperlapForImagePlacardContextModel
    {
        public string OverlapBackgroundColor { get; set; }

        public Enumerations.OverlapTrailMode OverlapTrailMode { get; set; }

        public string TextColor { get; set; }

        public bool ContextedImageCenteredAtPresentation { get; set; }
    }
}
