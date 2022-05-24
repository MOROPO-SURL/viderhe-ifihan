namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PortraitPicturePresentingVideoPlacardConfigurationPageModel : AbstractPicturePresentingVideoPlacardConfigurationPageModel
    {
        private Enumerations.PortraitPresentationSide presenterSide;

        public PortraitPicturePresentingVideoPlacardConfigurationPageModel()
        {
            PresenterSide = Enumerations.PortraitPresentationSide.Top;
        }

        public Enumerations.PortraitPresentationSide PresenterSide { get => presenterSide; set => SetProperty(ref presenterSide, value); }

        public Enumerations.PortraitPresentationSide[] PortraitPresentationSides { get => new[] { Enumerations.PortraitPresentationSide.Top, Enumerations.PortraitPresentationSide.Bottom }; }
    }
}
