using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View.Contract;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View
{
    public class LandscapePennantPlacardViewModel : AbstractImageMuseographyPlacardViewModel
    {
        public Enumerations.FlyoutShapeKind FlyoutShapeKind { get; set; }

        public Enumerations.FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get; set; }

        public Enumerations.PennantVerticalOrientation PennantVerticalOrientation { get; set; }
    }
}
