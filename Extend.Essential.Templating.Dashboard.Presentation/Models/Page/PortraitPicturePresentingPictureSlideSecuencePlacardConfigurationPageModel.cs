namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPageModel : AbstractPicturePresentingPictureSlideSecuencePlacardConfigurationPageModel
    {
        private Enumerations.PortraitPresentationSide presenterSide;

        public PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPageModel()
        {
            PresenterSide = Enumerations.PortraitPresentationSide.Top;
        }

        public Enumerations.PortraitPresentationSide PresenterSide { get => presenterSide; set => SetProperty(ref presenterSide, value); }

        public Enumerations.PortraitPresentationSide[] PortraitPresentationSides { get => new[] { Enumerations.PortraitPresentationSide.Top, Enumerations.PortraitPresentationSide.Bottom }; }
    }
}
