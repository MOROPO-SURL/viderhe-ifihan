namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapePennantTrainPlacardConfigurationPageModel : Contract.AbstractImagedMuseographyPlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.FlyoutShapeKind flyoutShapeKind;
        private Templating.Presentation.Enumerations.FlyoutBackgroundColorMode flyoutBackgroundColorMode;
        private Templating.Presentation.Enumerations.PennantVerticalOrientation pennantVerticalOrientation;

        public LandscapePennantTrainPlacardConfigurationPageModel()
        {
            AvailableFlyoutShapeKinds = new Templating.Presentation.Enumerations.FlyoutShapeKind[]
            {
                Templating.Presentation.Enumerations.FlyoutShapeKind.Train,
                Templating.Presentation.Enumerations.FlyoutShapeKind.Tally
            };

            AvailableFlyoutBackgroundColorModes = new Templating.Presentation.Enumerations.FlyoutBackgroundColorMode[]
            {
                Templating.Presentation.Enumerations.FlyoutBackgroundColorMode.Primary,
                Templating.Presentation.Enumerations.FlyoutBackgroundColorMode.Secoundary,
                Templating.Presentation.Enumerations.FlyoutBackgroundColorMode.Light,
                Templating.Presentation.Enumerations.FlyoutBackgroundColorMode.Dark
            };

            AvailablePennantVerticalOrientations = new Templating.Presentation.Enumerations.PennantVerticalOrientation[]
            {
                Templating.Presentation.Enumerations.PennantVerticalOrientation.Top,
                Templating.Presentation.Enumerations.PennantVerticalOrientation.Bottom
            };
        }

        public Templating.Presentation.Enumerations.FlyoutShapeKind FlyoutShapeKind { get => flyoutShapeKind; set => SetProperty(ref flyoutShapeKind, value); }

        public Templating.Presentation.Enumerations.FlyoutShapeKind[] AvailableFlyoutShapeKinds { get; private set; }

        public Templating.Presentation.Enumerations.FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get => flyoutBackgroundColorMode; set => SetProperty(ref flyoutBackgroundColorMode, value); }

        public Templating.Presentation.Enumerations.FlyoutBackgroundColorMode[] AvailableFlyoutBackgroundColorModes { get; private set; }

        public Templating.Presentation.Enumerations.PennantVerticalOrientation PennantVerticalOrientation { get => pennantVerticalOrientation; set => SetProperty(ref pennantVerticalOrientation, value); }

        public Templating.Presentation.Enumerations.PennantVerticalOrientation[] AvailablePennantVerticalOrientations { get; private set; }
    }
}
