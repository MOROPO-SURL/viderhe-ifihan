using MOROPO.VIDERHE.Support.Presentation.Managers;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    public partial class HelpPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();

            MainWebView.Source = new Xamarin.Forms.UrlWebViewSource { Url = string.Format("{0}://{1}/support", SessionMemoryManager.Instance.UseSSL ? "https" : "http", SessionMemoryManager.Instance.Server) };
        }
    }
}