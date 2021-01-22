namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PortraitPicturePresentingPicturePlacardConfigurationPageModel : AbstractPicturePresentingPicturePlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.PortraitPresentationSide presenterSide;

        public PortraitPicturePresentingPicturePlacardConfigurationPageModel()
        {
            PresenterSide = Templating.Presentation.Enumerations.PortraitPresentationSide.Top;
        }

        public Templating.Presentation.Enumerations.PortraitPresentationSide PresenterSide { get => presenterSide; set => SetProperty(ref presenterSide, value); }

        public Templating.Presentation.Enumerations.PortraitPresentationSide[] PortraitPresentationSides { get => new[] { Templating.Presentation.Enumerations.PortraitPresentationSide.Top, Templating.Presentation.Enumerations.PortraitPresentationSide.Bottom }; }
    }
}
