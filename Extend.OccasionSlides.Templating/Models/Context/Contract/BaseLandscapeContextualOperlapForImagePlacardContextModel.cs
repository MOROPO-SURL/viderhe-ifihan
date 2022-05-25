namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Models.Context.Contract
{
    public class BaseLandscapeContextualOperlapForImagePlacardContextModel : AbstractLandscapeContextedMediaPlacardContextModel
    {
        internal BaseLandscapeContextualOperlapForImagePlacardContextModel()
        {

        }

        public Common.Templating.Models.Context.ImageContextModel ContextedImage { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }
    }
}
