namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View
{
    public class LandscapeContextualTranslucentOverlapForImagePlacardViewModel : Contract.AbstractLandscapeContextualOperlapForImagePlacardViewModel, Contract.IContextualOverlapPlacardViewModelSKPathTransformable
    {
        public Xamarin.Forms.Color OverlapBackgroundColor { get; set; }

        public Enumerations.OverlapTrailMode OverlapTrailMode { get; set; }

        public Xamarin.Forms.Color TextColor { get; set; }
    }
}
