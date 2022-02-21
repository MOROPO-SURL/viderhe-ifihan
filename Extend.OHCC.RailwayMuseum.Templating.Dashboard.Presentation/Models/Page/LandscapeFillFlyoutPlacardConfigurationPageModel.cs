namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeFillFlyoutPlacardConfigurationPageModel : Contract.AbstractImagedMuseographyPlacardConfigurationPageModel
    {
        private bool contextedImageCenteredAtPresentation;
        private Essential.Templating.Presentation.Enumerations.PictureLayoutMode contextedImageLayoutMode;
        private Templating.Presentation.Enumerations.FlyoutShapeKind flyoutShapeKind;
        private Templating.Presentation.Enumerations.FlyoutBackgroundColorMode flyoutBackgroundColorMode;
        private Templating.Presentation.Enumerations.FlyoutHorizontalOrientation flyoutHorizontalOrientation;

        public LandscapeFillFlyoutPlacardConfigurationPageModel()
        {
            contextedImageLayoutMode = Essential.Templating.Presentation.Enumerations.PictureLayoutMode.AspectFill;

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

            AvailableFlyoutHorizontalOrientations = new Templating.Presentation.Enumerations.FlyoutHorizontalOrientation[]
            {
                Templating.Presentation.Enumerations.FlyoutHorizontalOrientation.Left,
                Templating.Presentation.Enumerations.FlyoutHorizontalOrientation.Right
            };

            AvailableLayoutModes = new Essential.Templating.Presentation.Enumerations.PictureLayoutMode[] 
            { 
                Essential.Templating.Presentation.Enumerations.PictureLayoutMode.AspectFit,
                Essential.Templating.Presentation.Enumerations.PictureLayoutMode.AspectFill,
                Essential.Templating.Presentation.Enumerations.PictureLayoutMode.Fill,
                Essential.Templating.Presentation.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf 
            };
        }

        public bool ContextedImageCenteredAtPresentation { get => contextedImageCenteredAtPresentation; set => SetProperty(ref contextedImageCenteredAtPresentation, value); }

        public Essential.Templating.Presentation.Enumerations.PictureLayoutMode ContextedImageLayoutMode { get => contextedImageLayoutMode; set => SetProperty(ref contextedImageLayoutMode, value); }

        public Templating.Presentation.Enumerations.FlyoutShapeKind FlyoutShapeKind { get => flyoutShapeKind; set => SetProperty(ref flyoutShapeKind, value); }

        public Templating.Presentation.Enumerations.FlyoutShapeKind[] AvailableFlyoutShapeKinds { get; private set; }

        public Templating.Presentation.Enumerations.FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get => flyoutBackgroundColorMode; set => SetProperty(ref flyoutBackgroundColorMode, value); }

        public Templating.Presentation.Enumerations.FlyoutBackgroundColorMode[] AvailableFlyoutBackgroundColorModes { get; private set; }

        public Templating.Presentation.Enumerations.FlyoutHorizontalOrientation FlyoutHorizontalOrientation { get => flyoutHorizontalOrientation; set => SetProperty(ref flyoutHorizontalOrientation, value); }

        public Templating.Presentation.Enumerations.FlyoutHorizontalOrientation[] AvailableFlyoutHorizontalOrientations { get; private set; }

        public Essential.Templating.Presentation.Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }
    }
}
