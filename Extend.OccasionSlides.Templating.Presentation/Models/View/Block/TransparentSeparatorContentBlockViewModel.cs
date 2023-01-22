namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block
{
    public class TransparentSeparatorContentBlockViewModel : Contract.AbstractContentBlockViewModel, Contract.IScreenVerticalSizePercentCalculableContentBlockViewModel
    {
        private double heightByScreenVerticalSizePercent;

        public double HeightByScreenVerticalSizePercent { get => heightByScreenVerticalSizePercent; set => SetProperty(ref heightByScreenVerticalSizePercent, value); }
    }
}
