namespace MOROPO.VIDERHE.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PortraitPicturePresentingPicturePlacardConfigurationPageModel : AbstractPicturePresentingPicturePlacardConfigurationPageModel
    {
        private Enumerations.PortraitPresentationSide presenterSide;

        public PortraitPicturePresentingPicturePlacardConfigurationPageModel()
        {
            PresenterSide = Enumerations.PortraitPresentationSide.Top;
        }

        public Enumerations.PortraitPresentationSide PresenterSide { get => presenterSide; set => SetProperty(ref presenterSide, value); }

        public Enumerations.PortraitPresentationSide[] PortraitPresentationSides { get => new[] { Enumerations.PortraitPresentationSide.Top, Enumerations.PortraitPresentationSide.Bottom }; }
    }
}
