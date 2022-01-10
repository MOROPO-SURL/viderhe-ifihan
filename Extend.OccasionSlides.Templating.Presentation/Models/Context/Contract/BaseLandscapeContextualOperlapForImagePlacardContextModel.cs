namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.Context.Contract
{
    public class BaseLandscapeContextualOperlapForImagePlacardContextModel : AbstractLandscapeContextedMediaPlacardContextModel
    {
        internal BaseLandscapeContextualOperlapForImagePlacardContextModel()
        {

        }

        public Common.Templating.Presentation.Models.Context.ImageContextModel ContextedImage { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }
    }
}
