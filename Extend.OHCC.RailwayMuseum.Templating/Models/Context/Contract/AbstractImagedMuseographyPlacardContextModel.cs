namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Models.Context.Contract
{
    public abstract class AbstractImagedMuseographyPlacardContextModel : AbstractMuseographyPlacardContextModel
    {
        public Common.Templating.Models.Context.ImageContextModel ContextedImage { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }
    }
}
