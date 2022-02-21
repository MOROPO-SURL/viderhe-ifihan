namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.Context
{
    public class LandscapeFillFlyoutPlacardContextModel : Contract.AbstractImagedMuseographyPlacardContextModel
    {
        public LandscapeFillFlyoutPlacardContextModel()
        {
            ContextedImageLayoutMode = Essential.Templating.Presentation.Enumerations.PictureLayoutMode.AspectFill;
        }

        public Essential.Templating.Presentation.Enumerations.PictureLayoutMode ContextedImageLayoutMode { get; set; }

        public Enumerations.FlyoutShapeKind FlyoutShapeKind { get; set; }

        public Enumerations.FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get; set; }

        public Enumerations.FlyoutHorizontalOrientation FlyoutHorizontalOrientation { get; set; }

        public bool ContextedImageCenteredAtPresentation { get; set; }
    }
}
