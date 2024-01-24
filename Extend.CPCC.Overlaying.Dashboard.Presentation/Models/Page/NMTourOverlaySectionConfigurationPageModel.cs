namespace MOROPO.VIDERHE.Extend.CPCC.Overlaying.Dashboard.Presentation.Models.Page
{
    public class NMTourOverlaySectionConfigurationPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string glyph;
        private string title;
        private string action;

        public string Glyph { get => glyph; set => SetProperty(ref glyph, value); }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public string Action { get => action; set => SetProperty(ref action, value); }
    }
}
