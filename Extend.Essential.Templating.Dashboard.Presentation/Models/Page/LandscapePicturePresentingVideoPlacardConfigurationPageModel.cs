namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class LandscapePicturePresentingVideoPlacardConfigurationPageModel : AbstractPicturePresentingVideoPlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.LandscapePresentationSide presenterSide;

        public LandscapePicturePresentingVideoPlacardConfigurationPageModel()
        {
            PresenterSide = Templating.Presentation.Enumerations.LandscapePresentationSide.Left;
        }

        public Templating.Presentation.Enumerations.LandscapePresentationSide PresenterSide { get => presenterSide; set => SetProperty(ref presenterSide, value); }

        public Templating.Presentation.Enumerations.LandscapePresentationSide[] LandscapePresentationSides { get => new[] { Templating.Presentation.Enumerations.LandscapePresentationSide.Left, Templating.Presentation.Enumerations.LandscapePresentationSide.Right }; }
    }
}
