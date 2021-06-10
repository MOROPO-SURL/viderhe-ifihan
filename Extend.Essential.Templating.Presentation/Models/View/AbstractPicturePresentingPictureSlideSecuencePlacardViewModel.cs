namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Presentation.Models.View
{
    public abstract class AbstractPicturePresentingPictureSlideSecuencePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractPlacardViewModel, Facade.IPresentedByImagePlacardViewModelFacade
    {
        public AbstractPicturePresentingPictureSlideSecuencePlacardViewModel()
        {
            PresentedPictureSlideSecuenceCenteredAtPresentation = false;
        }

        public Xamarin.Forms.ImageSource PresenterSource { get; set; }

        public int PresenterImageWidth { get; set; }

        public int PresenterImageHeigth { get; set; }

        public Context.PictureSlideSecuencePlacardContextModel PresentedPictureSlideSecuence { get; set; }

        public bool PresentedPictureSlideSecuenceCenteredAtPresentation { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterSource = null;
        }
    }
}
