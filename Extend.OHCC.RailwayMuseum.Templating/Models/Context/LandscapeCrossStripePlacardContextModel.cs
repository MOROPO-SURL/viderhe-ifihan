namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Models.Context
{
    public class LandscapeCrossStripePlacardContextModel : Contract.AbstractImagedMuseographyPlacardContextModel
    {
        public bool IsStripeBackgroundTranslucent { get; set; }

        public Enumerations.BackgroundColorMode StripeColorBackgroundMode { get; set; }
    }
}
