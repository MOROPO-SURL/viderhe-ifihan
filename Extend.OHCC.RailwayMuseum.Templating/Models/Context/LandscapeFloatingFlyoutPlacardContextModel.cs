namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Models.Context
{
    public class LandscapeFloatingFlyoutPlacardContextModel : Contract.AbstractImagedMuseographyPlacardContextModel
    {
        public Enumerations.FlyoutShapeKind FlyoutShapeKind { get; set; }

        public Enumerations.FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get; set; }

        public Enumerations.FlyoutHorizontalOrientation FlyoutHorizontalOrientation { get; set; }
    }
}
