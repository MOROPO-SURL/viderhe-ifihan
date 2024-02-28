using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Models.Context
{
    public class LandscapeFillFlyoutPlacardContextModel : Contract.AbstractImagedMuseographyPlacardContextModel
    {
        public LandscapeFillFlyoutPlacardContextModel()
        {
            ContextedImageLayoutMode = Essential.Templating.Enumerations.PictureLayoutMode.AspectFill;
        }

        public Essential.Templating.Enumerations.PictureLayoutMode ContextedImageLayoutMode { get; set; }

        public FlyoutShapeKind FlyoutShapeKind { get; set; }

        public FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get; set; }

        public FlyoutHorizontalOrientation FlyoutHorizontalOrientation { get; set; }

        public bool ContextedImageCenteredAtPresentation { get; set; }
    }
}
