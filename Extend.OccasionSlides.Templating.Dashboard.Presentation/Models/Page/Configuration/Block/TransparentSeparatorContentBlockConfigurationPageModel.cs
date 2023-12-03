using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block
{
    public class TransparentSeparatorContentBlockConfigurationPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private SeparatorSizingMode sizingMode;

        public TransparentSeparatorContentBlockConfigurationPageModel()
        {
            Id = System.Guid.NewGuid();

            AvailableSizingModes = (SeparatorSizingMode[])System.Enum.GetValues(typeof(SeparatorSizingMode));
        }

        public System.Guid Id { get; set; }

        public SeparatorSizingMode SizingMode { get => sizingMode; set => SetProperty(ref sizingMode, value); }

        public SeparatorSizingMode[] AvailableSizingModes { get; private set; }
    }
}
