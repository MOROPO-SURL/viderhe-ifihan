using MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Models.Page;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class SimplePicturePlacardConfigurationPageModel : AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private ImageViewModel image;
        private Enumerations.PictureLayoutMode layoutMode;
        private bool isZoomingEnabled;

        public SimplePicturePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;

            AvailableLayoutModes = new Enumerations.PictureLayoutMode[]
            {
                Enumerations.PictureLayoutMode.AspectFit,
                Enumerations.PictureLayoutMode.AspectFill,
                Enumerations.PictureLayoutMode.Fill,
                Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf
            };
        }

        public Enumerations.PictureLayoutMode LayoutMode { get => layoutMode; set => SetProperty(ref layoutMode, value); }

        public ImageViewModel Image { get => image; set => SetProperty(ref image, value); }

        public bool IsZoomingEnabled { get => isZoomingEnabled; set => SetProperty(ref isZoomingEnabled, value); }

        public Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image = null;

            AvailableLayoutModes = null;
        }
    }
}
