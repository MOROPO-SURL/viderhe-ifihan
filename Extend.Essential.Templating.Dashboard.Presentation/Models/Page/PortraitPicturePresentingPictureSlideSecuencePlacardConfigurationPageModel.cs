namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPageModel : AbstractPicturePresentingPictureSlideSecuencePlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.PortraitPresentationSide presenterSide;

        public PortraitPicturePresentingPictureSlideSecuencePlacardConfigurationPageModel()
        {
            PresenterSide = Templating.Presentation.Enumerations.PortraitPresentationSide.Top;
        }

        public Templating.Presentation.Enumerations.PortraitPresentationSide PresenterSide { get => presenterSide; set => SetProperty(ref presenterSide, value); }

        public Templating.Presentation.Enumerations.PortraitPresentationSide[] PortraitPresentationSides { get => new[] { Templating.Presentation.Enumerations.PortraitPresentationSide.Top, Templating.Presentation.Enumerations.PortraitPresentationSide.Bottom }; }
    }
}
