namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.Context.Contract
{
    public abstract class AbstractImagedMuseographyPlacardContextModel : AbstractMuseographyPlacardContextModel
    {
        public Common.Templating.Presentation.Models.Context.ImageContextModel ContextedImage { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }
    }
}
