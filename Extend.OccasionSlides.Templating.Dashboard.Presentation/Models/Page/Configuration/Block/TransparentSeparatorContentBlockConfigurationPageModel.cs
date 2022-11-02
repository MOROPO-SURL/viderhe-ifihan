namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.Page.Configuration.Block
{
    public class TransparentSeparatorContentBlockConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private double heightByScreenVerticalSizePercent;

        public System.Guid Id { get; set; }

        public double HeightByScreenVerticalSizePercent { get => heightByScreenVerticalSizePercent; set => SetProperty(ref heightByScreenVerticalSizePercent, value); }
    }
}
