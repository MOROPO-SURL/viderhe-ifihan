using MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Enumerations;
using MOROPO.VIDERHE.Extend.Essential.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapeFillFlyoutPlacardConfigurationPageModel : Contract.AbstractImagedMuseographyPlacardConfigurationPageModel
    {
        private bool contextedImageCenteredAtPresentation;
        private PictureLayoutMode contextedImageLayoutMode;
        private FlyoutShapeKind flyoutShapeKind;
        private FlyoutBackgroundColorMode flyoutBackgroundColorMode;
        private FlyoutHorizontalOrientation flyoutHorizontalOrientation;

        public LandscapeFillFlyoutPlacardConfigurationPageModel()
        {
            contextedImageLayoutMode = PictureLayoutMode.AspectFill;

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

            AvailableLayoutModes = new PictureLayoutMode[]
            {
                PictureLayoutMode.AspectFit,
                PictureLayoutMode.AspectFill,
                PictureLayoutMode.Fill,
                PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf
            };
        }

        public bool ContextedImageCenteredAtPresentation { get => contextedImageCenteredAtPresentation; set => SetProperty(ref contextedImageCenteredAtPresentation, value); }

        public PictureLayoutMode ContextedImageLayoutMode { get => contextedImageLayoutMode; set => SetProperty(ref contextedImageLayoutMode, value); }

        public FlyoutShapeKind FlyoutShapeKind { get => flyoutShapeKind; set => SetProperty(ref flyoutShapeKind, value); }

        public FlyoutShapeKind[] AvailableFlyoutShapeKinds { get; private set; }

        public FlyoutBackgroundColorMode FlyoutBackgroundColorMode { get => flyoutBackgroundColorMode; set => SetProperty(ref flyoutBackgroundColorMode, value); }

        public FlyoutBackgroundColorMode[] AvailableFlyoutBackgroundColorModes { get; private set; }

        public FlyoutHorizontalOrientation FlyoutHorizontalOrientation { get => flyoutHorizontalOrientation; set => SetProperty(ref flyoutHorizontalOrientation, value); }

        public FlyoutHorizontalOrientation[] AvailableFlyoutHorizontalOrientations { get; private set; }

        public PictureLayoutMode[] AvailableLayoutModes { get; private set; }
    }
}
