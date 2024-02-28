using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context
{
    public class LandscapeFramedPlacardContextModel : Contract.AbstractMuseographyPlacardContextModel
    {
        public FrameStyle FrameStyle { get; set; }

        public BackgroundMode BackgroundMode { get; set; }
    }
}
