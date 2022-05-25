using SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Enumerations;

namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractLandscapeContextedMediaPlacardConfigurationPageModel : AbstractContextedMediaPlacardConfigurationPageModel
    {
        private OverlapHorizontalAlignment pverlapHorizontalAlignment;

        public AbstractLandscapeContextedMediaPlacardConfigurationPageModel()
        {
            AvailableOverlapHorizontalAlignments = new OverlapHorizontalAlignment[]
            {
                OverlapHorizontalAlignment.Left,
                OverlapHorizontalAlignment.Right
            };
        }

        public OverlapHorizontalAlignment OverlapHorizontalAlignment { get => pverlapHorizontalAlignment; set => SetProperty(ref pverlapHorizontalAlignment, value); }

        public OverlapHorizontalAlignment[] AvailableOverlapHorizontalAlignments { get; private set; }
    }
}
