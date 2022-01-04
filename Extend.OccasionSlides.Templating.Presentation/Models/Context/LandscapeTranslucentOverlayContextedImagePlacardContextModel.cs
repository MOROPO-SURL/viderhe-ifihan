namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.Context
{
    public class LandscapeTranslucentOverlayContextedImagePlacardContextModel : Contract.AbstractLandscapeContextedMediaPlacardContextModel
    {
        public string OverlayBackgroundColor { get; set; }

        public string TextColor { get; set; }

        public Common.Templating.Presentation.Models.Context.ImageContextModel ContextedImage { get; set; }
    }
}
