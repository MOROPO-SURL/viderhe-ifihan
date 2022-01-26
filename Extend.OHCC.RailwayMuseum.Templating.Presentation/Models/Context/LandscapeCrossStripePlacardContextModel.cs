namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Presentation.Models.Context
{
    public class LandscapeCrossStripePlacardContextModel : Contract.AbstractImagedMuseographyPlacardContextModel
    {
        public bool IsStripeBackgroundTranslucent { get; set; }

        public Enumerations.BackgroundColorMode StripeColorBackgroundMode { get; set; }
    }
}
