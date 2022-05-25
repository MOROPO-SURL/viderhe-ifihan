namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Models.Context.Contract
{
    public abstract class AbstractCornerTileVideoPresentingPlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Common.Templating.Models.Context.VideoContextModel PresenterTileVideo { get; set; }

        public Enumerations.ScreenCorner PresenterTileVideoScreenCorner { get; set; }

        public System.TimeSpan PresenterTileVideoPlayDelay { get; set; }
    }
}
