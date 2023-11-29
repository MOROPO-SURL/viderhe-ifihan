namespace MOROPO.VIDERHE.Extend.Essential.Templating.Presentation.Models.View
{
    public abstract class AbstractPicturePresentingVideoPlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel, Facade.IPresentedByImagePlacardViewModelFacade
    {
        public AbstractPicturePresentingVideoPlacardViewModel()
        {
            PresentedVideoCenteredAtPresentation = false;
        }

        public Xamarin.Forms.ImageSource PresenterSource { get; set; }

        public int PresenterImageWidth { get; set; }

        public int PresenterImageHeigth { get; set; }

        public SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource PresentedSource { get; set; }

        public bool PresentedVideoCenteredAtPresentation { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterSource = null;
            PresentedSource = null;
        }
    }
}
