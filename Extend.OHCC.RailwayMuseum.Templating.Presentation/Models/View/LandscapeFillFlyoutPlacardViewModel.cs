namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.View
{
    public class LandscapeFillFlyoutPlacardViewModel : Contract.AbstractMuseographyPlacardViewModel
    {
        public Common.Templating.Presentation.Models.Context.ImageContextModel ContextedImage { get; set; }

        public bool ContextedImageZoomingEnabled { get; set; }

        public Essential.Templating.Presentation.Enumerations.PictureLayoutMode ContextedImageLayoutMode { get; set; }

        public Enumerations.FlyoutShapeKind FlyoutShapeKind { get; set; }

        public Enumerations.FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get; set; }

        public Enumerations.FlyoutHorizontalOrientation FlyoutHorizontalOrientation { get; set; }

        public bool ContextedImageCenteredAtPresentation { get; set; }
    }
}
