using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View.Contract;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View
{
    public class LandscapeFramedPlacardViewModel : AbstractMuseographyPlacardViewModel
    {
        public Enumerations.FrameStyle FrameStyle { get; set; }

        public Enumerations.BackgroundMode BackgroundMode { get; set; }
    }
}
