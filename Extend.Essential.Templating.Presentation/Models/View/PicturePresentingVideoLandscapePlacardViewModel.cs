namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.View
{
    public class PicturePresentingVideoLandscapePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel, Facade.IPresentedByImagePlacardViewModelFacade
    {
        public PicturePresentingVideoLandscapePlacardViewModel()
        {
            PresentedVideoCenteredAtPresentation = false;
            PresenterSide = Enumerations.LandscapePresentationSide.Left;
        }

        public Xamarin.Forms.ImageSource PresenterSource { get; set; }

        public int PresenterImageWidth { get; set; }

        public int PresenterImageHeigth { get; set; }

        public Enumerations.LandscapePresentationSide PresenterSide { get; set; }

        public XFToolKit.Presentation.Sources.Video.VideoSource PresentedSource { get; set; }

        public bool PresentedVideoCenteredAtPresentation { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterSource = null;
            PresentedSource = null;
        }
    }
}
