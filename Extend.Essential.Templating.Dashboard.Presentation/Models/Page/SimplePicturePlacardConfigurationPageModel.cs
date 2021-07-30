namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class SimplePicturePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel image;
        private Templating.Presentation.Enumerations.PictureLayoutMode layoutMode;
        private bool isZoomingEnabled;

        public SimplePicturePlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;

            AvailableLayoutModes = new Templating.Presentation.Enumerations.PictureLayoutMode[] { Templating.Presentation.Enumerations.PictureLayoutMode.AspectFit, Templating.Presentation.Enumerations.PictureLayoutMode.AspectFill, Templating.Presentation.Enumerations.PictureLayoutMode.Fill, Templating.Presentation.Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf };
        }

        public Templating.Presentation.Enumerations.PictureLayoutMode LayoutMode { get => layoutMode; set => SetProperty(ref layoutMode, value); }

        public Support.Presentation.Models.View.ImageViewModel Image { get => image; set => SetProperty(ref image, value); }

        public bool IsZoomingEnabled { get => isZoomingEnabled; set => SetProperty(ref isZoomingEnabled, value); }

        public Templating.Presentation.Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Image = null;

            AvailableLayoutModes = null;
        }
    }
}
