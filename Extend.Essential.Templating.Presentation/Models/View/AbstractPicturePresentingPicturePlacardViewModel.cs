namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Models.View
{
    public abstract class AbstractPicturePresentingPicturePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel, Facade.IPresentedByImagePlacardViewModelFacade
    {
        public AbstractPicturePresentingPicturePlacardViewModel()
        {
            PresentedImageZoomingEnabled = false;
            PresentedImageCenteredAtPresentation = false;
        }

        public Xamarin.Forms.ImageSource PresenterSource { get; set; }

        public int PresenterImageWidth { get; set; }

        public int PresenterImageHeigth { get; set; }

        public Xamarin.Forms.ImageSource PresentedSource { get; set; }

        public bool PresentedImageZoomingEnabled { get; set; }

        public bool PresentedImageCenteredAtPresentation { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterSource = null;
            PresentedSource = null;
        }
    }
}
