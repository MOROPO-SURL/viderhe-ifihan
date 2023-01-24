namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block
{
    public class TransparentSeparatorContentBlockConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private Enumerations.SeparatorSizingMode sizingMode;

        public TransparentSeparatorContentBlockConfigurationPageModel()
        {
            Id = System.Guid.NewGuid();

            AvailableSizingModes = (Enumerations.SeparatorSizingMode[])System.Enum.GetValues(typeof(Enumerations.SeparatorSizingMode));
        }
        
        public System.Guid Id { get; set; }

        public Enumerations.SeparatorSizingMode SizingMode { get => sizingMode; set => SetProperty(ref sizingMode, value); }

        public Enumerations.SeparatorSizingMode[] AvailableSizingModes { get; private set; }
    }
}
