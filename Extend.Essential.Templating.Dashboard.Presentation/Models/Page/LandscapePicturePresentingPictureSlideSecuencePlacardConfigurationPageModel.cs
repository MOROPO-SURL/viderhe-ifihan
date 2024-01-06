namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapePicturePresentingPictureSlideSecuencePlacardConfigurationPageModel : AbstractPicturePresentingPictureSlideSecuencePlacardConfigurationPageModel
    {
        private Enumerations.LandscapePresentationSide presenterSide;

        public LandscapePicturePresentingPictureSlideSecuencePlacardConfigurationPageModel()
        {
            PresenterSide = Enumerations.LandscapePresentationSide.Left;
        }

        public Enumerations.LandscapePresentationSide PresenterSide { get => presenterSide; set => SetProperty(ref presenterSide, value); }

        public Enumerations.LandscapePresentationSide[] LandscapePresentationSides { get => new[] { Enumerations.LandscapePresentationSide.Left, Enumerations.LandscapePresentationSide.Right }; }
    }
}