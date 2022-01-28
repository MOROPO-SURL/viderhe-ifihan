namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.Context
{
    public class LandscapePennantPlacardContextModel : Contract.AbstractImagedMuseographyPlacardContextModel
    {
        public Enumerations.FlyoutShapeKind FlyoutShapeKind { get; set; }

        public Enumerations.FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get; set; }

        public Enumerations.PennantVerticalOrientation PennantVerticalOrientation { get; set; }
    }
}
