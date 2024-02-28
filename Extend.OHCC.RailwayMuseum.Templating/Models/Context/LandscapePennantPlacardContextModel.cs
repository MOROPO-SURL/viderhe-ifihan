using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context.Contract;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context
{
    public class LandscapePennantPlacardContextModel : AbstractImagedMuseographyPlacardContextModel
    {
        public FlyoutShapeKind FlyoutShapeKind { get; set; }

        public FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get; set; }

        public PennantVerticalOrientation PennantVerticalOrientation { get; set; }
    }
}
