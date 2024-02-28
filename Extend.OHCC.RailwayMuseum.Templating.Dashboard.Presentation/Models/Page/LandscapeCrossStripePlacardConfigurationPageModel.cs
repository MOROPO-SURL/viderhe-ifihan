using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeCrossStripePlacardConfigurationPageModel : Contract.AbstractImagedMuseographyPlacardConfigurationPageModel
    {
        private BackgroundColorMode stripeColorBackgroundMode;
        private bool isStripeBackgroundTranslucent;

        public LandscapeCrossStripePlacardConfigurationPageModel()
        {
            StripeColorBackgroundMode = BackgroundColorMode.Primary;

            AvailableStripeColorBackgroundModes = new BackgroundColorMode[]
            {
                BackgroundColorMode.Primary,
                BackgroundColorMode.Secoundary
            };
        }

        public BackgroundColorMode StripeColorBackgroundMode { get => stripeColorBackgroundMode; set => SetProperty(ref stripeColorBackgroundMode, value); }

        public BackgroundColorMode[] AvailableStripeColorBackgroundModes { get; private set; }

        public bool IsStripeBackgroundTranslucent { get => isStripeBackgroundTranslucent; set => SetProperty(ref isStripeBackgroundTranslucent, value); }
    }
}
