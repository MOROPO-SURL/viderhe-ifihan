namespace SmartSolucionesCuba.Viderhe.Extend.CPCC.Overlaying.Presentation.Models.Page
{
    public class WebPortalPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        public string Title { get; set; }

        public System.Uri Url { get; set; }

        public bool IsNavigationEnabled { get; set; }
    }
}
