namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractLandscapeContextedMediaPlacardConfigurationPageModel : AbstractContextedMediaPlacardConfigurationPageModel
    {
        private Templating.Presentation.Enumerations.OverlapHorizontalAlignment pverlapHorizontalAlignment;

        public AbstractLandscapeContextedMediaPlacardConfigurationPageModel()
        {
            AvailableOverlapHorizontalAlignments = new Templating.Presentation.Enumerations.OverlapHorizontalAlignment[]
            {
                Templating.Presentation.Enumerations.OverlapHorizontalAlignment.Left,
                Templating.Presentation.Enumerations.OverlapHorizontalAlignment.Right
            };
        }

        public Templating.Presentation.Enumerations.OverlapHorizontalAlignment OverlapHorizontalAlignment { get => pverlapHorizontalAlignment; set => SetProperty(ref pverlapHorizontalAlignment, value); }

        public Templating.Presentation.Enumerations.OverlapHorizontalAlignment[] AvailableOverlapHorizontalAlignments { get; private set; }
    }
}
