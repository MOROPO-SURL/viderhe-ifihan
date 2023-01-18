namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Models.View.Block.Contract
{
    public abstract class AbstractContentBlockViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private int priority;

        public System.Guid Id { get; set; }

        public int Priority { get => priority; set => SetProperty(ref priority, value); }
    }
}
