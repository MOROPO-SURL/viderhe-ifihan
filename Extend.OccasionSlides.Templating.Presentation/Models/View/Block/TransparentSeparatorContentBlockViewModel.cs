namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class TransparentSeparatorContentBlockViewModel : Contract.AbstractContentBlockViewModel
    {
        private Enumerations.SeparatorSizingMode sizingMode;

        public Enumerations.SeparatorSizingMode SizingMode { get => sizingMode; set => SetProperty(ref sizingMode, value); }
    }
}
