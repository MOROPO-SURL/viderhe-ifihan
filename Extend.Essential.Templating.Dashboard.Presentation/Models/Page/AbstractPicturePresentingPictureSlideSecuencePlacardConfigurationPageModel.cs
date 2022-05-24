namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractPicturePresentingPictureSlideSecuencePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private Support.Presentation.Models.View.ImageViewModel presenterImage;
        private int pictureSlidePresentationSecounds;
        public System.Guid pictureTransitionId;
        private bool presentedPictureSlideSecuenceCenteredAtPresentation;

        public AbstractPicturePresentingPictureSlideSecuencePlacardConfigurationPageModel()
        {
            PictureSlidePresentationSecounds = 10;
            AvailableLayoutModes = new Enumerations.PictureLayoutMode[] 
            { 
                Enumerations.PictureLayoutMode.AspectFit, 
                Enumerations.PictureLayoutMode.AspectFill, 
                Enumerations.PictureLayoutMode.Fill, 
                Enumerations.PictureLayoutMode.AspectFitWithOpaqueAspectFilledBySelf
            };

            PresentedSlides = new System.Collections.ObjectModel.ObservableCollection<View.PictureSlideViewModel>();
        }

        public Support.Presentation.Models.View.ImageViewModel PresenterImage { get => presenterImage; set => SetProperty(ref presenterImage, value); }

        public System.Collections.ObjectModel.ObservableCollection<View.PictureSlideViewModel> PresentedSlides { get; set; }

        public Templating.Enumerations.PictureLayoutMode[] AvailableLayoutModes { get; private set; }
        
        public int PictureSlidePresentationSecounds { get => pictureSlidePresentationSecounds; set => SetProperty(ref pictureSlidePresentationSecounds, value); }

        public bool PresentedPictureSlideSecuenceCenteredAtPresentation { get => presentedPictureSlideSecuenceCenteredAtPresentation; set => SetProperty(ref presentedPictureSlideSecuenceCenteredAtPresentation, value); }
        
        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            PresenterImage = null;

            PresentedSlides.Clear();

            PresentedSlides = null;
        }
    }
}
