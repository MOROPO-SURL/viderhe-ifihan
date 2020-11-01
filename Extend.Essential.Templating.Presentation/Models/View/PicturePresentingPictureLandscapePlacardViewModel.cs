namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.View
{
    public class PicturePresentingPictureLandscapePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public PicturePresentingPictureLandscapePlacardViewModel()
        {
            PresentedImageZoomingEnabled = false;
            PresentedImageCenteredAtPresentation = false;
            PresenterSide = Enumerations.LandscapePresentationSide.Left;
        }

        public Xamarin.Forms.ImageSource PresenterSource { get; set; }

        public int PresenterImageWidth { get; set; }

        public int PresenterImageHeigth { get; set; }

        public Xamarin.Forms.ImageSource PresentedSource { get; set; }

        public bool PresentedImageZoomingEnabled { get; set; }

        public bool PresentedImageCenteredAtPresentation { get; set; }

        public Enumerations.LandscapePresentationSide PresenterSide { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterSource = null;
            PresentedSource = null;
        }
    }
}
