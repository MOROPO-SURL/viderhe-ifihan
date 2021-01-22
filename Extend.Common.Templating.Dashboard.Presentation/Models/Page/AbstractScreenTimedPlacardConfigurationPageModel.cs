namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Dashboard.Presentation.Models.Page
{
    public class AbstractScreenTimedPlacardConfigurationPageModel : AbstractPlacardConfigurationPageModel
    {
        private int screenPresentationTimeSecounds;

        public int ScreenPresentationTimeSecounds { get => screenPresentationTimeSecounds; set => SetProperty(ref screenPresentationTimeSecounds, value); }
    }
}
