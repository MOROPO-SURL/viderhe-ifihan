namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractLandscapeContextedMediaPlacardConfigurationPageModel : AbstractContextedMediaPlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.MediaContextOverlayHorizontalAlignment overlayHorizontalAlignment;

        public AbstractLandscapeContextedMediaPlacardConfigurationPageModel()
        {
            AvailableOverlayHorizontalAlignments = new Templating.Presentation.Enumerations.MediaContextOverlayHorizontalAlignment[]
            {
                Templating.Presentation.Enumerations.MediaContextOverlayHorizontalAlignment.Left,
                Templating.Presentation.Enumerations.MediaContextOverlayHorizontalAlignment.Right
            };
        }

        public Templating.Presentation.Enumerations.MediaContextOverlayHorizontalAlignment OverlayHorizontalAlignment { get => overlayHorizontalAlignment; set => SetProperty(ref overlayHorizontalAlignment, value); }

        public Templating.Presentation.Enumerations.MediaContextOverlayHorizontalAlignment[] AvailableOverlayHorizontalAlignments { get; private set; }
    }
}
