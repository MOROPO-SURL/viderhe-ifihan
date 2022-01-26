namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeCrossStripePlacardConfigurationPageModel : Contract.AbstractImagedMuseographyPlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.BackgroundColorMode stripeColorBackgroundMode;
        private bool isStripeBackgroundTranslucent;

        public LandscapeCrossStripePlacardConfigurationPageModel()
        {
            StripeColorBackgroundMode = Templating.Presentation.Enumerations.BackgroundColorMode.Primary;

            AvailableStripeColorBackgroundModes = new Templating.Presentation.Enumerations.BackgroundColorMode[]
            {
                Templating.Presentation.Enumerations.BackgroundColorMode.Primary,
                Templating.Presentation.Enumerations.BackgroundColorMode.Secoundary
            };
        }

        public Templating.Presentation.Enumerations.BackgroundColorMode StripeColorBackgroundMode { get => stripeColorBackgroundMode; set => SetProperty(ref stripeColorBackgroundMode, value); }

        public Templating.Presentation.Enumerations.BackgroundColorMode[] AvailableStripeColorBackgroundModes { get; private set; }

        public bool IsStripeBackgroundTranslucent { get => isStripeBackgroundTranslucent; set => SetProperty(ref isStripeBackgroundTranslucent, value); }
    }
}
