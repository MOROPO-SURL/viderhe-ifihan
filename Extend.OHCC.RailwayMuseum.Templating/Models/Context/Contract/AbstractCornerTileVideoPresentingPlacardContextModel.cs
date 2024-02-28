using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context.Contract
{
    public abstract class AbstractCornerTileVideoPresentingPlacardContextModel : Common.Templating.Models.Context.AbstractPlacardContextModel
    {
        public Common.Templating.Models.Context.VideoContextModel PresenterTileVideo { get; set; }

        public ScreenCorner PresenterTileVideoScreenCorner { get; set; }

        public System.TimeSpan PresenterTileVideoPlayDelay { get; set; }
    }
}
