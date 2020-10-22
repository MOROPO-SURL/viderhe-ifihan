namespace SmartSolucionesCuba.Videre.Extend.Common.Templating.Dashboard.Presentation.Models.Page
{
    public abstract class AbstractPlacardConfigurationPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private bool requireUnobstructedPresetation;

        public bool RequireUnobstructedPresetation { get => requireUnobstructedPresetation; set => SetProperty(ref requireUnobstructedPresetation, value); }
    }
}
