using SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeFloatingFlyoutPlacardConfigurationPageModel : Contract.AbstractImagedMuseographyPlacardConfigurationPageModel
    {
        private FlyoutShapeKind flyoutShapeKind;
        private FlyoutBackgroundColorMode flyoutBackgroundColorMode;
        private FlyoutHorizontalOrientation flyoutHorizontalOrientation;

        public LandscapeFloatingFlyoutPlacardConfigurationPageModel()
        {
            AvailableFlyoutShapeKinds = new FlyoutShapeKind[]
            {
                FlyoutShapeKind.Train,
                FlyoutShapeKind.Tally
            };

            AvailableFlyoutBackgroundColorModes = new FlyoutBackgroundColorMode[]
            {
                FlyoutBackgroundColorMode.Primary,
                FlyoutBackgroundColorMode.Secoundary,
                FlyoutBackgroundColorMode.Light,
                FlyoutBackgroundColorMode.Dark
            };

            AvailableFlyoutHorizontalOrientations = new FlyoutHorizontalOrientation[]
            {
                FlyoutHorizontalOrientation.Left,
                FlyoutHorizontalOrientation.Right
            };
        }

        public FlyoutShapeKind FlyoutShapeKind { get => flyoutShapeKind; set => SetProperty(ref flyoutShapeKind, value); }

        public FlyoutShapeKind[] AvailableFlyoutShapeKinds { get; private set; }

        public FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get => flyoutBackgroundColorMode; set => SetProperty(ref flyoutBackgroundColorMode, value); }

        public FlyoutBackgroundColorMode[] AvailableFlyoutBackgroundColorModes { get; private set; }

        public FlyoutHorizontalOrientation FlyoutHorizontalOrientation { get => flyoutHorizontalOrientation; set => SetProperty(ref flyoutHorizontalOrientation, value); }

        public FlyoutHorizontalOrientation[] AvailableFlyoutHorizontalOrientations { get; private set; }
    }
}
