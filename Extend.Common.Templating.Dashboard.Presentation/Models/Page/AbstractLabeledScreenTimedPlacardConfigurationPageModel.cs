namespace MOROPO.VIDERHE.Extend.Common.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractLabeledScreenTimedPlacardConfigurationPageModel : AbstractLabeledPlacardConfigurationPageModel
    {
        private int screenPresentationTimeSecounds;

        public int ScreenPresentationTimeSecounds { get => screenPresentationTimeSecounds; set => SetProperty(ref screenPresentationTimeSecounds, value); }
    }
}
