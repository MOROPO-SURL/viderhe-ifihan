using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context.Contract;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context
{
    public class LandscapeFloatingFlyoutPlacardContextModel : AbstractImagedMuseographyPlacardContextModel
    {
        public FlyoutShapeKind FlyoutShapeKind { get; set; }

        public FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get; set; }

        public FlyoutHorizontalOrientation FlyoutHorizontalOrientation { get; set; }
    }
}
